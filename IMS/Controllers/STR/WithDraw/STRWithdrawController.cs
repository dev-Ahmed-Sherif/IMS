using Business.STR.WithDraw;
using Entities.ViewModels.STR.WithDraw;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace IMS.Controllers.STR.WithDraw
{
    [Route("api/[controller]")]
    [ApiController]
    public class STRWithdrawController : ControllerBase

    {
        private StrWithDrawService _WithdrawService;
        public STRWithdrawController(StrWithDrawService STR_WithdrawService)
        {
            _WithdrawService = STR_WithdrawService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm] StrWithdrawVM withdraw)
        {
            string _response = await _WithdrawService.Add(withdraw);
            return new JsonResult(_response);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] StrWithdrawVM group)
        {
            string _response = await _WithdrawService.Update(group);
            return new JsonResult(_response);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _WithdrawService.Delete(id);
            return new JsonResult(_response);
        }
        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allItems = _WithdrawService.GetAll();
            return Ok(allItems);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var item = _WithdrawService.GetById(id);
            return Ok(item);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] searchwithdraw searchModel)
        {
            var AllSTR_Add_Details = _WithdrawService.Search(searchModel);
            return Ok(AllSTR_Add_Details);
        }
        [HttpGet("get/By/Employee/Stores/{employeeId}")]
        public IActionResult GetByUserStores(int employeeId, int page, int pageSize, int fiscalYearId)
        {
            var add = _WithdrawService.GetByUserStores(employeeId, page, pageSize, fiscalYearId);
            return Ok(add);
        }
        [HttpGet("get/By/Dest/Store/{Id}")]
        public IActionResult GetByDestStore(int Id, int fiscalYearId)
        {
            var add = _WithdrawService.GetByDestStore(Id, fiscalYearId);
            return Ok(add);
        }


        [HttpGet("get/AutoNo")]
        public IActionResult AutoNo(int StoreId, int FiscalYearId)
        {
            var AutoNo = _WithdrawService.AutoNo(StoreId, FiscalYearId);
            return Ok(AutoNo);
        }

        [HttpGet("get/Report")]
        public IActionResult Get([FromQuery] reportwithdrawsearch searchModel)
        {
            //List<StrItemGeneralVM> AllSTR_Add_Details = _reportService.SearchProducts(searchModel);


            Console.WriteLine(searchModel.ToString());
            //var reportFileByString = _reportService.GenerateReportAsync(searchModel.reportName,searchModel.reportType,searchModel.reportData);
            var reportFileByString = _WithdrawService.GenerateReportAsync(searchModel.reportName, searchModel.reportType, searchModel);
            return File(reportFileByString, MediaTypeNames.Application.Pdf, Entities.Helpers.ReportHelper.GetReportDetails(searchModel.reportName, searchModel.reportType));
        }

    }
}
