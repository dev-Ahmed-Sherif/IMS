using AutoMapper;
using Business.Pro;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProQuotationViewModels;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.ViewModels.Pro.ProTenderVendorReqSendTypeViewModels;
using System.Linq;
using Entities.ExtensionMethods;

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
        public IActionResult GetById(int id)
        {
            ProQuotation model = _ProQuotationService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<ProQuotationOutputVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<ProQuotationOutputVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] ProQuotationFilter filter)
        {
            IQueryable<ProQuotation> items = _ProQuotationService.GetFiltered(filter); ;
            IQueryable<ProQuotationOutputVM> result =
                _mapper.ProjectTo<ProQuotationOutputVM>(items);

            PaginatedResult<ProQuotationOutputVM> mappedResult = new()
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
        public async Task<IActionResult> Add([FromForm] ProQuotationInputVM input)
        {
            int modelId = await _ProQuotationService.Add(input);
            return Ok(modelId);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromForm] ProQuotationInputVM input)
        {
            int? modelId = await _ProQuotationService.Update(id, input);
            if (!modelId.HasValue) return NotFound();
            return Ok(modelId);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            ProQuotation model = _ProQuotationService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _ProQuotationService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
