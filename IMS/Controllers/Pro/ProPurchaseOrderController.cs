using AutoMapper;
using Business.Pro;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProPurchaseOrderViewModels;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IMS.Controllers.Pro
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProPurchaseOrderController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ProPurchaseOrderService _ProPurchaseOrderService;
        public ProPurchaseOrderController(
            IMapper mapper,
            ProPurchaseOrderService ProPurchaseOrderService)
        {
            _mapper = mapper;
            _ProPurchaseOrderService = ProPurchaseOrderService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProPurchaseOrderOutputVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            ProPurchaseOrder model = await _ProPurchaseOrderService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<ProPurchaseOrderOutputVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<ProPurchaseOrderOutputVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] ProPurchaseOrderFilter filter)
        {
            PaginatedResultUnMapped<ProPurchaseOrder> unmappedResult =
                _ProPurchaseOrderService
                .GetFilteredPaginated(pagination, filter);
            PaginatedResult<ProPurchaseOrderOutputVM> mappedResult = new()
            {
                Items = await _mapper.ProjectTo<ProPurchaseOrderOutputVM>(unmappedResult.Items).ToListAsync(),
                Page = unmappedResult.Page,
                PageSize = unmappedResult.PageSize,
                TotalItems = unmappedResult.TotalItems,
            };
            return Ok(mappedResult);
        }
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add(ProPurchaseOrderInputVM input)
        {
            ProPurchaseOrder model = _mapper.Map<ProPurchaseOrder>(input);
            int rowsAffected = await _ProPurchaseOrderService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(ProPurchaseOrderInputVM input)
        {

            ProPurchaseOrder model = await _ProPurchaseOrderService.GetById(input.Id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _ProPurchaseOrderService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            ProPurchaseOrder model = await _ProPurchaseOrderService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _ProPurchaseOrderService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
