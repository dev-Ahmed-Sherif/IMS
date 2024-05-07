using Business.STR.StoreOpen;
using Entities.ViewModels.STR.StoreOpen;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.STR.StoreOpen
{
    [Route("api/[controller]")]
    [ApiController]
    public class STROpeningStockDetailsController : ControllerBase
    {

        private StrOpeningStockDetailsService _opening_StockDetialsService;

        public STROpeningStockDetailsController(StrOpeningStockDetailsService opening_StockService)
        {
            _opening_StockDetialsService = opening_StockService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] StrOpeningStockDetailsGeneralVM opening_Stock_Details)
        {
            _opening_StockDetialsService.Add(opening_Stock_Details);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] StrOpeningStockDetailsVM opening_Stock_Details)
        {
            var updatedOpening_Stock_Details = _opening_StockDetialsService.Update(opening_Stock_Details);
            return Ok(updatedOpening_Stock_Details);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _opening_StockDetialsService.Delete(id);
            return Ok();
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allopening_Stock_Details = _opening_StockDetialsService.GetAll();
            return Ok(allopening_Stock_Details);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize, int id)
        {
            var Pagination = _opening_StockDetialsService.getAllByPagination(page, pageSize, id);
            return Ok(Pagination);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var opening_Stock = _opening_StockDetialsService.GetById(id);
            return Ok(opening_Stock);
        }
        [HttpGet("Get/by/header/{id}")]
        public IActionResult GetByHeader(int id)
        {
            var opening_Stock = _opening_StockDetialsService.GetByHeader(id);
            return Ok(opening_Stock);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] searchopeningstock searchModel)
        {
            var AllSTR_Add_Details = _opening_StockDetialsService.Search(searchModel);
            //DateTime? requiredDate = searchModel.Date;
            return Ok(AllSTR_Add_Details);
        }
        [HttpGet("Get/by/GetopenstockdetailsByStore/{storeid}/{itemid}/{fiscalyearid}")]
        public IActionResult GetopenstockdetailsByStore(int storeid, int itemid, int fiscalyearid)
        {
            var opening_Stock = _opening_StockDetialsService.GetopenstockdetailsByStore(storeid, itemid, fiscalyearid);
            return Ok(opening_Stock);
        }
    }

}
