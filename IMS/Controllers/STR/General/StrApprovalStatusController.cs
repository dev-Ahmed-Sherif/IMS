using Business.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.STR.General
{

    [Route("api/[controller]")]
    [ApiController]
    public class StrApprovalStatusController : ControllerBase
    {

        private StrApprovalStatusService _ApprovalStatusService;

        public StrApprovalStatusController(StrApprovalStatusService ApprovalStatusService)
        {
            _ApprovalStatusService = ApprovalStatusService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] StrApprovalStatusVM ApprovalStatus)
        {
            var _response = _ApprovalStatusService.Add(ApprovalStatus);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] StrApprovalStatusVM ApprovalStatus)
        {
            var _response = _ApprovalStatusService.Update(ApprovalStatus);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _ApprovalStatusService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allApprovalStatus = _ApprovalStatusService.GetAll();
            return Ok(allApprovalStatus);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var ApprovalStatus = _ApprovalStatusService.GetById(id);
            return Ok(ApprovalStatus);
        }

    }
}
