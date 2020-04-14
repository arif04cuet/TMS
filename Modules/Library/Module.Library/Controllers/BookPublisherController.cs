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
    [Route("api/books/publishers")]
    [ApiController]
    public class BookPublisherController : ControllerBase
    {

        private readonly INameCrudService<Author> _nameCrudService;

        public BookPublisherController(
            INameCrudService<Author> nameCrudService)
        {
            _nameCrudService = nameCrudService;
        }

        [HttpGet]
        [RequirePermission(PublisherList, PublisherManage)]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _nameCrudService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        [RequirePermission(PublisherView, PublisherManage)]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _nameCrudService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        [RequirePermission(PublisherCreate, PublisherManage)]
        public async Task<IActionResult> Post([FromBody] NameCreateRequest request)
        {
            var result = await _nameCrudService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        [RequirePermission(PublisherUpdate, PublisherManage)]
        public async Task<IActionResult> Put(int id, [FromBody] NameUpdateRequest request)
        {
            request.Id = id;
            var result = await _nameCrudService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        [RequirePermission(PublisherDelete, PublisherManage)]
        public async Task<IActionResult> Delete(long id)
        {
            await _nameCrudService.DeleteAsync(id);
            return NoContent();
        }

    }
}
