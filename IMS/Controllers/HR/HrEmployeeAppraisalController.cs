using Business.HR;
using Entities.ViewModels;
using Entities.ViewModels.STR.AddDetails;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrEmployeeAppraisalController : ControllerBase
    {

        private HrEmployeeAppraisalService _EmployeeAppraisalService;

        public HrEmployeeAppraisalController(HrEmployeeAppraisalService EmployeeAppraisalService)
        {
            _EmployeeAppraisalService = EmployeeAppraisalService;
        }

        [HttpPost("Add")]
        public  async Task<IActionResult> Add([FromForm] HrEmployeeAppraisalVM EmployeeAppraisal) 
        {
            var _response = await _EmployeeAppraisalService.Add(EmployeeAppraisal);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] HrEmployeeAppraisalVM EmployeeAppraisal)
        {
            var _response =await _EmployeeAppraisalService.Update(EmployeeAppraisal);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _EmployeeAppraisalService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allEmployeeAppraisal = _EmployeeAppraisalService.GetAll();
            return Ok(allEmployeeAppraisal);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var EmployeeAppraisal = _EmployeeAppraisalService.GetById(id);
            return Ok(EmployeeAppraisal);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] searchEmpAppr searchModel)
        {
            var Add = _EmployeeAppraisalService.Search(searchModel);
            return Ok(Add);
        }
        [HttpGet("get/Report")]
        public IActionResult Get([FromQuery] HrEmployeeAppraisalReport searchModel)
        {

            var reportFileByString = _EmployeeAppraisalService.GenerateReportAsync(searchModel.reportName, searchModel.reportType, searchModel);
            return File(reportFileByString, MediaTypeNames.Application.Pdf, Entities.Helpers.ReportHelper.GetReportDetails(searchModel.reportName, searchModel.reportType));
        }

    }
}
