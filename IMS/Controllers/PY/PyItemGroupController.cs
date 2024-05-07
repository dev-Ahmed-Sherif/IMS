using Business.PY;
using Entities.ViewModels.PY;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.PY
{
    [Route("api/[controller]")]
    [ApiController]

    public class PyItemGroupController : ControllerBase
    {

        private PyItemGroupService _ItemGroupService;

        public PyItemGroupController(PyItemGroupService ItemGroupService)
        {
            _ItemGroupService = ItemGroupService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] PyItemGroupVM ItemGroup)
        {
            var _response = _ItemGroupService.Add(ItemGroup);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] PyItemGroupVM ItemGroup)
        {
            var _response = _ItemGroupService.Update(ItemGroup);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _ItemGroupService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allItemGroup = _ItemGroupService.GetAll();
            return Ok(allItemGroup);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var ItemGroup = _ItemGroupService.GetById(id);
            return Ok(ItemGroup);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var Item = _ItemGroupService.GetAllByPagination(page, pageSize);
            return Ok(Item);
        }
    }
}
