using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using Module.Core.ViewModels;
using System.Threading.Tasks;
using Module.Core.Data;

using static Module.Core.Data.PermissionConstants;
using Msi.UtilityKit.Pagination;

namespace Module.Core.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly IDepartmentService _departmentService;

        public DepartmentController(
            IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [RequirePermission(DepartmentList, DepartmentManage)]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions)
        {
            var result = await _departmentService.ListAsync(pagingOptions);
            return Ok(new Response(result));
        }

        [HttpGet("{id}")]
        [RequirePermission(DesignationView, DepartmentManage)]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _departmentService.Get(id);
            return Ok(new Response(result));
        }

    }
}
