using AutoMapper;
using Business.Pro;
using Entities.Models.Pro;
using Entities.ViewModels.Pro.ProTenderCommitteeRoleViewModels;
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
    public class ProTenderCommitteeRoleController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ProTenderCommitteeRoleService _proTenderCommitteeRoleService;
        public ProTenderCommitteeRoleController(
            IMapper mapper,
            ProTenderCommitteeRoleService ProTenderCommitteeRoleService)
        {
            _mapper = mapper;
            _proTenderCommitteeRoleService = ProTenderCommitteeRoleService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProTenderCommitteeRoleGeneralVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            ProTenderCommitteeRole model = _proTenderCommitteeRoleService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<ProTenderCommitteeRoleGeneralVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<ProTenderCommitteeRoleGeneralVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationInputViewModel pagination, [FromQuery] ProTenderCommitteeRoleFilter filter)
        {
            IQueryable<ProTenderCommitteeRole> items = _proTenderCommitteeRoleService.GetFiltered(filter); ;
            IQueryable<ProTenderCommitteeRoleGeneralVM> result =
                _mapper.ProjectTo<ProTenderCommitteeRoleGeneralVM>(items);

            PaginatedResult<ProTenderCommitteeRoleGeneralVM> mappedResult = new()
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
        public async Task<IActionResult> Add(ProTenderCommitteeRoleGeneralVM input)
        {
            ProTenderCommitteeRole model = _mapper.Map<ProTenderCommitteeRole>(input);
            int rowsAffected = await _proTenderCommitteeRoleService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, ProTenderCommitteeRoleGeneralVM input)
        {

            ProTenderCommitteeRole model = _proTenderCommitteeRoleService.GetById(id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _proTenderCommitteeRoleService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            ProTenderCommitteeRole model = _proTenderCommitteeRoleService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _proTenderCommitteeRoleService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
