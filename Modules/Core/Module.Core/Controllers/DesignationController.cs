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
        [RequirePermission(DesignationList, DepartmentManage)]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions)
        {
            var result = await _designationService.ListAsync(pagingOptions);
            return Ok(new Response(result));
        }

        [HttpGet("{id}")]
        [RequirePermission(DesignationView, DepartmentManage)]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _designationService.Get(id);
            return Ok(new Response(result));
        }

        [HttpPost]
        [RequirePermission(DesignationCreate, DepartmentManage)]
        public async Task<IActionResult> Post([FromBody] DesignationCreateRequest request)
        {
            var result = await _designationService.CreateAsync(request);
            return Created("", new Response(result));
        }

        [HttpPut("{id}")]
        [RequirePermission(DesignationUpdate, DepartmentManage)]
        public async Task<IActionResult> Put(int id, [FromBody] DesignationUpdateRequest request)
        {
            request.Id = id;
            var result = await _designationService.UpdateAsync(request);
            return Ok(new Response(result));
        }

        [HttpDelete("{id}")]
        [RequirePermission(DesignationDelete, DepartmentManage)]
        public async Task<IActionResult> Delete(long id)
        {
            await _designationService.DeleteAsync(id);
            return NoContent();
        }

    }
}
