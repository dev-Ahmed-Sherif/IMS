using AutoMapper;
using Business.Pro;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderVendorReqSendTypeViewModels;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.ViewModels.Pro.ProTenderVendorReqViewModels;
using System.Linq;
using Entities.ExtensionMethods;

namespace IMS.Controllers.Pro
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProTenderVendorReqSendTypeController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ProTenderVendorReqSendTypeService _ProTenderVendorReqSendTypeService;
        public ProTenderVendorReqSendTypeController(
            IMapper mapper,
            ProTenderVendorReqSendTypeService ProTenderVendorReqSendTypeService)
        {
            _mapper = mapper;
            _ProTenderVendorReqSendTypeService = ProTenderVendorReqSendTypeService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProTenderVendorReqSendTypeGeneralVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            ProTenderVendorReqSendType model = await _ProTenderVendorReqSendTypeService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<ProTenderVendorReqSendTypeGeneralVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<ProTenderVendorReqSendTypeGeneralVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] ProTenderVendorReqSendTypeFilter filter)
        {
            IQueryable<ProTenderVendorReqSendType> items = _ProTenderVendorReqSendTypeService.GetFiltered(filter); ;
            IQueryable<ProTenderVendorReqSendTypeGeneralVM> result =
                _mapper.ProjectTo<ProTenderVendorReqSendTypeGeneralVM>(items);

            PaginatedResult<ProTenderVendorReqSendTypeGeneralVM> mappedResult = new()
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
        public async Task<IActionResult> Add(ProTenderVendorReqSendTypeGeneralVM input)
        {
            ProTenderVendorReqSendType model = _mapper.Map<ProTenderVendorReqSendType>(input);
            int rowsAffected = await _ProTenderVendorReqSendTypeService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(ProTenderVendorReqSendTypeGeneralVM input)
        {

            ProTenderVendorReqSendType model = await _ProTenderVendorReqSendTypeService.GetById(input.Id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _ProTenderVendorReqSendTypeService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            ProTenderVendorReqSendType model = await _ProTenderVendorReqSendTypeService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _ProTenderVendorReqSendTypeService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
