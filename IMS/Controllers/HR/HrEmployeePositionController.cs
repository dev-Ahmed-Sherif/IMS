using Business.HR;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace IMS.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HrEmployeePositionController : ControllerBase
    {

        private HrEmployeePositionService _EmployeePositionService;

        public HrEmployeePositionController(HrEmployeePositionService EmployeePositionService)
        {
            _EmployeePositionService = EmployeePositionService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrEmployeePositionVM EmployeePosition)
        {
            var _response = _EmployeePositionService.Add(EmployeePosition);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrEmployeePositionVM EmployeePosition)
        {
            var _response = _EmployeePositionService.Update(EmployeePosition);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _EmployeePositionService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allEmployeePosition = _EmployeePositionService.GetAll();
            return Ok(allEmployeePosition);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var EmployeePosition = _EmployeePositionService.GetById(id);
            return Ok(EmployeePosition);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] HrEmployeePositionSearch searchModel)
        {
            var EmployeePosition = _EmployeePositionService.Search(searchModel);
            return Ok(EmployeePosition);
        }

        [HttpGet("get/Report")]
        public IActionResult Get([FromQuery] HrEmployeePositionReport searchModel)
        {
            var reportFileByString = _EmployeePositionService.GenerateReportAsync(searchModel.reportName, searchModel.reportType, searchModel);
            return File(reportFileByString, MediaTypeNames.Application.Pdf, Entities.Helpers.ReportHelper.GetReportDetails(searchModel.reportName, searchModel.reportType));
        }


    }
}
