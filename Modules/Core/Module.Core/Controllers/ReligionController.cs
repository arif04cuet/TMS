using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using System.Threading.Tasks;

using static Module.Core.Shared.PermissionConstants;
using Msi.UtilityKit.Pagination;
using Module.Core.Shared;
using Module.Core.Entities;

namespace Module.Core.Controllers
{
    [Route("api/religions")]
    [ApiController]
    public class ReligionController : ControllerBase
    {

        private readonly INameService<Religion> _nameService;

        public ReligionController(
            INameService<Religion> nameService)
        {
            _nameService = nameService;
        }

        [HttpGet]
        [RequirePermission(RoleList)]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions)
        {
            var result = await _nameService.ListAsync(pagingOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        [RequirePermission(RoleView)]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _nameService.Get(id);
            return result.ToOkResult();
        }

    }
}
