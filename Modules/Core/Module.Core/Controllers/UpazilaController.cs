using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Module.Core.Shared;
using Module.Core.Entities;
using Msi.UtilityKit.Search;
using Module.Core.Data;

namespace Module.Core.Controllers
{
    [Route("api/upazilas")]
    [ApiController]
    public class UpazilaController : ControllerBase
    {

        private readonly INameService<Upazila> _nameService;
        private readonly IGeoService _geoService;

        public UpazilaController(
            INameService<Upazila> nameService,
            IGeoService geoService
            )
        {
            _nameService = nameService;
            _geoService = geoService;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery] PagingOptions pagingOptions, [FromQuery] SearchOptions searchOptions)
        {
            var result = await _geoService.ListUpazilaAsync(pagingOptions, searchOptions);
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
