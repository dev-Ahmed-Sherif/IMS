using AutoMapper;
using Business.Pro;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProPurchaseOrderDetailsViewModels;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IMS.Controllers.Pro
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProPurchaseOrderDetailsController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ProPurchaseOrderDetailsService _ProPurchaseOrderDetailsService;
        public ProPurchaseOrderDetailsController(
            IMapper mapper,
            ProPurchaseOrderDetailsService ProPurchaseOrderDetailsService)
        {
            _mapper = mapper;
            _ProPurchaseOrderDetailsService = ProPurchaseOrderDetailsService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProPurchaseOrderDetailsGeneralVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            ProPurchaseOrderDetails model = await _ProPurchaseOrderDetailsService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<ProPurchaseOrderDetailsGeneralVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<ProPurchaseOrderDetailsGeneralVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] ProPurchaseOrderDetailsFilter filter)
        {
            PaginatedResultUnMapped<ProPurchaseOrderDetails> unmappedResult =
                _ProPurchaseOrderDetailsService
                .GetFilteredPaginated(pagination, filter);
            PaginatedResult<ProPurchaseOrderDetailsGeneralVM> mappedResult = new()
            {
                Items = await _mapper.ProjectTo<ProPurchaseOrderDetailsGeneralVM>(unmappedResult.Items).ToListAsync(),
                Page = unmappedResult.Page,
                PageSize = unmappedResult.PageSize,
                TotalItems = unmappedResult.TotalItems,
            };
            return Ok(mappedResult);
        }
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add(ProPurchaseOrderDetailsGeneralVM input)
        {
            ProPurchaseOrderDetails model = _mapper.Map<ProPurchaseOrderDetails>(input);
            int rowsAffected = await _ProPurchaseOrderDetailsService.Add(model);
            if (rowsAffected <= 0) return StatusCode(500);
            return Ok(model.Id);
        }
        [HttpPut]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(ProPurchaseOrderDetailsGeneralVM input)
        {

            ProPurchaseOrderDetails model = await _ProPurchaseOrderDetailsService.GetById(input.Id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _ProPurchaseOrderDetailsService.Update(model);
            if (rowsAffected <= 0) return StatusCode(500);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            ProPurchaseOrderDetails model = await _ProPurchaseOrderDetailsService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _ProPurchaseOrderDetailsService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(500);
            return Ok(model.Id);
        }
    }
}
