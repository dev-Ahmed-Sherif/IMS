using AutoMapper;
using Business.Pro;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProPurchaseOrderDetailsViewModels;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Entities.ExtensionMethods;
using Entities.ViewModels.Pro.ProTenderVendorReqSendTypeViewModels;

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
        [ProducesResponseType(typeof(ProPurchaseOrderDetailsOutputVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            ProPurchaseOrderDetails model = _ProPurchaseOrderDetailsService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<ProPurchaseOrderDetailsOutputVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<ProPurchaseOrderDetailsOutputVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] ProPurchaseOrderDetailsFilter filter)
        {
            IQueryable<ProPurchaseOrderDetails> items = _ProPurchaseOrderDetailsService.GetFiltered(filter);
            IQueryable<ProPurchaseOrderDetailsOutputVM> result =
                _mapper.ProjectTo<ProPurchaseOrderDetailsOutputVM>(items);
            string query = result.ToQueryString();
            PaginatedResult<ProPurchaseOrderDetailsOutputVM> mappedResult = new()
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
        public async Task<IActionResult> Add(ProPurchaseOrderDetailsInputVM input)
        {
            ProPurchaseOrderDetails model = _mapper.Map<ProPurchaseOrderDetails>(input);
            int rowsAffected = await _ProPurchaseOrderDetailsService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, ProPurchaseOrderDetailsInputVM input)
        {

            ProPurchaseOrderDetails model = _ProPurchaseOrderDetailsService.GetById(id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _ProPurchaseOrderDetailsService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            ProPurchaseOrderDetails model =  _ProPurchaseOrderDetailsService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _ProPurchaseOrderDetailsService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
