using AutoMapper;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Business.Vl;
using Entities.ViewModels.VL.VlStaff;
using Entities.Models.VL;
using Entities.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace IMS.Controllers.Vl
{
    [Route("api/[controller]")]
    [ApiController]
    public class VlStaffController : ControllerBase
    {

        readonly IMapper _mapper;
        readonly VlStaffService _VlStaffService;
        public VlStaffController(
            IMapper mapper,
            VlStaffService VlStaffService)
        {
            _mapper = mapper;
            _VlStaffService = VlStaffService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VlStaffOutputVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            VlStaff model = await _VlStaffService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<VlStaffOutputVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<VlStaffOutputVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] VlStaffFilter filter)
        {
            IQueryable<VlStaff> items = _VlStaffService.GetFiltered(filter); ;
            IQueryable<VlStaffOutputVM> result =
                _mapper.ProjectTo<VlStaffOutputVM>(items);

            PaginatedResult<VlStaffOutputVM> mappedResult = new()
            {
                Items =await result.ToPaginatedResultUnMapped(pagination).ToListAsync(),
                Page = pagination.Index,
                PageSize = pagination.Size,
                TotalItems =await result.CountAsync(),
            };
            return Ok(mappedResult);
        }
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add(VlStaffInputVM input)
        {
            VlStaff model = _mapper.Map<VlStaff>(input);
            int rowsAffected = await _VlStaffService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, VlStaffInputVM input)
        {

            VlStaff model = await _VlStaffService.GetById(id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _VlStaffService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            VlStaff model = await _VlStaffService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _VlStaffService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
