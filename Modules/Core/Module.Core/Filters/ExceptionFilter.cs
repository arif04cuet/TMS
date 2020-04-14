using Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

namespace Module.Core.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _env;
        public ExceptionFilter(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void OnException(ExceptionContext context)
        {
            System.Console.WriteLine(context.Exception.Message);
            if (context.Exception is BusinessExceptionBase)
            {
                var exception = (BusinessExceptionBase)context.Exception;
                context.HttpContext.Response.StatusCode = exception.Status;
                context.Result = new ObjectResult(new
                {
                    Status = exception.Status,
                    Message = exception.Message
                })
                {
                    StatusCode = exception.Status
                };
            }
            else
            {
                ObjectResult result;
                if (_env.IsProduction())
                {
                    result = GetProductionErrorResult();
                }
                else
                {
                    result = GetDevelopmentErrorResult(context);
                }
                context.Result = result;
            }
        }

        private ObjectResult GetDevelopmentErrorResult(ExceptionContext context)
        {
            return new ObjectResult(new
            {
                Status = 500,
                Message = "Something went wrong.",
                Errors = CollectErrors(context)
            })
            {
                StatusCode = 500
            };
        }

        private ObjectResult GetProductionErrorResult()
        {
            return new ObjectResult(new
            {
                Status = 500,
                Message = "Something went wrong."
            })
            {
                StatusCode = 500
            };
        }

        private List<string> CollectErrors(ExceptionContext context)
        {
            List<string> errors = new List<string>();
            Exception ex = context.Exception;
            while (ex != null)
            {
                errors.Add(ex.Message);
                ex = ex.InnerException;
            }
            return errors;
        }
    }
}
