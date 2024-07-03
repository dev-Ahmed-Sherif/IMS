using AutoMapper;
using Business.Pro;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProPurchaseOrderViewModels;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Entities.ExtensionMethods;
using Entities.ViewModels.Pro.ProTenderVendorReqSendTypeViewModels;
using AutoMapper.QueryableExtensions;

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
        public IActionResult GetById(int id)
        {
            ProPurchaseOrder model = _ProPurchaseOrderService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<ProPurchaseOrderOutputVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<ProPurchaseOrderOutputVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] ProPurchaseOrderFilter filter)
        {
            IQueryable<ProPurchaseOrder> items = _ProPurchaseOrderService.GetFiltered(filter);
            var result = items.ToPaginatedResultUnMapped(pagination).Select(_mapper.Map<ProPurchaseOrderOutputVM>).ToList();

            PaginatedResult<ProPurchaseOrderOutputVM> mappedResult = new()
            {
                Items = result,
                Page = pagination.Index,
                PageSize = pagination.Size,
                TotalItems = await items.CountAsync(),
            };
            return Ok(mappedResult);
        }
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add([FromForm] ProPurchaseOrderInputVM input)
        {
            ProPurchaseOrder model = _mapper.Map<ProPurchaseOrder>(input);
            int rowsAffected = await _ProPurchaseOrderService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromForm] ProPurchaseOrderInputVM input)
        {

            ProPurchaseOrder model = _ProPurchaseOrderService.GetById(id);
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
            ProPurchaseOrder model = _ProPurchaseOrderService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _ProPurchaseOrderService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
