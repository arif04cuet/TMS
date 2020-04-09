//using Core.Infrastructure.Commands;
//using Microsoft.AspNetCore.Identity;
//using Module.Identity.Entities;
//using Module.Identity.Persistence.EntityFramework;
//using Msi.Extensions.Persistence.Abstractions;
//using System;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Module.Identity.Domain.Login
//{
//    public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginDto>
//    {

//        private readonly IUnitOfWork<IdentityDataContext> _unitOfWork;
//        private readonly IPasswordHasher<User> _passwordHasher;

//        public LoginCommandHandler(
//            IUnitOfWork<IdentityDataContext> unitOfWork,
//            IPasswordHasher<User> passwordHasher)
//        {
//            _unitOfWork = unitOfWork;
//            _passwordHasher = passwordHasher;
//        }

//        public async Task<LoginDto> Handle(LoginCommand request, CancellationToken cancellationToken)
//        {
//            //var hashedPassword = new PasswordHasher<User>().HashPassword(user1, "123456");
//            var user = await _unitOfWork.GetRepository<User>().FirstOrDefaultAsync(x => x.Email == request.Username);

//            if(user == null)
//            {
//                throw new Exception("user name or password invalid");
//            }

//            var r = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
//            if(r == PasswordVerificationResult.Success)
//            {
//                return new LoginDto {
//                    Authenticated = true,
//                    ReditectUrl = request.ReturnUrl,
//                    UserId = user.Id
//                };
//            }

//            return null;
//        }
//    }
//}
