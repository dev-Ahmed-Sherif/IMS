using AutoMapper;
using Business.Pro;
using Entities.Models.Pro;
using Entities.ViewModels;
using Entities.ViewModels.Pro.ProTenderDetailsViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IMS.Controllers.PR
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProTenderDetailsController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ProTenderDetailsService _proTenderDetailsService;
        public ProTenderDetailsController(
            IMapper mapper,
            ProTenderDetailsService proTenderDetailsService)
        {
            _mapper = mapper;
            _proTenderDetailsService = proTenderDetailsService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ProTenderDetails model = await _proTenderDetailsService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<ProTenderDetailsGeneralVM>(model));
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] ProTenderDetailsFilter filter)
        {
            PaginatedResultUnMapped<ProTenderDetails> unmappedResult =
                _proTenderDetailsService
                .GetFilteredPaginated(pagination, filter);
            PaginatedResult<ProTenderDetailsGeneralVM> mappedResult = new()
            {
                Items = await _mapper.ProjectTo<ProTenderDetailsGeneralVM>(unmappedResult.Items).ToListAsync(),
                Page = unmappedResult.Page,
                PageSize = unmappedResult.PageSize,
                TotalItems = unmappedResult.TotalItems,
            };
            return Ok(mappedResult);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProTenderDetailsGeneralVM input)
        {
            ProTenderDetails model = _mapper.Map<ProTenderDetails>(input);
            int rowsAffected = await _proTenderDetailsService.Add(model);
            if (rowsAffected <= 0) return StatusCode(500);
            return Ok(model.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProTenderDetailsGeneralVM input)
        {

            ProTenderDetails model = await _proTenderDetailsService.GetById(input.Id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _proTenderDetailsService.Update(model);
            if (rowsAffected <= 0) return StatusCode(500);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ProTenderDetails model = await _proTenderDetailsService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _proTenderDetailsService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(500);
            return Ok(model.Id);
        }
    }
}
