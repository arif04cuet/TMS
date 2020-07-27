using Infrastructure.Security;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Module.Core.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        private readonly IAuthenticatedUser _authenticatedUser;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //if (_authenticatedUser != null && _authenticatedUser.Id > 0)
            //{
            //    var userExist = _unitOfWork.GetRepository<User>()
            //        .Where(x => x.Id == _authenticatedUser.Id && x.Email == _authenticatedUser.Email && !x.IsDeleted)
            //        .AsNoTracking()
            //        .Select(x => x.Id)
            //        .Count() > 0;
            //    if (userExist)
            //    {
            //        context.Succeed(null);
            //    }
            //}
            //else
            //{
            //    _logger.LogInformation($"Can not find any login user.");
            //}

            //return Task.CompletedTask;
        }
    }
}
