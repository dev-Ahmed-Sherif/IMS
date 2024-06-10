using AutoMapper;
using Business.Pro;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderSellerReqSendTypeViewModels;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IMS.Controllers.Pro
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProTenderSellerReqSendTypeController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ProTenderSellerReqSendTypeService _ProTenderSellerReqSendTypeService;
        public ProTenderSellerReqSendTypeController(
            IMapper mapper,
            ProTenderSellerReqSendTypeService ProTenderSellerReqSendTypeService)
        {
            _mapper = mapper;
            _ProTenderSellerReqSendTypeService = ProTenderSellerReqSendTypeService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProTenderSellerReqSendTypeGeneralVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            ProTenderSellerReqSendType model = await _ProTenderSellerReqSendTypeService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<ProTenderSellerReqSendTypeGeneralVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<ProTenderSellerReqSendTypeGeneralVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] ProTenderSellerReqSendTypeFilter filter)
        {
            PaginatedResultUnMapped<ProTenderSellerReqSendType> unmappedResult =
                _ProTenderSellerReqSendTypeService
                .GetFilteredPaginated(pagination, filter);
            PaginatedResult<ProTenderSellerReqSendTypeGeneralVM> mappedResult = new()
            {
                Items = await _mapper.ProjectTo<ProTenderSellerReqSendTypeGeneralVM>(unmappedResult.Items).ToListAsync(),
                Page = unmappedResult.Page,
                PageSize = unmappedResult.PageSize,
                TotalItems = unmappedResult.TotalItems,
            };
            return Ok(mappedResult);
        }
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add(ProTenderSellerReqSendTypeGeneralVM input)
        {
            ProTenderSellerReqSendType model = _mapper.Map<ProTenderSellerReqSendType>(input);
            int rowsAffected = await _ProTenderSellerReqSendTypeService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(ProTenderSellerReqSendTypeGeneralVM input)
        {

            ProTenderSellerReqSendType model = await _ProTenderSellerReqSendTypeService.GetById(input.Id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _ProTenderSellerReqSendTypeService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            ProTenderSellerReqSendType model = await _ProTenderSellerReqSendTypeService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _ProTenderSellerReqSendTypeService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
