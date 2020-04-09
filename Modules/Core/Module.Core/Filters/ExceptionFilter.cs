using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Module.Core.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is BusinessExceptionBase)
            {
                var exception = (BusinessExceptionBase)context.Exception;
                context.HttpContext.Response.StatusCode = exception.Status;
                context.Result = new ObjectResult(new
                {
                    Status = exception.Status,
                    Message = exception.Message
                });
            }
            else
            {
                context.Result = new ObjectResult(new
                {
                    Status = 500,
                    Message = "Something went wrong."
                });
            }
        }
    }
}
