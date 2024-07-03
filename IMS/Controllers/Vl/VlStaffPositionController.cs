using AutoMapper;
using Business.Vl;
using Entities.Models.VL;

using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Entities.ViewModels.VL.VlStaffPosition;
using Entities.ExtensionMethods;
using System.Data.Entity;

namespace IMS.Controllers.Vl
{
    [Route("api/[controller]")]
    [ApiController]
    public class VlStaffPositionController : ControllerBase
    {

        readonly IMapper _mapper;
        readonly VlStaffPositionService _VlStaffPositionService;
        public VlStaffPositionController(
            IMapper mapper,
            VlStaffPositionService VlStaffPositionService)
        {
            _mapper = mapper;
            _VlStaffPositionService = VlStaffPositionService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VlStaffPositionGeneralVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            VlStaffPosition model = _VlStaffPositionService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<VlStaffPositionGeneralVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<VlStaffPositionGeneralVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] VlStaffPositionFilter filter)
        {
            IQueryable<VlStaffPosition> items = _VlStaffPositionService.GetFiltered(filter); ;
            IQueryable<VlStaffPositionGeneralVM> result =
                _mapper.ProjectTo<VlStaffPositionGeneralVM>(items);

            PaginatedResult<VlStaffPositionGeneralVM> mappedResult = new()
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
        public async Task<IActionResult> Add(VlStaffPositionGeneralVM input)
        {
            VlStaffPosition model = _mapper.Map<VlStaffPosition>(input);
            int rowsAffected = await _VlStaffPositionService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, VlStaffPositionGeneralVM input)
        {

            VlStaffPosition model = _VlStaffPositionService.GetById(id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _VlStaffPositionService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            VlStaffPosition model = _VlStaffPositionService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _VlStaffPositionService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
