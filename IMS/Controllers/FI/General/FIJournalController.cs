using Business.FI.General;
using Entities.ViewModels.FI.General;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.FI.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class FIJournalController : ControllerBase
    {
        private FiJournalService _item;

        public FIJournalController(FiJournalService FI_JournalService)
        {
            _item = FI_JournalService;
        }

        [HttpPost("Add")]
        public IActionResult AddItem([FromBody] FiJournalGeneralVM journal)
        {
            var _response = _item.Add(journal);
            return new JsonResult(_response);
        }
        [HttpPut("update")]
        public IActionResult UpdateItem([FromBody] FiJournalVM item)
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
        public IActionResult GetAllItem(int YearID)
        {
            var allItems = _item.GetAll(YearID);
            return Ok(allItems);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize, int YearID)
        {
            var Pagination = _item.getAllByPagination(page, pageSize, YearID);
            return Ok(Pagination);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetItemById(int id)
        {
            var CostCenter = _item.GetById(id);
            return Ok(CostCenter);
        }
        [HttpGet("get/By/Description/{Description}")]
        public IActionResult GetFiJournalByName(string Description)
        {
            var CostCenter = _item.GetByName(Description);
            return Ok(CostCenter);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] Searchjournal searchModel)
        {
            var Add = _item.Search(searchModel);
            return Ok(Add);
        }
    }
}
