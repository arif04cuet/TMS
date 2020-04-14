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
    [Route("api/books/reservations")]
    [ApiController]
    public class BookReservationStatusController : ControllerBase
    {

        private readonly INameCrudService<ReservationStatus> _nameService;

        public BookReservationStatusController(
            INameCrudService<ReservationStatus> nameService)
        {
            _nameService = nameService;
        }

        [HttpGet]
        [RequirePermission(BookReservationList, BookReservationManage)]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _nameService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        [RequirePermission(BookReservationView, BookReservationManage)]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _nameService.Get(id);
            return result.ToOkResult();
        }

    }
}
