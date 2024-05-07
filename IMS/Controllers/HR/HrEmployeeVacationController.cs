using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace IMS.Controllers.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrEmployeeVacationController : ControllerBase
    {

        private HrEmployeeVacationService _EmployeeVacationService;

        public HrEmployeeVacationController(HrEmployeeVacationService EmployeeVacationService)
        {
            _EmployeeVacationService = EmployeeVacationService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrEmployeeVacationVM ID)
        {
            var _response = _EmployeeVacationService.Add(ID);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrEmployeeVacationVM ID)
        {
            var _response = _EmployeeVacationService.Update(ID);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int ID)
        {
            var _response = _EmployeeVacationService.Delete(ID);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allEmployeeVacation = _EmployeeVacationService.GetAll();
            return Ok(allEmployeeVacation);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int ID)
        {
            var EmployeeVacation = _EmployeeVacationService.GetById(ID);
            return Ok(EmployeeVacation);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] HrEmployeeVacationSearch searchModel)
        {
            var EmployeeVacationSearch = _EmployeeVacationService.Search(searchModel);
            return Ok(EmployeeVacationSearch);
        }


        [HttpGet("get/Report")]
        public IActionResult Report([FromQuery] HrEmploeeVactionReport searchModel)
        {

            var reportFileByString = _EmployeeVacationService.GenerateReportAsync(searchModel.reportName, searchModel.reportType, searchModel);
            return File(reportFileByString, MediaTypeNames.Application.Pdf, Entities.Helpers.ReportHelper.GetReportDetails(searchModel.reportName, searchModel.reportType));
        }

    }
}
