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

namespace IMS.Controllers.Vl
{
    [Route("api/[controller]")]
    [ApiController]
    public class VlManufacturerController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly VlModelService _VlModelService;
        public VlManufacturerController(
            IMapper mapper,
            VlModelService VlModelService)
        {
            _mapper = mapper;
            _VlModelService = VlModelService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VlModelGeneralVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            VlModel model = await _VlModelService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<VlModelGeneralVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<VlModelGeneralVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] VlModelFilter filter)
        {
            IQueryable<VlModel> items = _VlModelService.GetFiltered(filter); ;
            IQueryable<VlModelGeneralVM> result =
                _mapper.ProjectTo<VlModelGeneralVM>(items);

            PaginatedResult<VlModelGeneralVM> mappedResult = new()
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
        public async Task<IActionResult> Add(VlModelGeneralVM input)
        {
            VlModel model = _mapper.Map<VlModel>(input);
            int rowsAffected = await _VlModelService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(VlModelGeneralVM input)
        {

            VlModel model = await _VlModelService.GetById(input.Id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _VlModelService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            VlModel model = await _VlModelService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _VlModelService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
