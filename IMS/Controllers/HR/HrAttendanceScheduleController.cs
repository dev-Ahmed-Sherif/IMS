using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.HR
{


    [Route("api/[controller]")]
    [ApiController]
    public class HrAttendanceScheduleController : ControllerBase
    {

        private HrAttendanceScheduleService _AttendanceScheduleService;

        public HrAttendanceScheduleController(HrAttendanceScheduleService AttendanceScheduleService)
        {
            _AttendanceScheduleService = AttendanceScheduleService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrAttendanceScheduleVM AttendanceSchedule)
        {
            var _response = _AttendanceScheduleService.Add(AttendanceSchedule);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrAttendanceScheduleVM AttendanceSchedule)
        {
            var _response = _AttendanceScheduleService.Update(AttendanceSchedule);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _AttendanceScheduleService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allAttendanceSchedule = _AttendanceScheduleService.GetAll();
            return Ok(allAttendanceSchedule);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var AttendanceSchedule = _AttendanceScheduleService.GetById(id);
            return Ok(AttendanceSchedule);
        }

    }
}
