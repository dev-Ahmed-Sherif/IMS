using AutoMapper;
using Business.Pro;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderOpeningViewModels;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.ViewModels.Pro.ProTenderVendorReqSendTypeViewModels;
using System.Linq;
using Entities.ExtensionMethods;

namespace IMS.Controllers.Pro
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProTenderOpeningController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ProTenderOpeningService _ProTenderOpeningService;
        public ProTenderOpeningController(
            IMapper mapper,
            ProTenderOpeningService ProTenderOpeningService)
        {
            _mapper = mapper;
            _ProTenderOpeningService = ProTenderOpeningService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProTenderOpeningOutputVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            ProTenderOpening model = await _ProTenderOpeningService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<ProTenderOpeningOutputVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<ProTenderOpeningOutputVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] ProTenderOpeningFilter filter)
        {
            IQueryable<ProTenderOpening> items = _ProTenderOpeningService.GetFiltered(filter); ;
            IQueryable<ProTenderOpeningOutputVM> result =
                _mapper.ProjectTo<ProTenderOpeningOutputVM>(items);

            PaginatedResult<ProTenderOpeningOutputVM> mappedResult = new()
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
        public async Task<IActionResult> Add(ProTenderOpeningInputVM input)
        {
            ProTenderOpening model = _mapper.Map<ProTenderOpening>(input);
            int rowsAffected = await _ProTenderOpeningService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, ProTenderOpeningInputVM input)
        {

            ProTenderOpening model = await _ProTenderOpeningService.GetById(id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _ProTenderOpeningService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            ProTenderOpening model = await _ProTenderOpeningService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _ProTenderOpeningService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
