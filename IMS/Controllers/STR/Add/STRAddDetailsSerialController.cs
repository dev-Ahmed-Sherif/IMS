using Business.STR.Add;
using Entities.ViewModels.STR.AddDetails;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.STR.Add
{
    [Route("api/[controller]")]
    [ApiController]
    public class STRAddDetailsSerialController : ControllerBase
    {
        private StrAddDetailsSerialService _Row;

        public STRAddDetailsSerialController(StrAddDetailsSerialService ID)
        {
            _Row = ID;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] StrAddDetailsSerialVM ID)
        {
            var _response = _Row.Add(ID);
            return new JsonResult(_response);
        }
        [HttpPut("update")]
        public IActionResult UpdateItem([FromBody] StrAddDetailsSerialVM ID)
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
            var row = _Row.GetById(id);
            return Ok(row);
        }
        [HttpGet("get/by/header/{id}")]
        public IActionResult GetByHeader(int id)
        {
            var row = _Row.GetByHeader(id);
            return Ok(row);
        }
        [HttpGet("get/by/Product/{id}")]
        public IActionResult GetByProduct(int id)
        {
            var row = _Row.GetByProduct(id);
            return Ok(row);
        }
    }
}
