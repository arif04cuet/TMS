using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using System.Threading.Tasks;
using Module.Core.Shared;

using static Module.Core.Shared.PermissionConstants;
using Module.Library.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;

namespace Module.Library.Controllers
{
    [Route("api/books/subjects")]
    [ApiController]
    public class BookSubjectController : ControllerBase
    {

        private readonly INameCrudService<Subject> _nameCrudService;

        public BookSubjectController(
            INameCrudService<Subject> nameCrudService)
        {
            _nameCrudService = nameCrudService;
        }

        [HttpGet]
        [RequirePermission(SubjectList, SubjectManage)]
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
        [RequirePermission(SubjectCreate, SubjectManage)]
        public async Task<IActionResult> Post([FromBody] NameCreateRequest request)
        {
            var result = await _nameCrudService.CreateAsync(request);
            return result.ToCreatedResult($"api/books/subjects/{result}");
        }

        [HttpPut("{id}")]
        [RequirePermission(SubjectUpdate, SubjectManage)]
        public async Task<IActionResult> Put(int id, [FromBody] NameUpdateRequest request)
        {
            request.Id = id;
            var result = await _nameCrudService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        [RequirePermission(SubjectDelete, SubjectManage)]
        public async Task<IActionResult> Delete(long id)
        {
            await _nameCrudService.DeleteAsync(id);
            return NoContent();
        }

    }
}
