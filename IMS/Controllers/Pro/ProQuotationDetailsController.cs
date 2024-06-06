using AutoMapper;
using Business.Pro;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProQuotationDetailsViewModels;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IMS.Controllers.Pro
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProQuotationDetailsController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ProQuotationDetailsService _ProQuotationDetailsService;
        public ProQuotationDetailsController(
            IMapper mapper,
            ProQuotationDetailsService ProQuotationDetailsService)
        {
            _mapper = mapper;
            _ProQuotationDetailsService = ProQuotationDetailsService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProQuotationDetailsOutputVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            ProQuotationDetails model = await _ProQuotationDetailsService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<ProQuotationDetailsOutputVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<ProQuotationDetailsOutputVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] ProQuotationDetailsFilter filter)
        {
            PaginatedResultUnMapped<ProQuotationDetails> unmappedResult =
                _ProQuotationDetailsService
                .GetFilteredPaginated(pagination, filter);
            PaginatedResult<ProQuotationDetailsOutputVM> mappedResult = new()
            {
                Items = await _mapper.ProjectTo<ProQuotationDetailsOutputVM>(unmappedResult.Items).ToListAsync(),
                Page = unmappedResult.Page,
                PageSize = unmappedResult.PageSize,
                TotalItems = unmappedResult.TotalItems,
            };
            return Ok(mappedResult);
        }
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add(ProQuotationDetailsInputVM input)
        {
            ProQuotationDetails model = _mapper.Map<ProQuotationDetails>(input);
            int rowsAffected = await _ProQuotationDetailsService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(ProQuotationDetailsInputVM input)
        {
            ProQuotationDetails model = await _ProQuotationDetailsService.GetById(input.Id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _ProQuotationDetailsService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            ProQuotationDetails model = await _ProQuotationDetailsService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _ProQuotationDetailsService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
