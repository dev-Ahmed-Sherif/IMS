using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace IMS.Controllers.HR
{

    [Route("api/[controller]")]
    [ApiController]
    public class HrEmployeeAttendancePermissionController : ControllerBase
    {

        private HrEmployeeAttendancePermissionService _EmployeeAttendancePermissionService;

        public HrEmployeeAttendancePermissionController(HrEmployeeAttendancePermissionService EmployeeAttendancePermissionService)
        {
            _EmployeeAttendancePermissionService = EmployeeAttendancePermissionService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrEmployeeAttendancePermissionVM EmployeeAttendancePermission)
        {
            var _response = _EmployeeAttendancePermissionService.Add(EmployeeAttendancePermission);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrEmployeeAttendancePermissionVM EmployeeAttendancePermission)
        {
            var _response = _EmployeeAttendancePermissionService.Update(EmployeeAttendancePermission);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _EmployeeAttendancePermissionService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allEmployeeAttendancePermission = _EmployeeAttendancePermissionService.GetAll();
            return Ok(allEmployeeAttendancePermission);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var EmployeeAttendancePermission = _EmployeeAttendancePermissionService.GetById(id);
            return Ok(EmployeeAttendancePermission);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] HrEmployeeAttendancePermissionSearch searchModel)
        {
            var EmployeeAttendence = _EmployeeAttendancePermissionService.Search(searchModel);
            return Ok(EmployeeAttendence);
        }
        [HttpGet("get/Report")]
        public IActionResult Get([FromQuery] HrEmpAttendancePermissionReport searchModel)
        {
            var reportFileByString = _EmployeeAttendancePermissionService.GenerateReportAsync(searchModel.reportName, searchModel.reportType, searchModel);
            return File(reportFileByString, MediaTypeNames.Application.Pdf, Entities.Helpers.ReportHelper.GetReportDetails(searchModel.reportName, searchModel.reportType));
        }

    }
}
