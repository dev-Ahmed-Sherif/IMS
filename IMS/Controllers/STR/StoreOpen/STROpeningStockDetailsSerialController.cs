using Business.STR.StoreOpen;
using Entities.ViewModels.STR.StoreOpen;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.STR.StoreOpen
{
    [Route("api/[controller]")]
    [ApiController]
    public class STROpeningStockDetailsSerialController : ControllerBase
    {
        private StrOpeningStockDetailsSerialService _Row;

        public STROpeningStockDetailsSerialController(StrOpeningStockDetailsSerialService ID)
        {
            _Row = ID;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] StrOpeningStockDetailsSerialVM ID)
        {
            var _response = _Row.Add(ID);
            return new JsonResult(_response);
        }
        [HttpPut("update")]
        public IActionResult UpdateItem([FromBody] StrOpeningStockDetailsSerialVM ID)
        {
            var _response = _Row.Update(ID);
            return new JsonResult(_response);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _Row.Delete(id);
            return new JsonResult(_response);
        }
        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allItems = _Row.GetAll();
            return Ok(allItems);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var CostCenter = _Row.GetById(id);
            return Ok(CostCenter);
        }
        [HttpGet("get/by/header/{id}")]
        public IActionResult GetByHeader(int id)
        {
            var CostCenter = _Row.GetByHeader(id);
            return Ok(CostCenter);
        }
        [HttpGet("get/by/Product/{id}")]
        public IActionResult GetByProduct(int id)
        {
            var CostCenter = _Row.GetByProduct(id);
            return Ok(CostCenter);
        }

    }
}
