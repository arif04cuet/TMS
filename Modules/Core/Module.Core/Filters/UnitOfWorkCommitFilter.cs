using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Module.Core.Filters
{
    public class UnitOfWorkCommitFilter : IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var result = await next();

            if(result.Exception == null && context.HttpContext.Request.Method != "GET")
            {
                var unitOfWork = result.HttpContext.RequestServices.GetService(typeof   (IUnitOfWork)) as IUnitOfWork;
                await unitOfWork.CommitAsync();
            }
        }
    }
}
