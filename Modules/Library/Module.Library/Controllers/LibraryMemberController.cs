﻿using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using Module.Library.Data;
using System.Threading.Tasks;
using Module.Core.Shared;

using static Module.Core.Shared.PermissionConstants;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;

namespace Module.Library.Controllers
{
    [Route("api/library/members")]
    [ApiController]
    public class LibraryMemberController : ControllerBase
    {

        private readonly ILibraryMemberService _libraryMemberService;

        public LibraryMemberController(
            ILibraryMemberService libraryMemberService)
        {
            _libraryMemberService = libraryMemberService;
        }

        [HttpGet]
        [RequirePermission(LibraryList, LibraryManage)]
        public async Task<ActionResult> List([FromQuery] PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _libraryMemberService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("cards")]
        [RequirePermission(LibraryList, LibraryManage)]
        public async Task<ActionResult> ListMemberCards([FromQuery] PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _libraryMemberService.ListMemberCardsAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _libraryMemberService.GetAsync(id);
            return result.ToOkResult();
        }

        [HttpPost]
        [RequirePermission(LibraryCreate, LibraryManage)]
        public async Task<IActionResult> Post([FromBody] LibraryMemberCreateRequest request)
        {
            var result = await _libraryMemberService.CreateAsync(request);
            return result.ToCreatedResult($"api/libraries/members/{result}");
        }

        [HttpPost("register-from-users")]
        [RequirePermission(LibraryCreate, LibraryManage)]
        public async Task<IActionResult> CreateFromUser([FromBody] LibraryMemberCreateFromUserRequest request)
        {
            var result = await _libraryMemberService.CreateFromUserAsync(request);
            return result.ToCreatedResult($"api/libraries/members/{result}");
        }

        [HttpPut("{id}")]
        [RequirePermission(BookUpdate, BookManage)]
        public async Task<IActionResult> Put(long id, [FromBody] LibraryMemberUpdateRequest request)
        {
            request.Id = id;
            var result = await _libraryMemberService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        [RequirePermission(LibraryDelete, LibraryManage)]
        public async Task<IActionResult> Delete(long id)
        {
            await _libraryMemberService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("approved")]
        [RequirePermission(LibraryCreate, LibraryManage)]
        public async Task<IActionResult> ApproveAsync([FromBody] LibraryMemberApproveCreateRequest request)
        {
            var result = await _libraryMemberService.ApproveMemberAsync(request);
            return result.ToOkResult();
        }

        [HttpPost("request")]
        [RequirePermission(LibraryCreate, LibraryManage)]
        public async Task<IActionResult> RequestAsync([FromBody] LibraryMemberRequestCreateRequest request)
        {
            var result = await _libraryMemberService.CreateRequestAsync(request);
            return result.ToOkResult();
        }

        [HttpGet("request")]
        [RequirePermission(LibraryCreate, LibraryManage)]
        public async Task<IActionResult> ListRequestsUser([FromQuery]bool? isApproved, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions = default)
        {
            var result = await _libraryMemberService.ListMemberRequestAsync(isApproved, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

    }
}
