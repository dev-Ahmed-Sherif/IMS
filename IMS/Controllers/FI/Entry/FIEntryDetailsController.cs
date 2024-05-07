using Business.FI.Entry;
using Entities.ViewModels.FI.Entry;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.FI.Entry
{
    [Route("api/[controller]")]
    [ApiController]
    public class FIEntryDetailsController : ControllerBase
    {
        private FiEntryDetailsService _item;

        public FIEntryDetailsController(FiEntryDetailsService FI_EntryDetalisService)
        {
            _item = FI_EntryDetalisService;
        }

        [HttpPost("Add")]
        public IActionResult AddItem([FromBody] FiEntryDetailsGeneralVM item)
        {
            var _response = _item.Add(item);
            return new JsonResult(_response);
        }
        [HttpPut("update")]
        public IActionResult UpdateItem([FromBody] FiEntryDetailsVM item)
        {
            var _response = _item.Update(item);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteItem(int id)
        {
            var _response = _item.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAllItem()
        {
            var allItems = _item.GetAll();
            return Ok(allItems);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize, int HeaderId)
        {
            var Pagination = _item.getAllByPagination(page, pageSize, HeaderId);
            return Ok(Pagination);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetItemById(int id)
        {
            var CostCenter = _item.GetById(id);
            return Ok(CostCenter);
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] searchFiEntry searchModel)
        {
            var Add = _item.Search(searchModel);
            return Ok(Add);
        }
        [HttpGet("get/By/Header/{id}")]
        public IActionResult getByHeader(int id)
        {
            var CostCenter = _item.GetByHeader(id);
            return Ok(CostCenter);
        }
    }
}
