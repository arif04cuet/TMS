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
    [Route("api/ebooks/formats")]
    [ApiController]
    public class EBookFormatController : ControllerBase
    {

        private readonly INameCrudService<BookFormat> _nameService;

        public EBookFormatController(
            INameCrudService<BookFormat> nameService)
        {
            _nameService = nameService;
        }

        [HttpGet]
        [RequirePermission(EBookFormatList, EBookFormatManage)]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _nameService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        [RequirePermission(EBookFormatView, EBookFormatManage)]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _nameService.Get(id);
            return result.ToOkResult();
        }

    }
}
