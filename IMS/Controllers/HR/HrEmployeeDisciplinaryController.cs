using Business.HR;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace IMS.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HrEmployeeDisciplinaryController : ControllerBase
    {

        private HrEmployeeDisciplinaryService _EmployeeDisciplinaryService;

        public HrEmployeeDisciplinaryController(HrEmployeeDisciplinaryService EmployeeDisciplinaryService)
        {
            _EmployeeDisciplinaryService = EmployeeDisciplinaryService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrEmployeeDisciplinaryVM EmployeeDisciplinary)
        {
            var _response = _EmployeeDisciplinaryService.Add(EmployeeDisciplinary);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrEmployeeDisciplinaryVM EmployeeDisciplinary)
        {
            var _response = _EmployeeDisciplinaryService.Update(EmployeeDisciplinary);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _EmployeeDisciplinaryService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allEmployeeDisciplinary = _EmployeeDisciplinaryService.GetAll();
            return Ok(allEmployeeDisciplinary);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var EmployeeDisciplinary = _EmployeeDisciplinaryService.GetById(id);
            return Ok(EmployeeDisciplinary);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] HrEmployeeDisciplinarySearch searchModel)
        {
            var Add = _EmployeeDisciplinaryService.Search(searchModel);
            return Ok(Add);
        }
        [HttpGet("get/Report")]
        public IActionResult Get([FromQuery] HrEmployeeDisciplinaryReport searchModel)
        {

            var reportFileByString = _EmployeeDisciplinaryService.GenerateReportAsync(searchModel.reportName, searchModel.reportType, searchModel);
            return File(reportFileByString, MediaTypeNames.Application.Pdf, Entities.Helpers.ReportHelper.GetReportDetails(searchModel.reportName, searchModel.reportType));
        }
    }
}
