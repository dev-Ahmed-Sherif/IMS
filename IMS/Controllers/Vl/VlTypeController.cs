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
using Entities.ViewModels.VL.VlTypeModels;

namespace IMS.Controllers.Vl
{
    [Route("api/[controller]")]
    [ApiController]
    public class VlTypeController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly VlTypeService _VlTypeService;
        public VlTypeController(
            IMapper mapper,
            VlTypeService VlTypeService)
        {
            _mapper = mapper;
            _VlTypeService = VlTypeService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VlTypeGeneralVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            VlType model =  _VlTypeService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<VlTypeGeneralVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<VlTypeGeneralVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] VlTypeFilter filter)
        {
            IQueryable<VlType> items = _VlTypeService.GetFiltered(filter); ;
            IQueryable<VlTypeGeneralVM> result =
                _mapper.ProjectTo<VlTypeGeneralVM>(items);

            PaginatedResult<VlTypeGeneralVM> mappedResult = new()
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
        public async Task<IActionResult> Add(VlTypeGeneralVM input)
        {
            VlType model = _mapper.Map<VlType>(input);
            int rowsAffected = await _VlTypeService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, VlTypeGeneralVM input)
        {

            VlType model = _VlTypeService.GetById(id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _VlTypeService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            VlType model = _VlTypeService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _VlTypeService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
