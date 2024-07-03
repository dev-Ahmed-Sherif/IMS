using AutoMapper;
using Business.Vl;
using Entities.Models.VL;

using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Entities.ViewModels.VL.VlStaffStatus;
using Entities.ExtensionMethods;
using Microsoft.EntityFrameworkCore;


namespace IMS.Controllers.Vl
{
    [Route("api/[controller]")]
    [ApiController]
    public class VlStaffStatusController : ControllerBase
    {

        readonly IMapper _mapper;
        readonly VlStaffStatusService _VlStaffStatuseService;
        public VlStaffStatusController(
            IMapper mapper,
            VlStaffStatusService VlStaffStatuseService)
        {
            _mapper = mapper;
            _VlStaffStatuseService = VlStaffStatuseService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VlStaffStatusGeneralVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            VlStaffStatus model = await _VlStaffStatuseService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<VlStaffStatusGeneralVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<VlStaffStatusGeneralVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] VlStaffStatusFilter filter)
        {
            IQueryable<VlStaffStatus> items = _VlStaffStatuseService.GetFiltered(filter); ;
            IQueryable<VlStaffStatusGeneralVM> result =
                _mapper.ProjectTo<VlStaffStatusGeneralVM>(items);

            PaginatedResult<VlStaffStatusGeneralVM> mappedResult = new()
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
        public async Task<IActionResult> Add(VlStaffStatusGeneralVM input)
        {
            VlStaffStatus model = _mapper.Map<VlStaffStatus>(input);
            int rowsAffected = await _VlStaffStatuseService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, VlStaffStatusGeneralVM input)
        {

            VlStaffStatus model = await _VlStaffStatuseService.GetById(id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _VlStaffStatuseService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            VlStaffStatus model = await _VlStaffStatuseService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _VlStaffStatuseService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
