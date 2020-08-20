using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace Module.Core.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDataContext _dataContext;
        private readonly ILogger<TestController> _logger;

        public TestController(
            IHttpContextAccessor httpContextAccessor,
            IDataContext dataContext,
            ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<TestController>();
            _dataContext = dataContext;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpGet("server")]
        public ActionResult ServerTest()
        {
            var http = _httpContextAccessor.HttpContext;
            var info = new
            {
                Request = new
                {
                    Path = http.Request.Path,
                    Host = new
                    {
                        Port = http.Request.Host.Port,
                        Value = http.Request.Host.Value,
                        Host = http.Request.Host.Host,
                        UriComponent = http.Request.Host.ToUriComponent()
                    },
                    Scheme = http.Request.Scheme,
                    Protocol = http.Request.Protocol,
                    ContentType = http.Request.ContentType
                },
                TraceIdentifier = http.TraceIdentifier,
                Connection = new
                {
                    RemoteIpAddress = http.Connection.RemoteIpAddress.ToString(),
                    RemotePort = http.Connection.RemotePort,
                    LocalIpAddress = http.Connection.LocalIpAddress.ToString(),
                    LocalPort = http.Connection.LocalPort
                }
            };
            return Ok(info);
        }

        [HttpGet("migrate")]
        public void Migrate()
        {
            if (_dataContext != null)
            {
                try
                {
                    DbContext dbContext = (_dataContext as DbContext);
                    if (dbContext != null)
                    {
                        dbContext.Database.CurrentTransaction?.Dispose();
                        dbContext.Database.Migrate();
                        _logger.LogInformation($"---TEST MIGRATE DONE--- at {DateTime.Now}");
                    }
                    else
                    {
                        _logger.LogInformation($"---TEST MIGRATE DB CONTEXT NULL--- at {DateTime.Now}");
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError($"---TEST MIGRATE ERROR--- at {DateTime.Now}");
                    Exception ex = e;
                    while (ex != null)
                    {
                        _logger.LogError(ex.Message);
                        ex = ex.InnerException;
                    }
                    _logger.LogError($"---TEST MIGRATE ERROR END --- at {DateTime.Now}");
                }
            }

        }

    }
}
