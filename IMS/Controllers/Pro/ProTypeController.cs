using AutoMapper;
using Business.Pro;
using Entities.ExtensionMethods;
using Entities.Models.Pro;
using Entities.ViewModels;
using Entities.ViewModels.Pro.ProTenderVendorReqSendTypeViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

using System.Collections.Generic;
using Entities.Helpers;
using System;
using Entities.ViewModels.Pro.ProTenderVendorReqViewModels;
using Entities.ViewModels.Pro.ProType;

namespace IMS.Controllers.PR
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProTypeController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ProTypeService _ProTypeService;
        public ProTypeController(
            IMapper mapper,
            ProTypeService ProTypeService)
        {
            _mapper = mapper;
            _ProTypeService = ProTypeService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProTypeOutputVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            ProType model = _ProTypeService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<ProTypeOutputVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<ProTypeOutputVM>), StatusCodes.Status200OK)]
        public IActionResult Get([FromQuery] ProTypeFilter filter)
        {
            IEnumerable<ProType> items = _ProTypeService.GetAll();
            List<ProTypeOutputVM> result = items.Select(_mapper.Map<ProTypeOutputVM>).ToList();
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add([FromForm] ProTypeInputVM input)
        {
            ProType model = _mapper.Map<ProType>(input);

            int rowsAffected = await _ProTypeService.Add(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromForm] ProTypeInputVM input)
        {

            ProType model = _ProTypeService.GetById(id);
            if (model == null) return NotFound();
            _mapper.Map(input, model);
            int rowsAffected = await _ProTypeService.Update(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            ProType model = _ProTypeService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _ProTypeService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
