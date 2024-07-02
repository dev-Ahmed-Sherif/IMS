using AutoMapper;
using Business.Pro;
using Entities.Models.Pro;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Entities.ExtensionMethods;
using Entities.ViewModels.Pro;
using System.Collections.Generic;

namespace IMS.Controllers.Pro
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProVendorsTypesController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ProVendorsTypesService _ProVendorsTypesService;
        public ProVendorsTypesController(
            IMapper mapper,
            ProVendorsTypesService ProVendorsTypesService)
        {
            _mapper = mapper;
            _ProVendorsTypesService = ProVendorsTypesService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProVendorsTypesGeneralVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            ProVendorsTypes model = await _ProVendorsTypesService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<ProVendorsTypesGeneralVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResult<ProVendorsTypesGeneralVM>), StatusCodes.Status200OK)]
        public IActionResult Get([FromQuery] PaginationInputViewModel pagination)
        {
            List<ProVendorsTypes> items = _ProVendorsTypesService.GetAll().ToList();
            return Ok(items);
        }
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add(ProVendorsTypesGeneralVM input)
        {
            ProVendorsTypes model = _mapper.Map<ProVendorsTypes>(input);
            int rowsAffected = await _ProVendorsTypesService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        //[HttpPost(nameof(BulkAdd))]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> BulkAdd(ProVendorsTypesBulkInputVM input)
        //{
        //    List<ProVendorsTypes> models = _mapper.Map<List<ProVendorsTypes>>(input);
        //    int rowsAffected = await _ProVendorsTypesService.AddRange(models);
        //    if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
        //    return Ok();
        //}
        [HttpPut]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(ProVendorsTypesVM input)
        {

            ProVendorsTypes model = await _ProVendorsTypesService.GetById(input.Id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _ProVendorsTypesService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            ProVendorsTypes model = await _ProVendorsTypesService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _ProVendorsTypesService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
