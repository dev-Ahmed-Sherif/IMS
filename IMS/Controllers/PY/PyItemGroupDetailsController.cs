using Business.PY;
using Entities.ViewModels.PY;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.PY
{


    [Route("api/[controller]")]
    [ApiController]

    public class PyItemGroupDetailsController : ControllerBase
    {

        private PyItemGroupDetailsService _ItemGroupDetailsService;

        public PyItemGroupDetailsController(PyItemGroupDetailsService ItemGroupDetailsService)
        {
            _ItemGroupDetailsService = ItemGroupDetailsService;
        }

        [HttpPost("Add")]
        public IActionResult AddDetails([FromBody] PyItemGroupDetailsVM ItemGroupDetails)
        {
            var _response = _ItemGroupDetailsService.Add(ItemGroupDetails);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] PyItemGroupDetailsVM ItemGroupDetails)
        {
            var _response = _ItemGroupDetailsService.Update(ItemGroupDetails);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _ItemGroupDetailsService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allItemGroupDetails = _ItemGroupDetailsService.GetAll();
            return Ok(allItemGroupDetails);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var ItemGroupDetails = _ItemGroupDetailsService.GetById(id);
            return Ok(ItemGroupDetails);
        }
        [HttpGet("get/by/header/{id}")]
        public IActionResult GetByHeader(int id)
        {
            var ExchangeDetails = _ItemGroupDetailsService.GetByHeader(id);
            return Ok(ExchangeDetails);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize, int HeaderId)
        {
            var Item = _ItemGroupDetailsService.GetAllByPagination(page, pageSize, HeaderId);
            return Ok(Item);
        }

    }
}
