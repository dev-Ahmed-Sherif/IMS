using Business.STR.StoreOpen;
using Entities.ViewModels.STR.StoreOpen;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;

namespace IMS.Controllers.STR.StoreOpen
{
    [Route("api/[controller]")]
    [ApiController]
    public class STROpeningStockController : ControllerBase
    {

        private StrOpeningStockService _opening_StockService;

        public STROpeningStockController(StrOpeningStockService opening_StockService)
        {
            _opening_StockService = opening_StockService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] StrOpeningStockVM opening_Stock)
        {
            var _response = await _opening_StockService.Add(opening_Stock);
            return new JsonResult(_response);

        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] StrOpeningStockVM opening_Stock)
        {
            var _response = await _opening_StockService.Update(opening_Stock);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _opening_StockService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allopening_Stock = _opening_StockService.GetAll();
            return Ok(allopening_Stock);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var opening_Stock = _opening_StockService.GetById(id);
            return Ok(opening_Stock);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] searchopeningstock searchModel)
        {
            var AllSTR_Add_Details = _opening_StockService.Search(searchModel);
            //DateTime? requiredDate = searchModel.Date;
            return Ok(AllSTR_Add_Details);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult GetAllByPagination(int page, int pageSize, int fiscalYearId)
        {
            var data = _opening_StockService.GetAllByPagination(page, pageSize, fiscalYearId);
            return Ok(data);
        }

        [HttpGet("get/Get/Last/No")]
        public IActionResult GetLastNo(int StoreId, int FiscalYearId)
        {
            var AutoNo = _opening_StockService.GetLastNo(StoreId, FiscalYearId);
            return Ok(AutoNo);
        }
        [HttpGet("get/Report")]
        public IActionResult Get([FromQuery] reportOpeningStock searchModel)
        {
            //List<StrItemGeneralVM> AllSTR_Add_Details = _reportService.SearchProducts(searchModel);
            //var reportFileByString = _reportService.GenerateReportAsync(searchModel.reportName,searchModel.reportType,searchModel.reportData);
            var reportFileByString = _opening_StockService.GenerateReportAsync(searchModel.reportName, searchModel.reportType, searchModel);
            return File(reportFileByString, MediaTypeNames.Application.Pdf, Entities.Helpers.ReportHelper.GetReportDetails(searchModel.reportName, searchModel.reportType));
        }

    }

}
