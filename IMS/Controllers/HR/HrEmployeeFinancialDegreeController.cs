using Business.HR;
using Entities.ViewModels;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace IMS.Controllers.HR
{

    [Route("api/[controller]")]
    [ApiController]
    public class HrEmployeeFinancialDegreeController : ControllerBase
    {

        private HrEmployeeFinancialDegreeService _EmployeeFinancialDegreeService;

        public HrEmployeeFinancialDegreeController(HrEmployeeFinancialDegreeService EmployeeFinancialDegreeService)
        {
            _EmployeeFinancialDegreeService = EmployeeFinancialDegreeService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrEmployeeFinancialDegreeVM ID)
        {
            var _response = _EmployeeFinancialDegreeService.Add(ID);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrEmployeeFinancialDegreeVM ID)
        {
            var _response = _EmployeeFinancialDegreeService.Update(ID);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int ID)
        {
            var _response = _EmployeeFinancialDegreeService.Delete(ID);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allEmployeeFinancialDegree = _EmployeeFinancialDegreeService.GetAll();
            return Ok(allEmployeeFinancialDegree);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int ID)
        {
            var EmployeeFinancialDegree = _EmployeeFinancialDegreeService.GetById(ID);
            return Ok(EmployeeFinancialDegree);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] HrEmployeeFinancialDegreeSearch searchModel)
        {
            var EmployeeFinancialDegree = _EmployeeFinancialDegreeService.Search(searchModel);
            return Ok(EmployeeFinancialDegree);
        }
        [HttpGet("get/Report")]
        public IActionResult Get([FromQuery] HrEmployeeFinancialDegreeReport searchModel)
        {

            var reportFileByString = _EmployeeFinancialDegreeService.GenerateReportAsync(searchModel.reportName, searchModel.reportType, searchModel);
            return File(reportFileByString, MediaTypeNames.Application.Pdf, Entities.Helpers.ReportHelper.GetReportDetails(searchModel.reportName, searchModel.reportType));
        }
    }
}
