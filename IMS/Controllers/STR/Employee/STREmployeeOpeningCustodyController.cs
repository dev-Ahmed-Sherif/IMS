using Business.STR.Employee;
using Entities.ViewModels.STR.Employee;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace IMS.Controllers.STR.Employee
{
    [Route("api/[controller]")]
    [ApiController]
    public class STREmployeeOpeningCustodyController : ControllerBase
    {
        private StrEmployeeOpeningCustodyService _Employee_Opening_CustodyService;

        public STREmployeeOpeningCustodyController(StrEmployeeOpeningCustodyService Employee_Opening_CustodyService)
        {
            _Employee_Opening_CustodyService = Employee_Opening_CustodyService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm] StrEmployeeOpeningCustodyVM add)
        {
            string _response = await _Employee_Opening_CustodyService.Add(add);
            return new JsonResult(_response);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] StrEmployeeOpeningCustodyVM update)
        {
            string _response = await _Employee_Opening_CustodyService.Update(update);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _Employee_Opening_CustodyService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllCustody = _Employee_Opening_CustodyService.GetAll();
            return Ok(AllCustody);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var getById = _Employee_Opening_CustodyService.GetById(id);
            return Ok(getById);
        }
        [HttpGet("search")]
        public IActionResult searchemployeeopeningcustody([FromQuery] searchemployeeopeningcustody searchModel)
        {
            var AllSTR_Add_Details = _Employee_Opening_CustodyService.search(searchModel);
            return Ok(AllSTR_Add_Details);
        }
        [HttpGet("get/AutoNo")]
        public IActionResult AutoNo()
        {
            var AutoNo = _Employee_Opening_CustodyService.AutoNo();
            return Ok(AutoNo);
        }
        [HttpGet("get/Report")]
        public IActionResult Get([FromQuery] reportemployeeopeningcustody searchModel)
        {
            //List<StrItemGeneralVM> AllSTR_Add_Details = _reportService.SearchProducts(searchModel);
            Console.WriteLine(searchModel.ToString());
            //var reportFileByString = _reportService.GenerateReportAsync(searchModel.reportName,searchModel.reportType,searchModel.reportData);
            var reportFileByString = _Employee_Opening_CustodyService.GenerateReportAsync(searchModel.reportName, searchModel.reportType, searchModel);
            return File(reportFileByString, MediaTypeNames.Application.Pdf, Entities.Helpers.ReportHelper.GetReportDetails(searchModel.reportName, searchModel.reportType));
        }

        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult GetAllByPagination(int page, int pageSize, int fiscalYearId)
        {
            var Pagination = _Employee_Opening_CustodyService.GetAllByPagination(page, pageSize, fiscalYearId);
            return Ok(Pagination);
        }
    }
}
