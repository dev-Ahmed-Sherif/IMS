using Business.Cc;
using Business.STR.Add;
using Entities.ViewModels.Cc;
using Entities.ViewModels.STR.WithDraw;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.Cc
{
    [Route("api/[controller]")]
    [ApiController]
    public class CcEntryController : ControllerBase
    {
        private CcEntryService _cc_entr;

        public CcEntryController(CcEntryService AddService)
        {
            _cc_entr = AddService;
        }
        [HttpPost("Add")]
        public IActionResult Add([FromBody] CcEntryGeneralVM add)
        {
            var _response = _cc_entr.Add(add);
            return new JsonResult(_response);
        }
        [HttpPut("update")]
        public IActionResult Update([FromBody] CcEntryVM update)
        {
            var _response = _cc_entr.Update(update);
            return new JsonResult(_response);
        }

        [HttpDelete("Delete/{EntryId}")]
        public IActionResult Delete(int EntryId)
        {
            var _response = _cc_entr.Delete(EntryId);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllSTR_Add = _cc_entr.GetAll();
            return Ok(AllSTR_Add);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var add = _cc_entr.GetById(id);
            return Ok(add);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] searcccentry searchModel)
        {
            var AllSTR_Add_Details = _cc_entr.Search(searchModel);
            return Ok(AllSTR_Add_Details);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize, int YearId)
        {
            var Pagination = _cc_entr.getAllByPagination(page, pageSize, YearId);
            return Ok(Pagination);
        }
    }
}
