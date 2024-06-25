using AutoMapper;
using Business.Pro;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProQuotationReceiveTypeViewModels;
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
    public class ProQuotationReceiveTypeController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ProQuotationReceiveTypeService _ProQuotationReceiveTypeService;
        public ProQuotationReceiveTypeController(
            IMapper mapper,
            ProQuotationReceiveTypeService ProQuotationReceiveTypeService)
        {
            _mapper = mapper;
            _ProQuotationReceiveTypeService = ProQuotationReceiveTypeService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProQuotationReceiveTypeGeneralVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            ProQuotationReceiveType model = await _ProQuotationReceiveTypeService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<ProQuotationReceiveTypeGeneralVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<ProQuotationReceiveTypeGeneralVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] ProQuotationReceiveTypeFilter filter)
        {
            IQueryable<ProQuotationReceiveType> items = _ProQuotationReceiveTypeService.GetFiltered(filter); ;
            IQueryable<ProQuotationReceiveTypeGeneralVM> result =
                _mapper.ProjectTo<ProQuotationReceiveTypeGeneralVM>(items);

            PaginatedResult<ProQuotationReceiveTypeGeneralVM> mappedResult = new()
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
        public async Task<IActionResult> Add(ProQuotationReceiveTypeGeneralVM input)
        {
            ProQuotationReceiveType model = _mapper.Map<ProQuotationReceiveType>(input);
            int rowsAffected = await _ProQuotationReceiveTypeService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(ProQuotationReceiveTypeGeneralVM input)
        {
            ProQuotationReceiveType model = await _ProQuotationReceiveTypeService.GetById(input.Id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _ProQuotationReceiveTypeService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            ProQuotationReceiveType model = await _ProQuotationReceiveTypeService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _ProQuotationReceiveTypeService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
