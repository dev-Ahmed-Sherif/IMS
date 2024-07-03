using AutoMapper;
using Business.Vl;
using Entities.Models.VL;
using Entities.ViewModels.VL.VlItineraryViewModels;
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
    public class VlItineraryController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly VlItineraryService _VlItineraryService;
        public VlItineraryController(
            IMapper mapper,
            VlItineraryService VlItineraryService)
        {
            _mapper = mapper;
            _VlItineraryService = VlItineraryService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VlItineraryGeneralVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            VlItinerary model = await _VlItineraryService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<VlItineraryGeneralVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<VlItineraryGeneralVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] VlItineraryFilter filter)
        {
            IQueryable<VlItinerary> items = _VlItineraryService.GetFiltered(filter); ;
            IQueryable<VlItineraryGeneralVM> result =
                _mapper.ProjectTo<VlItineraryGeneralVM>(items);

            PaginatedResult<VlItineraryGeneralVM> mappedResult = new()
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
        public async Task<IActionResult> Add(VlItineraryGeneralVM input)
        {
            VlItinerary model = _mapper.Map<VlItinerary>(input);
            int rowsAffected = await _VlItineraryService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, VlItineraryGeneralVM input)
        {

            VlItinerary model = await _VlItineraryService.GetById(id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _VlItineraryService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            VlItinerary model = await _VlItineraryService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _VlItineraryService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
