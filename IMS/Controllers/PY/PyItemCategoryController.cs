using Business.PY;
using Entities.ViewModels.PY;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.PY
{

    [Route("api/[controller]")]
    [ApiController]
    public class PyItemCategoryController : ControllerBase
    {

        private PyItemCategoryService _ItemCategoryService;

        public PyItemCategoryController(PyItemCategoryService ItemCategoryService)
        {
            _ItemCategoryService = ItemCategoryService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] PyItemCategoryVM ItemCategory)
        {
            var _response = _ItemCategoryService.Add(ItemCategory);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] PyItemCategoryVM ItemCategory)
        {
            var _response = _ItemCategoryService.Update(ItemCategory);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _ItemCategoryService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allItemCategory = _ItemCategoryService.GetAll();
            return Ok(allItemCategory);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var ItemCategory = _ItemCategoryService.GetById(id);
            return Ok(ItemCategory);
        }

        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var ItemCategory = _ItemCategoryService.GetAllByPagination(page, pageSize);
            return Ok(ItemCategory);
        }

    }
}
