using Business.PY;
using Entities.ViewModels.PY;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.PY
{


    [Route("api/[controller]")]
    [ApiController]
    public class PyItemController : ControllerBase
    {

        private PyItemService _ItemService;

        public PyItemController(PyItemService ItemService)
        {
            _ItemService = ItemService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] PyItemVM Item)
        {
            var _response = _ItemService.Add(Item);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] PyItemVM Item)
        {
            var _response = _ItemService.Update(Item);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _ItemService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allItem = _ItemService.GetAll();
            return Ok(allItem);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var Item = _ItemService.GetById(id);
            return Ok(Item);
        }
        [HttpGet("get/by/header/{id}")]
        public IActionResult GetByHeader(int id)
        {
            var ExchangeDetails = _ItemService.GetByHeader(id);
            return Ok(ExchangeDetails);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var Item = _ItemService.GetAllByPagination(page, pageSize);
            return Ok(Item);
        }

    }
}
