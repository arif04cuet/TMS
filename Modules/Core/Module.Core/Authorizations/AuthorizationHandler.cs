using Infrastructure.Data;
using Infrastructure.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Module.Core.Data.Criteria;
using Module.Core.Entities;
using System.Threading.Tasks;

namespace Module.Core.Authorizations
{
    public class AuthorizationHandler : IAuthorizationHandler
    {
        private readonly IAuthenticatedUser _authenticatedUser;
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;

        public AuthorizationHandler(
            IAuthenticatedUser authenticatedUser,
            ILoggerFactory loggerFactory,
            IUnitOfWork unitOfWork)
        {
            _authenticatedUser = authenticatedUser;
            _logger = loggerFactory.CreateLogger<AuthorizationHandler>();
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<User>();
        }

        public async Task HandleAsync(AuthorizationHandlerContext context)
        {
            if (_authenticatedUser != null && _authenticatedUser.Id > 0)
            {
                var criteria = new ExistUserByIdEmailCriteria(_authenticatedUser.Id, _authenticatedUser.Email);
                if (await _userRepository.MatchAsync(criteria))
                {
                    context.Succeed(null);
                }
            }
            else
            {
                _logger.LogInformation($"Can not find any login user.");
            }
        }
    }
}
