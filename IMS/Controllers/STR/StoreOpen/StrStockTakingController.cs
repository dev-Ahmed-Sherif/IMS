using Business.STR.StoreOpen;
using Entities.ViewModels.STR.StoreOpen;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;

namespace IMS.Controllers.STR.StoreOpen
{
    [Route("api/[controller]")]
    [ApiController]
    public class StrStockTakingController : ControllerBase
    {
        private StrStockTakingService _StockTakingService;

        public StrStockTakingController(StrStockTakingService StockTakingService)
        {
            _StockTakingService = StockTakingService;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] StrStockTakingVM StockTaking)
        {
            var _response =  await _StockTakingService.Add(StockTaking);
            return new JsonResult(_response);

        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] StrStockTakingVM StockTaking)
        {
            var _response = await _StockTakingService.Update(StockTaking);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _StockTakingService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allStockTaking = _StockTakingService.GetAll();
            return Ok(allStockTaking);
        }

        [HttpGet("get/by/pagination")]
        public IActionResult GetByPagination(int fiscalYearId, int pageIndex, int pageSize)
        {
            var allStockTaking = _StockTakingService.GetPaginated(fiscalYearId, pageIndex, pageSize);
            return Ok(allStockTaking);
        }

        [HttpGet("get/by/{id}")]
        public IActionResult GetById(int id)
        {
            var StockTaking = _StockTakingService.GetById(id);
            return Ok(StockTaking);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] Search searchModel)
        {
            var StockTaking = _StockTakingService.Search(searchModel);
            return Ok(StockTaking);
        }
        [HttpGet("storeTakingCommodity")]
        public IActionResult StoreBeforeTaking([FromQuery] Search searchModel)
        {
            var StockTaking = _StockTakingService.StoreBeforeTaking(searchModel);
            return Ok(StockTaking);
        }
        [HttpGet("get/Report")]
        public IActionResult Get([FromQuery] ReportStockTaking searchModel)
        {
            if (searchModel.ReportType == null)
            {
                searchModel.ReportType = "pdf";
            }
            var reportFileByString = _StockTakingService.GenerateReportAsync(searchModel.ReportName, searchModel.ReportType, searchModel);
            return File(reportFileByString, MediaTypeNames.Application.Pdf, Entities.Helpers.ReportHelper.GetReportDetails(searchModel.ReportName, searchModel.ReportType));
        }

    }
}
