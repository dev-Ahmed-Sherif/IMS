using AutoMapper;
using Business.Pro;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderOpeningMemberViewModels;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Entities.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace IMS.Controllers.Pro
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProTenderOpeningMemberController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ProTenderOpeningMemberService _ProTenderOpeningMemberService;
        public ProTenderOpeningMemberController(
            IMapper mapper,
            ProTenderOpeningMemberService ProTenderOpeningMemberService)
        {
            _mapper = mapper;
            _ProTenderOpeningMemberService = ProTenderOpeningMemberService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProTenderOpeningMemberOutputVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            ProTenderOpeningMember model = await _ProTenderOpeningMemberService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<ProTenderOpeningMemberOutputVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<ProTenderOpeningMemberOutputVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] ProTenderOpeningMemberFilter filter)
        {
            IQueryable<ProTenderOpeningMember> items = _ProTenderOpeningMemberService.GetPaginated(pagination);
            IQueryable<ProTenderOpeningMemberOutputVM> result =
                _mapper.ProjectTo<ProTenderOpeningMemberOutputVM>(items);

            PaginatedResult<ProTenderOpeningMemberOutputVM> mappedResult = new()
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
        public async Task<IActionResult> Add(ProTenderOpeningMemberInputVM input)
        {
            ProTenderOpeningMember model = _mapper.Map<ProTenderOpeningMember>(input);
            int rowsAffected = await _ProTenderOpeningMemberService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromForm] ProTenderOpeningMemberInputVM input)
        {
            ProTenderOpeningMember model = await _ProTenderOpeningMemberService.GetById(id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _ProTenderOpeningMemberService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            ProTenderOpeningMember model = await _ProTenderOpeningMemberService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _ProTenderOpeningMemberService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
