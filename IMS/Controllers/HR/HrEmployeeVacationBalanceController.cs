using Business.HR;
using Entities.ViewModels;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace IMS.Controllers.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrEmployeeVacationBalanceController : ControllerBase
    {

        private HrEmployeeVacationBalanceService _EmployeeVacationBalanceService;

        public HrEmployeeVacationBalanceController(HrEmployeeVacationBalanceService EmployeeVacationBalanceService)
        {
            _EmployeeVacationBalanceService = EmployeeVacationBalanceService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrEmployeeVacationBalanceVM ID)
        {
            var _response = _EmployeeVacationBalanceService.Add(ID);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrEmployeeVacationBalanceVM ID)
        {
            var _response = _EmployeeVacationBalanceService.Update(ID);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int ID)
        {
            var _response = _EmployeeVacationBalanceService.Delete(ID);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allEmployeeVacationBalance = _EmployeeVacationBalanceService.GetAll();
            return Ok(allEmployeeVacationBalance);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int ID)
        {
            var EmployeeVacationBalance = _EmployeeVacationBalanceService.GetById(ID);
            return Ok(EmployeeVacationBalance);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] HrEmployeeVacationBalanceSearch searchModel)
        {
            var EmployeeVacationBalance = _EmployeeVacationBalanceService.Search(searchModel);
            return Ok(EmployeeVacationBalance);
        }
        [HttpGet("get/Report")]
        public IActionResult Get([FromQuery] HrEmployeeVacationBalanceReport searchModel)
        {

            var reportFileByString = _EmployeeVacationBalanceService.GenerateReportAsync(searchModel.reportName, searchModel.reportType, searchModel);
            return File(reportFileByString, MediaTypeNames.Application.Pdf, Entities.Helpers.ReportHelper.GetReportDetails(searchModel.reportName, searchModel.reportType));
        }
    }
}
