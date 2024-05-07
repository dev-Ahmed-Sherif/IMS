using Business.PY;
using Entities.ViewModels.PY;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.PY
{

    [Route("api/[controller]")]
    [ApiController]

    public class PyItemGroupEmployeeController : ControllerBase
    {

        private PyItemGroupEmployeeService _ItemGroupEmployeeService;

        public PyItemGroupEmployeeController(PyItemGroupEmployeeService ItemGroupEmployeeService)
        {
            _ItemGroupEmployeeService = ItemGroupEmployeeService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] PyItemGroupEmployeeVM ItemGroupEmployee)
        {
            var _response = _ItemGroupEmployeeService.Add(ItemGroupEmployee);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] PyItemGroupEmployeeVM ItemGroupEmployee)
        {
            var _response = _ItemGroupEmployeeService.Update(ItemGroupEmployee);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _ItemGroupEmployeeService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allItemGroupEmployee = _ItemGroupEmployeeService.GetAll();
            return Ok(allItemGroupEmployee);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var ItemGroupEmployee = _ItemGroupEmployeeService.GetById(id);
            return Ok(ItemGroupEmployee);
        }
        [HttpGet("get/by/header/{id}")]
        public IActionResult GetByHeader(int id)
        {
            var ExchangeDetails = _ItemGroupEmployeeService.GetByHeader(id);
            return Ok(ExchangeDetails);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize, int HeaderId)
        {
            var Item = _ItemGroupEmployeeService.GetAllByPagination(page, pageSize, HeaderId);
            return Ok(Item);
        }

    }
}
