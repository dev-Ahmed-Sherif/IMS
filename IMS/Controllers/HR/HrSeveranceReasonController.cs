using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrSeveranceReasonController : ControllerBase
    {

        private HrSeveranceReasonService _SeveranceReasonService;

        public HrSeveranceReasonController(HrSeveranceReasonService SeveranceReasonService)
        {
            _SeveranceReasonService = SeveranceReasonService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrSeveranceReasonVM ID)
        {
            var _response = _SeveranceReasonService.Add(ID);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrSeveranceReasonVM ID)
        {
            var _response = _SeveranceReasonService.Update(ID);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int ID)
        {
            var _response = _SeveranceReasonService.Delete(ID);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allSeveranceReason = _SeveranceReasonService.GetAll();
            return Ok(allSeveranceReason);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int ID)
        {
            var SeveranceReason = _SeveranceReasonService.GetById(ID);
            return Ok(SeveranceReason);
        }

    }
}
