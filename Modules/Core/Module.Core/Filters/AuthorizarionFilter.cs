using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Module.Core.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //
        }
    }
}
