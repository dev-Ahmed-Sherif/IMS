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
    public class STREmployeeExchangeController : ControllerBase
    {
        private StrEmployeeExchangeService _Employee_ExchangeService;

        public STREmployeeExchangeController(StrEmployeeExchangeService exchService)
        {
            _Employee_ExchangeService = exchService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm] StrEmployeeExchangeGeneralVM exch)
        {
            string _response = await _Employee_ExchangeService.Add(exch);
            return new JsonResult(_response);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] StrEmployeeExchangeVM exch)
        {
            string _response = await _Employee_ExchangeService.Update(exch);
            return new JsonResult(_response);
        }
        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allEmployeeExchang = _Employee_ExchangeService.GetAll();
            return new JsonResult(allEmployeeExchang);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult GetAllByPagination(int page, int pageSize, int fiscalYearId)
        {
            var Pagination = _Employee_ExchangeService.GetAllByPagination(page, pageSize, fiscalYearId);
            return Ok(Pagination);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var EmployeeExchange = _Employee_ExchangeService.GetById(id);
            return Ok(EmployeeExchange);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _Employee_ExchangeService.Delete(id);
            return new JsonResult(_response);
        }
        [HttpGet("search")]
        public IActionResult search([FromQuery] searchemployeeexchange searchModel)
        {
            var AllSTR_Add_Details = _Employee_ExchangeService.search(searchModel);
            return Ok(AllSTR_Add_Details);
        }
        [HttpGet("get/AutoNo")]
        public IActionResult AutoNo()
        {
            var AutoNo = _Employee_ExchangeService.AutoNo();
            return Ok(AutoNo);
        }
        [HttpGet("get/Report")]
        public IActionResult Get([FromQuery] reportemployeeexchangesearch searchModel)
        {
            //List<StrItemGeneralVM> AllSTR_Add_Details = _reportService.SearchProducts(searchModel);


            Console.WriteLine(searchModel.ToString());
            //var reportFileByString = _reportService.GenerateReportAsync(searchModel.reportName,searchModel.reportType,searchModel.reportData);
            var reportFileByString = _Employee_ExchangeService.GenerateReportAsync(searchModel.reportName, searchModel.reportType, searchModel);
            return File(reportFileByString, MediaTypeNames.Application.Pdf, Entities.Helpers.ReportHelper.GetReportDetails(searchModel.reportName, searchModel.reportType));
        }


    }
}
