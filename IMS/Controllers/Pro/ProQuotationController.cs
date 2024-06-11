using AutoMapper;
using Business.Pro;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProQuotationViewModels;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IMS.Controllers.Pro
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProQuotationController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ProQuotationService _ProQuotationService;
        public ProQuotationController(
            IMapper mapper,
            ProQuotationService ProQuotationService)
        {
            _mapper = mapper;
            _ProQuotationService = ProQuotationService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProQuotationOutputVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            ProQuotation model = await _ProQuotationService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<ProQuotationOutputVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<ProQuotationOutputVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] ProQuotationFilter filter)
        {
            PaginatedResultUnMapped<ProQuotation> unmappedResult =
                _ProQuotationService
                .GetFilteredPaginated(pagination, filter);
            PaginatedResult<ProQuotationOutputVM> mappedResult = new()
            {
                Items = await _mapper.ProjectTo<ProQuotationOutputVM>(unmappedResult.Items).ToListAsync(),
                Page = unmappedResult.Page,
                PageSize = unmappedResult.PageSize,
                TotalItems = unmappedResult.TotalItems,
            };
            return Ok(mappedResult);
        }
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add([FromForm] ProQuotationInputVM input)
        {
            ProQuotation model = _mapper.Map<ProQuotation>(input);
            int rowsAffected = await _ProQuotationService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromForm] ProQuotationInputVM input)
        {
            ProQuotation model = await _ProQuotationService.GetById(input.Id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _ProQuotationService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            ProQuotation model = await _ProQuotationService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _ProQuotationService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
