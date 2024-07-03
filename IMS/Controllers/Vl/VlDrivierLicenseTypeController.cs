using AutoMapper;
using Business.Vl;
using Entities.Models.VL;
using Entities.ViewModels.VL.VlDrivierLicenseTypeViewModels;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Entities.ExtensionMethods;
using System.Data.Entity;

namespace IMS.Controllers.Vl
{
    [Route("api/[controller]")]
    [ApiController]
    public class VlDrivierLicenseTypeController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly VlDrivierLicenseTypeService _VlDrivierLicenseTypeService;
        public VlDrivierLicenseTypeController(
            IMapper mapper,
            VlDrivierLicenseTypeService VlDrivierLicenseTypeService)
        {
            _mapper = mapper;
            _VlDrivierLicenseTypeService = VlDrivierLicenseTypeService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VlDrivierLicenseTypeGeneralVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            VlDrivierLicenseType model = await _VlDrivierLicenseTypeService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<VlDrivierLicenseTypeGeneralVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<VlDrivierLicenseTypeGeneralVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] VlDrivierLicenseTypeFilter filter)
        {
            IQueryable<VlDrivierLicenseType> items = _VlDrivierLicenseTypeService.GetFiltered(filter); ;
            IQueryable<VlDrivierLicenseTypeGeneralVM> result =
                _mapper.ProjectTo<VlDrivierLicenseTypeGeneralVM>(items);

            PaginatedResult<VlDrivierLicenseTypeGeneralVM> mappedResult = new()
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
        public async Task<IActionResult> Add(VlDrivierLicenseTypeGeneralVM input)
        {
            VlDrivierLicenseType model = _mapper.Map<VlDrivierLicenseType>(input);
            int rowsAffected = await _VlDrivierLicenseTypeService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, VlDrivierLicenseTypeGeneralVM input)
        {

            VlDrivierLicenseType model = await _VlDrivierLicenseTypeService.GetById(id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _VlDrivierLicenseTypeService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            VlDrivierLicenseType model = await _VlDrivierLicenseTypeService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _VlDrivierLicenseTypeService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
