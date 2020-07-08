using Infrastructure;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Module.Core.Filters
{
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        public ExceptionFilter(
            IWebHostEnvironment env,
            IUnitOfWork unitOfWork,
            ILogger<ExceptionFilter> logger)
        {
            _env = env;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            _unitOfWork.RollBackAsync();
            if (context.Exception is BusinessExceptionBase)
            {
                var exception = (BusinessExceptionBase)context.Exception;
                context.HttpContext.Response.StatusCode = exception.Status;
                _logger.LogError(exception.Message);
                Console.WriteLine("--------------------------------------");
                Console.WriteLine(exception.Message);
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
                    CollectErrors(context);
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
                _logger.LogError(ex.Message);
                Console.WriteLine("--------------------------------------");
                Console.WriteLine(ex.Message);
                errors.Add(ex.Message);
                ex = ex.InnerException;
            }
            return errors;
        }
    }
}
