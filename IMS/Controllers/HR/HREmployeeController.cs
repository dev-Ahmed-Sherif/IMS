using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace IMS.Controllers.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class HREmployeeController : ControllerBase
    {

        private HrEmployeeService _employeeService;

        public HREmployeeController(HrEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("Add")]
        public IActionResult AddEmployee([FromBody] HrEmployeeVM employee)
        {
            var _response = _employeeService.Add(employee);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult UpdateEmployee([FromBody] HrEmployeeVM employee)
        {
            var _response = _employeeService.Update(employee);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var _response = _employeeService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAllEmployee()
        {
            var allEmployee = _employeeService.GetAll();
            return Ok(allEmployee);
        }
        [HttpGet("get/pagnation")]
        public IActionResult GetPagination(int page, int pageSize)
        {
            var allItems = _employeeService.GetPagination(page, pageSize);
            return Ok(allItems);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _employeeService.GetById(id);
            return Ok(employee);
        }
        [HttpGet("get/By/Name/{Name}")]
        public IActionResult GetByName(string Name)
        {
            var employee = _employeeService.GetByName(Name);
            return Ok(employee);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] HrSearch searchModel)
        {
            var employee = _employeeService.Search(searchModel);
            return Ok(employee);
        }
        [HttpGet("get/Report")]
        public IActionResult Get([FromQuery] HrReport searchModel)
        {

            var reportFileByString = _employeeService.GenerateReportAsync(searchModel.reportName, searchModel.reportType, searchModel);
            return File(reportFileByString, MediaTypeNames.Application.Pdf, Entities.Helpers.ReportHelper.GetReportDetails(searchModel.reportName, searchModel.reportType));
        }

    }

}
