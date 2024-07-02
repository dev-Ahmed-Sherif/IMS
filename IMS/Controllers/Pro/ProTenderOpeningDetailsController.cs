using AutoMapper;
using Business.Pro;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderOpeningDetailsViewModels;
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
    public class ProTenderOpeningDetailsController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ProTenderOpeningDetailsService _ProTenderOpeningDetailsService;
        public ProTenderOpeningDetailsController(
            IMapper mapper,
            ProTenderOpeningDetailsService ProTenderOpeningDetailsService)
        {
            _mapper = mapper;
            _ProTenderOpeningDetailsService = ProTenderOpeningDetailsService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProTenderOpeningDetailsOutputVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            ProTenderOpeningDetails model = await _ProTenderOpeningDetailsService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<ProTenderOpeningDetailsOutputVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<ProTenderOpeningDetailsOutputVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] ProTenderOpeningDetailsFilter filter)
        {
            IQueryable<ProTenderOpeningDetails> items = _ProTenderOpeningDetailsService.GetFiltered(filter); ;
            IQueryable<ProTenderOpeningDetailsOutputVM> result =
                _mapper.ProjectTo<ProTenderOpeningDetailsOutputVM>(items);

            PaginatedResult<ProTenderOpeningDetailsOutputVM> mappedResult = new()
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
        public async Task<IActionResult> Add(ProTenderOpeningDetailsInputVM input)
        {
            ProTenderOpeningDetails model = _mapper.Map<ProTenderOpeningDetails>(input);
            int rowsAffected = await _ProTenderOpeningDetailsService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, ProTenderOpeningDetailsInputVM input)
        {

            ProTenderOpeningDetails model = await _ProTenderOpeningDetailsService.GetById(id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _ProTenderOpeningDetailsService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            ProTenderOpeningDetails model = await _ProTenderOpeningDetailsService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _ProTenderOpeningDetailsService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
