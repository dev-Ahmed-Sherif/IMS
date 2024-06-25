using AutoMapper;
using Business.Pro;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderVendorReqViewModels;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.ViewModels.Pro.ProTenderOpeningStatusViewModels;
using Entities.ViewModels.Pro.ProTenderVendorReqSendTypeViewModels;
using System.Linq;
using Entities.ExtensionMethods;

namespace IMS.Controllers.Pro
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProTenderOpeningStatusController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ProTenderOpeningStatusService _proTenderOpeningStatusService;
        public ProTenderOpeningStatusController(
            IMapper mapper,
            ProTenderOpeningStatusService proTenderOpeningStatusService)
        {
            _mapper = mapper;
            _proTenderOpeningStatusService = proTenderOpeningStatusService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProTenderOpeningStatusGeneralVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            ProTenderOpeningStatus model = await _proTenderOpeningStatusService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<ProTenderOpeningStatusGeneralVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<ProTenderOpeningStatusGeneralVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] ProTenderOpeningStatusFilter filter)
        {
            IQueryable<ProTenderOpeningStatus> items = _proTenderOpeningStatusService.GetFiltered(filter); ;
            IQueryable<ProTenderOpeningStatusGeneralVM> result =
                _mapper.ProjectTo<ProTenderOpeningStatusGeneralVM>(items);

            PaginatedResult<ProTenderOpeningStatusGeneralVM> mappedResult = new()
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
        public async Task<IActionResult> Add(ProTenderOpeningStatusGeneralVM input)
        {
            ProTenderOpeningStatus model = _mapper.Map<ProTenderOpeningStatus>(input);
            int rowsAffected = await _proTenderOpeningStatusService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(ProTenderOpeningStatusGeneralVM input)
        {

            ProTenderOpeningStatus model = await _proTenderOpeningStatusService.GetById(input.Id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _proTenderOpeningStatusService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            ProTenderOpeningStatus model = await _proTenderOpeningStatusService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _proTenderOpeningStatusService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
