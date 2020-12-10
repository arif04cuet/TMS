using Infrastructure;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;
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
                    var err = CollectErrors(context);
                    result = GetProductionErrorResult(err.Item2);
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
            var err = CollectErrors(context);
            return new ObjectResult(new
            {
                Status = 500,
                Message = err.Item2 ? "Can't delete, child records exist." : "Something went wrong.",
                Errors = err.Item1,
                Error = err.Item2 ? "DELETE_CONFLICT_ERROR" : null
            })
            {
                StatusCode = 500
            };
        }

        private ObjectResult GetProductionErrorResult(bool conflicted = false)
        {
            return new ObjectResult(new
            {
                Status = 500,
                Message = conflicted ? "Can't delete, child records exist." : "Something went wrong.",
                Error = conflicted ? "DELETE_CONFLICT_ERROR" : null
            })
            {
                StatusCode = 500
            };
        }

        private (List<string>, bool) CollectErrors(ExceptionContext context)
        {
            List<string> errors = new List<string>();
            Exception ex = context.Exception;
            bool isSqpException = ex is SqlException;
            bool conflicted = false;
            while (ex != null)
            {
                if(isSqpException)
                {
                    SqlException sqlEx = ex as SqlException;
                    if(sqlEx.Number == 547)
                    {
                        conflicted = true;
                    }
                }
                _logger.LogError(ex.Message);
                errors.Add(ex.Message);
                ex = ex.InnerException;
                isSqpException = ex is SqlException;
            }
            return (errors, conflicted);
        }
    }
}
