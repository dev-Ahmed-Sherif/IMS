using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.HR
{

    [Route("api/[controller]")]
    [ApiController]
    public class HrAttendancePermissionController : ControllerBase
    {

        private HrAttendancePermissionService _AttendancePermissionService;

        public HrAttendancePermissionController(HrAttendancePermissionService AttendancePermissionService)
        {
            _AttendancePermissionService = AttendancePermissionService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrAttendancePermissionVM AttendancePermission)
        {
            var _response = _AttendancePermissionService.Add(AttendancePermission);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrAttendancePermissionVM AttendancePermission)
        {
            var _response = _AttendancePermissionService.Update(AttendancePermission);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _AttendancePermissionService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allAttendancePermission = _AttendancePermissionService.GetAll();
            return Ok(allAttendancePermission);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var AttendancePermission = _AttendancePermissionService.GetById(id);
            return Ok(AttendancePermission);
        }

    }
}
