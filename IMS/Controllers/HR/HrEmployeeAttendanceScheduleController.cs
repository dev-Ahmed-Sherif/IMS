using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace IMS.Controllers.HR
{

    [Route("api/[controller]")]
    [ApiController]
    public class HrEmployeeAttendanceScheduleController : ControllerBase
    {

        private HrEmployeeAttendanceScheduleService _EmployeeAttendanceScheduleService;

        public HrEmployeeAttendanceScheduleController(HrEmployeeAttendanceScheduleService EmployeeAttendanceScheduleService)
        {
            _EmployeeAttendanceScheduleService = EmployeeAttendanceScheduleService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrEmployeeAttendanceScheduleVM EmployeeAttendanceSchedule)
        {
            var _response = _EmployeeAttendanceScheduleService.Add(EmployeeAttendanceSchedule);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrEmployeeAttendanceScheduleVM EmployeeAttendanceSchedule)
        {
            var _response = _EmployeeAttendanceScheduleService.Update(EmployeeAttendanceSchedule);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _EmployeeAttendanceScheduleService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allEmployeeAttendanceSchedule = _EmployeeAttendanceScheduleService.GetAll();
            return Ok(allEmployeeAttendanceSchedule);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var EmployeeAttendanceSchedule = _EmployeeAttendanceScheduleService.GetById(id);
            return Ok(EmployeeAttendanceSchedule);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] HrEmpAttendScheduleSearch searchModel)
        {
            var EmployeeAttendence = _EmployeeAttendanceScheduleService.Search(searchModel);
            return Ok(EmployeeAttendence);
        }
        [HttpGet("get/Report")]
        public IActionResult Get([FromQuery] HrEmpAttendScheduleReport searchModel)
        {
            var reportFileByString = _EmployeeAttendanceScheduleService.GenerateReportAsync(searchModel.reportName, searchModel.reportType, searchModel);
            return File(reportFileByString, MediaTypeNames.Application.Pdf, Entities.Helpers.ReportHelper.GetReportDetails(searchModel.reportName, searchModel.reportType));
        }

    }
}
