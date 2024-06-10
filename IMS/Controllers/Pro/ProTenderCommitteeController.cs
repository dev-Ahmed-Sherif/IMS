using AutoMapper;
using Business.Pro;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderCommitteeViewModels;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.ViewModels.Pro.ProTenderCommitteeViewModels;

namespace IMS.Controllers.Pro
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProTenderCommitteeController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ProTenderCommitteeService _ProTenderCommitteeService;
        public ProTenderCommitteeController(
            IMapper mapper,
            ProTenderCommitteeService ProTenderCommitteeService)
        {
            _mapper = mapper;
            _ProTenderCommitteeService = ProTenderCommitteeService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProTenderCommitteeOutputVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            ProTenderCommittee model = await _ProTenderCommitteeService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<ProTenderCommitteeOutputVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<ProTenderCommitteeOutputVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] ProTenderCommitteeFilter filter)
        {
            PaginatedResultUnMapped<ProTenderCommittee> unmappedResult =
                _ProTenderCommitteeService
                .GetFilteredPaginated(pagination, filter);
            PaginatedResult<ProTenderCommitteeOutputVM> mappedResult = new()
            {
                Items = await _mapper.ProjectTo<ProTenderCommitteeOutputVM>(unmappedResult.Items).ToListAsync(),
                Page = unmappedResult.Page,
                PageSize = unmappedResult.PageSize,
                TotalItems = unmappedResult.TotalItems,
            };
            return Ok(mappedResult);
        }
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add(ProTenderCommitteeInputVM input)
        {
            ProTenderCommittee model = _mapper.Map<ProTenderCommittee>(input);
            int rowsAffected = await _ProTenderCommitteeService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(ProTenderCommitteeInputVM input)
        {

            ProTenderCommittee model = await _ProTenderCommitteeService.GetById(input.Id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _ProTenderCommitteeService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            ProTenderCommittee model = await _ProTenderCommitteeService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _ProTenderCommitteeService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
