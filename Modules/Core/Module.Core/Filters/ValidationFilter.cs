using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Module.Core.Data.ViewModels;
using Module.Core.ViewModels;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Module.Core.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ModelState.IsValid)
            {
                await next();
            }
            else
            {
                var data = from kvp in context.ModelState
                           from err in kvp.Value.Errors
                           let k = kvp.Key
                           select new ValidationError(k, string.IsNullOrEmpty(err.ErrorMessage) ? "Invalid Input" : err.ErrorMessage);

                var response = new UnprocessableEntityObjectResult(new Response(data, (int)HttpStatusCode.UnprocessableEntity, "form_error"));
                context.Result = response;
            }

        }
    }
}
