using AutoMapper;
using Business.Pro;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderVendorReqViewModels;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Entities.ExtensionMethods;

namespace IMS.Controllers.Pro
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProTenderVendorReqController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ProTenderVendorReqService _proTenderVendorReqService;
        public ProTenderVendorReqController(
            IMapper mapper,
            ProTenderVendorReqService proTenderVendorReqService)
        {
            _mapper = mapper;
            _proTenderVendorReqService = proTenderVendorReqService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProTenderVendorReqOutputVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            ProTenderVendorReq model = await _proTenderVendorReqService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<ProTenderVendorReqOutputVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<ProTenderVendorReqOutputVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] ProTenderVendorReqFilter filter)
        {
            IQueryable<ProTenderVendorReq> items = _proTenderVendorReqService.GetFiltered(filter);
            IQueryable<ProTenderVendorReq> result = items.ToPaginatedResultUnMapped(pagination);
            PaginatedResult<ProTenderVendorReqOutputVM> mappedResult = new()
            {
                Items = await _mapper.ProjectTo<ProTenderVendorReqOutputVM>(result).ToListAsync(),
                Page = pagination.Index,
                PageSize = pagination.Size,
                TotalItems = await items.CountAsync(),
            };
            return Ok(mappedResult);
        }
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add(ProTenderVendorReqInputVM input)
        {
            ProTenderVendorReq model = _mapper.Map<ProTenderVendorReq>(input);
            int rowsAffected = await _proTenderVendorReqService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, ProTenderVendorReqInputVM input)
        {

            ProTenderVendorReq model = await _proTenderVendorReqService.GetById(id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _proTenderVendorReqService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            ProTenderVendorReq model = await _proTenderVendorReqService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _proTenderVendorReqService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
