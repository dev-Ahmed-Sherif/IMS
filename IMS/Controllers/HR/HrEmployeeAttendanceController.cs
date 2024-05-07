using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace IMS.Controllers.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrEmployeeAttendanceController : ControllerBase
    {

        private HrEmployeeAttendanceService _EmployeeAttendanceService;

        public HrEmployeeAttendanceController(HrEmployeeAttendanceService EmployeeAttendanceService)
        {
            _EmployeeAttendanceService = EmployeeAttendanceService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrEmployeeAttendanceVM EmployeeAttendance)
        {
            var _response = _EmployeeAttendanceService.Add(EmployeeAttendance);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrEmployeeAttendanceVM EmployeeAttendance)
        {
            var _response = _EmployeeAttendanceService.Update(EmployeeAttendance);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _EmployeeAttendanceService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allEmployeeAttendance = _EmployeeAttendanceService.GetAll();
            return Ok(allEmployeeAttendance);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var EmployeeAttendance = _EmployeeAttendanceService.GetById(id);
            return Ok(EmployeeAttendance);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] HrEmployeeAttendanceSearch searchModel)
        {
            var EmployeeAttendence = _EmployeeAttendanceService.Search(searchModel);
            return Ok(EmployeeAttendence);
        }
        [HttpGet("get/Report")]
        public IActionResult Get([FromQuery] HrEmployeeAttendanceReport searchModel)
        {
            var reportFileByString = _EmployeeAttendanceService.GenerateReportAsync(searchModel.reportName, searchModel.reportType, searchModel);
            return File(reportFileByString, MediaTypeNames.Application.Pdf, Entities.Helpers.ReportHelper.GetReportDetails(searchModel.reportName, searchModel.reportType));
        }

    }
}
