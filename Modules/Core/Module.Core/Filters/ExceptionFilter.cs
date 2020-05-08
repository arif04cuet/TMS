using Infrastructure;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Module.Core.Filters
{
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUnitOfWork _unitOfWork;
        public ExceptionFilter(
            IWebHostEnvironment env,
            IUnitOfWork unitOfWork)
        {
            _env = env;
            _unitOfWork = unitOfWork;
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            _unitOfWork.RollBackAsync();
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
            return Task.CompletedTask;
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
