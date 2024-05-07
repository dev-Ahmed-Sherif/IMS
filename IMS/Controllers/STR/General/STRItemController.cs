using Business.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace IMS.Controllers.STR.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class STRItemController : ControllerBase
    {

        private StrItemService _itemsService;

        public STRItemController(StrItemService itemsService)
        {
            _itemsService = itemsService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] StrItemVM item)
        {
            var _response = _itemsService.Add(item);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] StrItemVM group)
        {
            var _response = _itemsService.Update(group);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _itemsService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allItems = _itemsService.GetAll();
            return Ok(allItems);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var allItems = _itemsService.getAllByPagination(page, pageSize);
            return Ok(allItems);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var item = _itemsService.GetById(id);
            return Ok(item);
        }
        [HttpGet("get/By/Name/{Name}")]
        public IActionResult GetByName(string Name)
        {
            var item = _itemsService.GetByName(Name);
            return Ok(item);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] searchgeneral searchModel)
        {
            var AllSTR_Add_Details = _itemsService.Search(searchModel);
            return Ok(AllSTR_Add_Details);
        }
        [HttpGet("Get/lastNo")]
        public IActionResult GetLastNo(int GroupId)
        {
            var _response = _itemsService.GetLastNo(GroupId);
            return new JsonResult(_response);
        }
        [HttpGet("Get/Item/Transactions")]
        public IActionResult GetTransactions(int StoreId, int itemId, DateTime startdate, DateTime enddate, int FiscalYearId)
        {
            var transactions = _itemsService.GetTransactions(StoreId, itemId, startdate, enddate, FiscalYearId);
            return Ok(transactions);
        }
        [HttpGet("Get/Sum/Of/Qty/Between/Two/Date")]
        public IActionResult GetSumOfQtyBetweenTwoDate(int StoreId, DateTime StartDate, DateTime EndDate)
        {

            var transactions = _itemsService.GetSumOfQtyBetweenTwoDate(StoreId, StartDate, EndDate);
            return Ok(transactions);
        }
        [HttpGet("Get/Items/WithPositive/TotalQty")]
        public IActionResult GetItemsWithPositiveTotalQty(int StoreId, int fiscalyearId)
        {

            var transactions = _itemsService.GetItemsWithPositiveTotalQty(StoreId, fiscalyearId);
            return Ok(transactions);
        }
        [HttpGet("get/Report")]
        public async Task<IActionResult> Get([FromQuery] reportsearch searchModel, int StoreId, int itemId, DateTime StartDate, DateTime EndDate, int FiscalYearId)
        {
            //List<StrItemGeneralVM> AllSTR_Add_Details = _reportService.SearchProducts(searchModel);
            //var reportFileByString = _reportService.GenerateReportAsync(searchModel.reportName,searchModel.reportType,searchModel.reportData);
            var reportFileByString = await _itemsService.GenerateReportAsync(searchModel.reportName, searchModel.reportType, searchModel, StoreId, itemId, StartDate, EndDate, FiscalYearId);
            return File(reportFileByString, MediaTypeNames.Application.Pdf, Entities.Helpers.ReportHelper.GetReportDetails(searchModel.reportName, searchModel.reportType));
        }

    }

}
