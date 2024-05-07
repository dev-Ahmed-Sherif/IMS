using Business.STR.Employee;
using Entities.ViewModels.STR.Employee;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.STR.Employee
{
    [Route("api/[controller]")]
    [ApiController]
    public class STREmployeeExchangeSerialController : ControllerBase
    {
        private StrEmployeeExchangeSerialService _Row;

        public STREmployeeExchangeSerialController(StrEmployeeExchangeSerialService ID)
        {
            _Row = ID;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] StrEmployeeExchangeSerialVM ID)
        {
            var _response = _Row.Add(ID);
            return new JsonResult(_response);
        }
        [HttpPut("update")]
        public IActionResult UpdateItem([FromBody] StrEmployeeExchangeSerialVM ID)
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
