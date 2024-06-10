using AutoMapper;
using Business.Pro;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderSelectionViewModels;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IMS.Controllers.Pro
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProTenderSelectionController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ProTenderSelectionService _ProTenderSelectionService;
        public ProTenderSelectionController(
            IMapper mapper,
            ProTenderSelectionService ProTenderSelectionService)
        {
            _mapper = mapper;
            _ProTenderSelectionService = ProTenderSelectionService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProTenderSelectionOutputVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            ProTenderSelection model = await _ProTenderSelectionService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<ProTenderSelectionOutputVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<ProTenderSelectionOutputVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] ProTenderSelectionFilter filter)
        {
            PaginatedResultUnMapped<ProTenderSelection> unmappedResult =
                _ProTenderSelectionService
                .GetFilteredPaginated(pagination, filter);
            PaginatedResult<ProTenderSelectionOutputVM> mappedResult = new()
            {
                Items = await _mapper.ProjectTo<ProTenderSelectionOutputVM>(unmappedResult.Items).ToListAsync(),
                Page = unmappedResult.Page,
                PageSize = unmappedResult.PageSize,
                TotalItems = unmappedResult.TotalItems,
            };
            return Ok(mappedResult);
        }
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add(ProTenderSelectionInputVM input)
        {
            ProTenderSelection model = _mapper.Map<ProTenderSelection>(input);
            int rowsAffected = await _ProTenderSelectionService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(ProTenderSelectionInputVM input)
        {

            ProTenderSelection model = await _ProTenderSelectionService.GetById(input.Id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _ProTenderSelectionService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            ProTenderSelection model = await _ProTenderSelectionService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _ProTenderSelectionService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
