using AutoMapper;
using Business.Pro;
using Entities.Models.Pro;
using Entities.ViewModels;
using Entities.ViewModels.Pro.ProTenderDetailsViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IMS.Controllers.PR
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProTenderDetailsController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ProTenderDetailsService _proTenderDetailsService;
        public ProTenderDetailsController(
            IMapper mapper,
            ProTenderDetailsService proTenderDetailsService)
        {
            _mapper = mapper;
            _proTenderDetailsService = proTenderDetailsService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProTenderDetailsInputVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            ProTenderDetails model = await _proTenderDetailsService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<ProTenderDetailsInputVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<ProTenderDetailsInputVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] ProTenderDetailsFilter filter)
        {
            PaginatedResultUnMapped<ProTenderDetails> unmappedResult =
                _proTenderDetailsService
                .GetFilteredPaginated(pagination, filter);
            PaginatedResult<ProTenderDetailsInputVM> mappedResult = new()
            {
                Items = await _mapper.ProjectTo<ProTenderDetailsInputVM>(unmappedResult.Items).ToListAsync(),
                Page = unmappedResult.Page,
                PageSize = unmappedResult.PageSize,
                TotalItems = unmappedResult.TotalItems,
            };
            return Ok(mappedResult);
        }
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add(ProTenderDetailsInputVM input)
        {
            ProTenderDetails model = _mapper.Map<ProTenderDetails>(input);
            int rowsAffected = await _proTenderDetailsService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(ProTenderDetailsInputVM input)
        {

            ProTenderDetails model = await _proTenderDetailsService.GetById(input.Id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _proTenderDetailsService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            ProTenderDetails model = await _proTenderDetailsService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _proTenderDetailsService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
