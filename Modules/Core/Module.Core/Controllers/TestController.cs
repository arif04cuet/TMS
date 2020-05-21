using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Module.Core.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpRequest _request;

        public TestController(IHttpContextAccessor httpContextAccessor)
        {
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
                Connection = new {
                    RemoteIpAddress = http.Connection.RemoteIpAddress.ToString(),
                    RemotePort = http.Connection.RemotePort,
                    LocalIpAddress = http.Connection.LocalIpAddress.ToString(),
                    LocalPort = http.Connection.LocalPort
                }
            };
            return Ok(info);
        }

    }
}
