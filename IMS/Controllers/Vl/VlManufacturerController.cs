using AutoMapper;
using Business.Pro;
using Entities.Models.Pro;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Business.Vl;
using Entities.Models.VL;
using Entities.ExtensionMethods;
using Microsoft.EntityFrameworkCore;
using Entities.ViewModels.VL.VlModelViewModels;
using Entities.ViewModels.VL.VlManufacturerViewModels;
using Entities.ViewModels.VL.VlManufacturer;

namespace IMS.Controllers.Vl
{
    [Route("api/[controller]")]
    [ApiController]
    public class VlManufacturerController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly VlManufacturerService _VlManufacturerService;
        public VlManufacturerController(
            IMapper mapper,
            VlManufacturerService VlManufacturerService)
        {
            _mapper = mapper;
            _VlManufacturerService = VlManufacturerService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VlManufacturerGeneralVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            VlManufacturer model = _VlManufacturerService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<VlModelGeneralVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<VlManufacturerGeneralVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] VlManufacturerFilter filter)
        {
            IQueryable<VlManufacturer> items = _VlManufacturerService.GetFiltered(filter); ;
            IQueryable<VlManufacturerGeneralVM> result =
                _mapper.ProjectTo<VlManufacturerGeneralVM>(items);

            PaginatedResult<VlManufacturerGeneralVM> mappedResult = new()
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
        public async Task<IActionResult> Add(VlManufacturerGeneralVM input)
        {
            VlManufacturer model = _mapper.Map<VlManufacturer>(input);
            int rowsAffected = await _VlManufacturerService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, VlManufacturerGeneralVM input)
        {

            VlManufacturer model = _VlManufacturerService.GetById(id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _VlManufacturerService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            VlManufacturer model = _VlManufacturerService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _VlManufacturerService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
