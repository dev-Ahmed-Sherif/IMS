using Business.FI.Entry;
using Entities.ViewModels.FI.Entry;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.FI.Entry
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiEntrySourceController : ControllerBase
    {
        private FiEntrySourceService _item;

        public FiEntrySourceController(FiEntrySourceService FI_EntryService)
        {
            _item = FI_EntryService;
        }

        [HttpPost("Add")]
        public IActionResult AddItem([FromBody] FiEntrySourceGeneralVM entry)
        {
            var _response = _item.Add(entry);
            return new JsonResult(_response);
        }
        [HttpPut("update")]
        public IActionResult UpdateItem([FromBody] FiEntrySourceVM entry)
        {
            var _response = _item.Update(entry);
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

        [HttpGet("get/{id}")]
        public IActionResult GetItemById(int id)
        {
            var CostCenter = _item.GetById(id);
            return Ok(CostCenter);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var Pagination = _item.getAllByPagination(page, pageSize);
            return Ok(Pagination);
        }
    }
}

