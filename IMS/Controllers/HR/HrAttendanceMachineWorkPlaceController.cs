using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.HR
{


    [Route("api/[controller]")]
    [ApiController]
    public class HrAttendanceMachineWorkPlaceController : ControllerBase
    {

        private HrAttendanceMachineWorkPlaceService _AttendanceMachineWorkPlaceService;

        public HrAttendanceMachineWorkPlaceController(HrAttendanceMachineWorkPlaceService AttendanceMachineWorkPlaceService)
        {
            _AttendanceMachineWorkPlaceService = AttendanceMachineWorkPlaceService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrAttendanceMachineWorkPlaceVM AttendanceMachine)
        {
            var _response = _AttendanceMachineWorkPlaceService.Add(AttendanceMachine);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrAttendanceMachineWorkPlaceVM AttendanceMachineWorkPlace)
        {
            var _response = _AttendanceMachineWorkPlaceService.Update(AttendanceMachineWorkPlace);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _AttendanceMachineWorkPlaceService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allAttendanceMachineWorkPlace = _AttendanceMachineWorkPlaceService.GetAll();
            return Ok(allAttendanceMachineWorkPlace);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var AttendanceMachineWorkPlace = _AttendanceMachineWorkPlaceService.GetById(id);
            return Ok(AttendanceMachineWorkPlace);
        }

    }
}
