using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Msi.UtilityKit.Pagination;

namespace Module.Core.Shared
{
    public static class ResultExtensions
    {
        public static IResult ToResult<T>(this PagedCollection<T> pagedCollection, int status = 200, string message = default)
        {
            return new Result(pagedCollection, status, message);
        }

        public static IResult ToResult<T>(this T model, int status = 200, string message = default)
        {
            return new Result(model, status, message);
        }

        public static ActionResult ToOkResult<T>(this T model, int status = 200, string message = default)
        {
            return new OkObjectResult(model.ToResult(status, message));
        }

        public static ActionResult ToOkResult<T>(this PagedCollection<T> pagedCollection, int status = 200, string message = default)
        {
            return new OkObjectResult(pagedCollection.ToResult(status, message));
        }

        public static ActionResult ToCreatedResult<T>(this T value, string location = "", int status = 201, string message = default)
        {
            return new CreatedResult(location, value.ToResult(status, message));
        }

        public static ActionResult ToFileResult(this byte[] result, HttpContext httpContext, string contentType, string filename)
        {
            if (result != null && result.Length > 0)
            {
                string contetntType = contentType;
                httpContext.Response.ContentType = contetntType;
                var fileResult = new FileContentResult(result, contetntType);
                fileResult.FileDownloadName = filename;
                return fileResult;
            }
            return new NoContentResult();
        }

        public static ActionResult ToCsvResult(this byte[] result, HttpContext httpContext, string filename = "")
        {
            return result.ToFileResult(httpContext, @"text/csv", filename);
        }
    }
}
