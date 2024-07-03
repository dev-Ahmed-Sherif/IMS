using AutoMapper;
using Business.Vl;
using Entities.Models.VL;
using Entities.ViewModels.VL.VlVehicleStatusViewModels;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Entities.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace IMS.Controllers.Vl
{
    [Route("api/[controller]")]
    [ApiController]
    public class VlVehicleStatusController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly VlVehicleStatusService _VlVehicleStatusService;
        public VlVehicleStatusController(
            IMapper mapper,
            VlVehicleStatusService VlVehicleStatusService)
        {
            _mapper = mapper;
            _VlVehicleStatusService = VlVehicleStatusService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VlVehicleStatusGeneralVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            VlVehicleStatus model = _VlVehicleStatusService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<VlVehicleStatusGeneralVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<VlVehicleStatusGeneralVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] VlVehicleStatusFilter filter)
        {
            IQueryable<VlVehicleStatus> items = _VlVehicleStatusService.GetFiltered(filter); ;
            IQueryable<VlVehicleStatusGeneralVM> result =
                _mapper.ProjectTo<VlVehicleStatusGeneralVM>(items);

            PaginatedResult<VlVehicleStatusGeneralVM> mappedResult = new()
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
        public async Task<IActionResult> Add(VlVehicleStatusGeneralVM input)
        {
            VlVehicleStatus model = _mapper.Map<VlVehicleStatus>(input);
            int rowsAffected = await _VlVehicleStatusService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, VlVehicleStatusGeneralVM input)
        {

            VlVehicleStatus model = _VlVehicleStatusService.GetById(id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _VlVehicleStatusService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            VlVehicleStatus model = _VlVehicleStatusService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _VlVehicleStatusService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
