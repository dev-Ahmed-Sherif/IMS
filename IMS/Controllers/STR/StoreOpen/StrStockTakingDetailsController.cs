using Business.STR.StoreOpen;
using Entities.ViewModels.STR.StoreOpen;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.STR.StoreOpen
{

    [Route("api/[controller]")]
    [ApiController]
    public class StrStockTakingDetailsController : ControllerBase
    {

        private StrStockTakingDetailsService _StockTakingDetialsService;

        public StrStockTakingDetailsController(StrStockTakingDetailsService StockTakingService)
        {
            _StockTakingDetialsService = StockTakingService;
        }


        [HttpPost("Add")]
        public IActionResult Add([FromBody] StrStockTakingDetailsGeneralVM StockTakingDetails)
        {
            var _response = _StockTakingDetialsService.Add(StockTakingDetails);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update( StrStockTakingDetailsVM StockTakingDetails)
        {
            var updatedStockTakingDetails = _StockTakingDetialsService.Update( StockTakingDetails);
            return new JsonResult(updatedStockTakingDetails);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _StockTakingDetialsService.Delete(id);
            return new JsonResult(result);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allStockTakingDetails = _StockTakingDetialsService.GetAll();
            return Ok(allStockTakingDetails);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int StockTakingid, int page, int pageSize)
        {
            var Pagination = _StockTakingDetialsService.getAllByPagination(StockTakingid, page, pageSize);
            return Ok(Pagination);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var StockTaking = _StockTakingDetialsService.GetById(id);
            return Ok(StockTaking);
        }
        [HttpGet("get/by/header/{id}")]
        public IActionResult GetByHeader(int id)
        {
            var StockTaking = _StockTakingDetialsService.GetByHeader(id);
            return Ok(StockTaking);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] Search searchModel)
        {
            var Add = _StockTakingDetialsService.Search(searchModel);
            return Ok(Add);
        }
        [HttpGet("Get/sum/with/CommodityName")]
        public IActionResult GetCommoditySum([FromQuery] Search searchModel)
        {
            var Add = _StockTakingDetialsService.GetCommoditySum(searchModel);
            return Ok(Add);
        }
        [HttpGet("Get/sum/with/PlatoonName")]
        public IActionResult GetPlatoonSum([FromQuery] Search searchModel)
        {
            var Add = _StockTakingDetialsService.GetPlatoonSum(searchModel);
            return Ok(Add);
        }

    }
}
