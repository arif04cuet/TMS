using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using Module.Core.ViewModels;
using System.Threading.Tasks;
using Module.Core.Data;

using static Module.Core.Data.PermissionConstants;
using Msi.UtilityKit.Pagination;

namespace Module.Core.Controllers
{
    [Route("api/designations")]
    [ApiController]
    public class DesignationController : ControllerBase
    {

        private readonly IDesignationService _designationService;

        public DesignationController(
            IDesignationService designationService)
        {
            _designationService = designationService;
        }

        [HttpGet]
        [RequirePermission(RoleList)]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions)
        {
            var result = await _designationService.ListAsync(pagingOptions);
            return Ok(new Response(result));
        }

        [HttpGet("{id}")]
        [RequirePermission(RoleView)]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _designationService.Get(id);
            return Ok(new Response(result));
        }

    }
}
