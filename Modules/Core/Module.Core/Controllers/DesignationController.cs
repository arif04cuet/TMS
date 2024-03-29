﻿using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using System.Threading.Tasks;

using static Module.Core.Shared.PermissionConstants;
using Msi.UtilityKit.Pagination;
using Module.Core.Shared;
using Module.Core.Entities;
using Msi.UtilityKit.Search;

namespace Module.Core.Controllers
{
    [Route("api/designations")]
    [ApiController]
    public class DesignationController : ControllerBase
    {

        private readonly INameCrudService<Designation> _nameCrudService;

        public DesignationController(
            INameCrudService<Designation> nameCrudService)
        {
            _nameCrudService = nameCrudService;
        }

        [HttpGet]
        [RequirePermission(DesignationList, DepartmentManage)]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _nameCrudService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _nameCrudService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        [RequirePermission(DesignationCreate, DepartmentManage)]
        public async Task<IActionResult> Post([FromBody] NameCreateRequest request)
        {
            var result = await _nameCrudService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        [RequirePermission(DesignationUpdate, DepartmentManage)]
        public async Task<IActionResult> Put(int id, [FromBody] NameUpdateRequest request)
        {
            request.Id = id;
            var result = await _nameCrudService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        [RequirePermission(DesignationDelete, DepartmentManage)]
        public async Task<IActionResult> Delete(long id)
        {
            await _nameCrudService.DeleteAsync(id);
            return NoContent();
        }

    }
}
