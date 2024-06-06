using AutoMapper;
using Business.Pro;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderSellerReqViewModels;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IMS.Controllers.Pro
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProTenderSellerReqController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ProTenderSellerReqService _proTenderSellerReqService;
        public ProTenderSellerReqController(
            IMapper mapper,
            ProTenderSellerReqService proTenderSellerReqService)
        {
            _mapper = mapper;
            _proTenderSellerReqService = proTenderSellerReqService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProTenderSellerReqGeneralVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            ProTenderSellerReq model = await _proTenderSellerReqService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<ProTenderSellerReqGeneralVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<ProTenderSellerReqGeneralVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] ProTenderSellerReqFilter filter)
        {
            PaginatedResultUnMapped<ProTenderSellerReq> unmappedResult =
                _proTenderSellerReqService
                .GetFilteredPaginated(pagination, filter);
            PaginatedResult<ProTenderSellerReqGeneralVM> mappedResult = new()
            {
                Items = await _mapper.ProjectTo<ProTenderSellerReqGeneralVM>(unmappedResult.Items).ToListAsync(),
                Page = unmappedResult.Page,
                PageSize = unmappedResult.PageSize,
                TotalItems = unmappedResult.TotalItems,
            };
            return Ok(mappedResult);
        }
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add(ProTenderSellerReqGeneralVM input)
        {
            ProTenderSellerReq model = _mapper.Map<ProTenderSellerReq>(input);
            int rowsAffected = await _proTenderSellerReqService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(ProTenderSellerReqGeneralVM input)
        {

            ProTenderSellerReq model = await _proTenderSellerReqService.GetById(input.Id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _proTenderSellerReqService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            ProTenderSellerReq model = await _proTenderSellerReqService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _proTenderSellerReqService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
