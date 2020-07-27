using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Module.Core.Entities;
using Module.Core.Shared;
using Msi.UtilityKit.Security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using static Module.Core.Shared.MessageConstants;

namespace Module.Core.Data
{
    public class TokenService : ITokenService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtTokenOptions _jwtTokenOptions;
        private readonly IRepository<UserToken> _userTokenRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<RefreshToken> _refreshTokenRepository;
        private readonly IAppService _appService;
        private static long ToUnixEpochDate(DateTime date)
          => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        public TokenService(
            IUnitOfWork unitOfWork,
            IOptions<JwtTokenOptions> jwtTokenOptions,
            IAppService appService)
        {
            _unitOfWork = unitOfWork;
            _appService = appService;
            _jwtTokenOptions = jwtTokenOptions.Value;
            _userTokenRepository = _unitOfWork.GetRepository<UserToken>();
            _userRepository = _unitOfWork.GetRepository<User>();
            _refreshTokenRepository = _unitOfWork.GetRepository<RefreshToken>();
        }

        public async Task<TokenViewModel> CreateAsync(TokenCreateRequest request)
        {
            string hashedPassword = request.Password.HashPassword();
            var user = await _userRepository.FirstOrDefaultAsync(x => x.Email.ToLower() == request.Email.ToLower() && x.Password == hashedPassword);

            if (user == null)
                throw new ValidationException(INVALID_EMAIL_OR_PASSWORD);

            return await CreateAsync(user.Id);
        }

        public async Task<TokenViewModel> CreateAsync(long userId)
        {
            var user = await _userRepository.FirstOrDefaultAsync(x => x.Id == userId, true);

            if (user == null)
                throw new NotFoundException(USER_NOT_FOUND);

            // Delete old tokens
            var oldTokens = _userTokenRepository.Where(x => x.UserId == userId);
            var oldRefreshTokens = oldTokens.Select(x => x.RefreshToken);

            _userTokenRepository.RemoveRange(oldTokens);
            _refreshTokenRepository.RemoveRange(oldRefreshTokens);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim("user_id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, await _jwtTokenOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtTokenOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64)
            };

            var refreshToken = new RefreshToken
            {
                Token = GenerateRefreshToken(),
                ExpiresIn = _jwtTokenOptions.RefreshTokenExpiration
            };

            await _refreshTokenRepository.AddAsync(refreshToken);
            await _unitOfWork.SaveChangesAsync();

            var userToken = new UserToken
            {
                AccessToken = GenerateToken(claims),
                RefreshTokenId = refreshToken.Id,
                ExpiresIn = _jwtTokenOptions.AccessTokenExpiration,
                UserId = userId
            };

            await _userTokenRepository.AddAsync(userToken);
            var result = await _unitOfWork.SaveChangesAsync();

            var userRoles = await _unitOfWork.GetRepository<UserRole>()
                .AsReadOnly()
                .Where(x => x.UserId == userId)
                .Select(x => new IdNameViewModel
                {
                    Id = x.RoleId,
                    Name = x.Role.Name
                })
                .ToListAsync();

            var profilePhoto = await _unitOfWork.GetRepository<UserProfile>()
                .Where(x => x.UserId == user.Id && !x.IsDeleted)
                .Select(x => x.Media.FileName)
                .FirstOrDefaultAsync();

            if(!string.IsNullOrEmpty(profilePhoto))
            {
                profilePhoto = Path.Combine(_appService.GetServerUrl(), MediaConstants.Path, profilePhoto);
            }

            return new TokenViewModel
            {
                AccessToken = userToken.AccessToken,
                RefreshToken = refreshToken.Token,
                ExpiresIn = (int)_jwtTokenOptions.AccessTokenValidFor.TotalSeconds,
                UserId = userId,
                UserInfo = new UserInfoViewModel
                {
                    Id = userId,
                    Name = user.FullName,
                    Email = user.Email,
                    Roles = userRoles,
                    Photo = profilePhoto
                }
            };

        }

        public async Task<TokenViewModel> RefreshAsync(TokenRefreshRequest request)
        {
            // Retrieve tokens
            var userToken = await _userTokenRepository.FirstOrDefaultAsync(x => x.AccessToken == request.AccessToken && x.RefreshToken.Token == request.RefreshToken);

            if (userToken == null)
                throw new SecurityTokenException(INVALID_TOKEN);

            // TODO: Check token expire time

            var principal = GetPrincipalFromExpiredToken(request.AccessToken);
            var username = principal.Identity.Name;

            var newJwtToken = GenerateToken(principal.Claims);

            // Delete old tokens
            _userTokenRepository.Remove(userToken);
            _refreshTokenRepository.Remove(userToken.RefreshToken);

            // Save new tokens
            var newRefreshToken = new RefreshToken
            {
                Token = GenerateRefreshToken(),
                ExpiresIn = _jwtTokenOptions.RefreshTokenExpiration
            };
            await _refreshTokenRepository.AddAsync(newRefreshToken);

            var newUserToken = new UserToken
            {
                AccessToken = newJwtToken,
                RefreshTokenId = newRefreshToken.Id,
                ExpiresIn = _jwtTokenOptions.AccessTokenExpiration,
                UserId = userToken.UserId
            };
            await _userTokenRepository.AddAsync(newUserToken);

            var result = _unitOfWork.SaveChangesAsync();

            return new TokenViewModel
            {
                AccessToken = newJwtToken,
                RefreshToken = newRefreshToken.Token,
                ExpiresIn = (int)_jwtTokenOptions.AccessTokenValidFor.TotalSeconds
            };
        }

        public async Task<bool> RevokeAsync(TokenRevokeRequest request)
        {
            var userToken = await _userTokenRepository.FirstOrDefaultAsync(x => x.RefreshToken.Token == request.RefreshToken);

            if (userToken == null)
                throw new NotFoundException(INVALID_TOKEN);

            _userTokenRepository.Remove(userToken);
            _refreshTokenRepository.Remove(userToken.RefreshToken);
            var result = await _unitOfWork.SaveChangesAsync();
            return result > 0;
        }

        // Generate Token
        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var jwt = new JwtSecurityToken(
                issuer: _jwtTokenOptions.Issuer,
                audience: _jwtTokenOptions.Audience,
                claims: claims,
                notBefore: _jwtTokenOptions.NotBefore,
                expires: _jwtTokenOptions.AccessTokenExpiration,
                signingCredentials: _jwtTokenOptions.SigningCredentials);
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        // Get Claim Principle
        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidIssuer = _jwtTokenOptions.Issuer,
                ValidateIssuer = true,
                ValidAudience = _jwtTokenOptions.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenOptions.SecretKey)),
                // We don't care about the token's expiration date
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException(INVALID_TOKEN);
            return principal;
        }

        // Generate Refresh Token
        private string GenerateRefreshToken()
        {
            var bytes = new byte[32];
            var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

    }
}
