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
using Entities.ViewModels.Pro.ProVendorAttachments;
using System.Collections.Generic;
using Entities.Helpers;
using System;
using Entities.ViewModels.Pro.ProTenderVendorReqViewModels;

namespace IMS.Controllers.PR
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProVendorAttachmentController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ProVendorAttachmentService _ProVendorAttachmentService;
        public ProVendorAttachmentController(
            IMapper mapper,
            ProVendorAttachmentService ProVendorAttachmentService)
        {
            _mapper = mapper;
            _ProVendorAttachmentService = ProVendorAttachmentService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProVendorAttachmentOutputVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            ProVendorAttachment model = _ProVendorAttachmentService.GetById(id);
            if (model == null) return NotFound();
            return Ok(_mapper.Map<ProVendorAttachmentOutputVM>(model));
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<ProVendorAttachmentOutputVM>), StatusCodes.Status200OK)]
        public IActionResult Get([FromQuery] ProVendorAttachmentFilter filter)
        {
            IQueryable<ProVendorAttachment> items = _ProVendorAttachmentService.GetFiltered(filter);
            List<ProVendorAttachmentOutputVM> result = _mapper.ProjectTo<ProVendorAttachmentOutputVM>(items).ToList();
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add([FromForm] ProVendorAttachmentInputVM input)
        {
            int modelId = await _ProVendorAttachmentService.Add(input);
            return Ok(modelId);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromForm] ProVendorAttachmentInputVM input)
        {
            int? modelId = await _ProVendorAttachmentService.Update(id, input);
            if (!modelId.HasValue) return NotFound();
            return Ok(modelId);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            ProVendorAttachment model = _ProVendorAttachmentService.GetById(id);
            if (model == null) return NotFound();
            int rowsAffected = await _ProVendorAttachmentService.SoftDelete(model);
            if (rowsAffected <= 0) return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(model.Id);
        }
    }
}
