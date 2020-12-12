using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Module.Core.Shared;
using Module.Core.Entities;
using Msi.UtilityKit.Search;
using Module.Core.Data;

namespace Module.Core.Controllers
{
    [Route("api/districts")]
    [ApiController]
    public class DistrictController : ControllerBase
    {

        private readonly INameService<District> _nameService;
        private readonly IGeoService _geoService;
        public DistrictController(
            INameService<District> nameService,
            IGeoService geoService
            )
        {
            _nameService = nameService;
            _geoService = geoService;

        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery] PagingOptions pagingOptions, [FromQuery] SearchOptions searchOptions)
        {
            var result = await _geoService.ListDistrictAsync(pagingOptions, searchOptions);
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
