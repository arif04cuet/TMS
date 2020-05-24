using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Core.Shared;
using Module.Training.Data;

namespace Module.Training.Controllers
{

    [Route("api/hostels")]
    [ApiController]
    public class HostelController : ControllerBase
    {

        private readonly IHostelService _hostelService;

        public HostelController(
            IHostelService hostelService)
        {
            _hostelService = hostelService;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _hostelService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _hostelService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HostelCreateRequest request)
        {
            var result = await _hostelService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] HostelUpdateRequest request)
        {
            request.Id = id;
            var result = await _hostelService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _hostelService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}/buildings")]
        public async Task<ActionResult> ListFloors(long id, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _hostelService.ListBuildingsAsync(id, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}/buildings/{buildingId}/floors")]
        public async Task<ActionResult> ListBuildings(long id, long buildingId, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _hostelService.ListFloorsAsync(id, buildingId, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}/buildings/{buildingId}/floors/{floorId}/rooms")]
        public async Task<ActionResult> ListRooms(long id, long buildingId, long floorId, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _hostelService.ListRoomsAsync(id, buildingId, floorId, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

    }
}
