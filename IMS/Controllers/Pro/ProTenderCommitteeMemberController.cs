using AutoMapper;
using Business.Pro;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderCommitteeMemberViewModels;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Entities.ExtensionMethods;
using Microsoft.EntityFrameworkCore;
using Entities.ViewModels.Pro.ProTenderComitteeMemberViewModels;

namespace IMS.Controllers.Pro
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProTenderCommitteeMemberController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ProTenderCommitteeMemberService _ProTenderCommitteeMemberService;
        public ProTenderCommitteeMemberController(
            IMapper mapper,
            ProTenderCommitteeMemberService ProTenderCommitteeMemberService)
        {
            _mapper = mapper;
            _ProTenderCommitteeMemberService = ProTenderCommitteeMemberService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProTenderCommitteeMemberOutputVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            ProTenderCommitteeMember model = await _ProTenderCommitteeMemberService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<ProTenderCommitteeMemberOutputVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<ProTenderCommitteeMemberOutputVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] ProTenderCommitteeMemberFilter filter)
        {
            IQueryable<ProTenderCommitteeMember> items = _ProTenderCommitteeMemberService.GetPaginated(pagination);
            IQueryable<ProTenderCommitteeMemberOutputVM> result =
                _mapper.ProjectTo<ProTenderCommitteeMemberOutputVM>(items);

            PaginatedResult<ProTenderCommitteeMemberOutputVM> mappedResult = new()
            {
                Items = await result.ToPaginatedResultUnMapped(pagination).ToListAsync(),
                Page = pagination.Index,
                PageSize = pagination.Size,
                TotalItems = await result.CountAsync(),
            };
            return Ok(mappedResult);
        }
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add([FromForm] ProTenderCommitteeMemberInputVM input)
        {
            ProTenderCommitteeMember model = _mapper.Map<ProTenderCommitteeMember>(input);
            int rowsAffected = await _ProTenderCommitteeMemberService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromForm] ProTenderCommitteeMemberInputVM input)
        {
            ProTenderCommitteeMember model = await _ProTenderCommitteeMemberService.GetById(id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _ProTenderCommitteeMemberService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            ProTenderCommitteeMember model = await _ProTenderCommitteeMemberService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _ProTenderCommitteeMemberService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
