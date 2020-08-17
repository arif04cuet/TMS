using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using System.Threading.Tasks;

using static Module.Core.Shared.PermissionConstants;
using Msi.UtilityKit.Pagination;
using Module.Core.Entities;
using Module.Core.Shared;

namespace Module.Core.Controllers
{
    [Route("api/marital-status")]
    [ApiController]
    public class MaritalStatusController : ControllerBase
    {

        private readonly INameService<MaritalStatus> _nameService;

        public MaritalStatusController(
            INameService<MaritalStatus> nameService)
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
        public async Task<ActionResult> Get(long id)
        {
            var result = await _nameService.Get(id);
            return result.ToOkResult();
        }

    }
}
