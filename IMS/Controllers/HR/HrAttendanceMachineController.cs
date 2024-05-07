using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrAttendanceMachineController : ControllerBase
    {

        private HrAttendanceMachineService _AttendanceMachineService;

        public HrAttendanceMachineController(HrAttendanceMachineService AttendanceMachineService)
        {
            _AttendanceMachineService = AttendanceMachineService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrAttendanceMachineVM AttendanceMachine)
        {
            var _response = _AttendanceMachineService.Add(AttendanceMachine);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrAttendanceMachineVM AttendanceMachine)
        {
            var _response = _AttendanceMachineService.Update(AttendanceMachine);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _AttendanceMachineService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allAttendanceMachine = _AttendanceMachineService.GetAll();
            return Ok(allAttendanceMachine);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var AttendanceMachine = _AttendanceMachineService.GetById(id);
            return Ok(AttendanceMachine);
        }

    }
}
