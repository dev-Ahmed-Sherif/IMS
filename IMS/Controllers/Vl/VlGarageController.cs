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
using Entities.ViewModels.VL.VlGarageViewModels;

namespace IMS.Controllers.Vl
{
    [Route("api/[controller]")]
    [ApiController]
    public class VlGarageController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly VlGarageService _VlGarageService;
        public VlGarageController(
            IMapper mapper,
            VlGarageService VlGarageService)
        {
            _mapper = mapper;
            _VlGarageService = VlGarageService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VlGarageGeneralVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            VlGarage model = await _VlGarageService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<VlGarageGeneralVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<VlGarageGeneralVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] VlGarageFilter filter)
        {
            IQueryable<VlGarage> items = _VlGarageService.GetFiltered(filter); ;
            IQueryable<VlGarageGeneralVM> result =
                _mapper.ProjectTo<VlGarageGeneralVM>(items);

            PaginatedResult<VlGarageGeneralVM> mappedResult = new()
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
        public async Task<IActionResult> Add(VlGarageGeneralVM input)
        {
            VlGarage model = _mapper.Map<VlGarage>(input);
            int rowsAffected = await _VlGarageService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, VlGarageGeneralVM input)
        {

            VlGarage model = await _VlGarageService.GetById(id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _VlGarageService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            VlGarage model = await _VlGarageService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _VlGarageService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
