using Business.Cc;
using Entities.ViewModels.Cc;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.Cc
{
    [Route("api/[controller]")]
    [ApiController]
    public class CcEntryDetailsController : ControllerBase
    {
        private CcEntryDetailsService _cc_cost;

        public CcEntryDetailsController(CcEntryDetailsService AddService)
        {
            _cc_cost = AddService;
        }
        [HttpPost("Add")]
        public IActionResult Add([FromBody] CcEntryDetailsGeneralVM add)
        {
            var _response = _cc_cost.Add(add);
            return new JsonResult(_response);
        }
        [HttpPut("update")]
        public IActionResult Update([FromBody] CcEntryDetailsVM update)
        {
            var _response = _cc_cost.Update(update);
            return new JsonResult(_response);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _cc_cost.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllSTR_Add = _cc_cost.GetAll();
            return Ok(AllSTR_Add);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var add = _cc_cost.GetById(id);
            return Ok(add);
        }
        [HttpGet("get/By/Header/{id}")]
        public IActionResult GetByHeader(int id)
        {
            var add = _cc_cost.GetByHeader(id);
            return Ok(add);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize, int HeaderId)
        {
            var Pagination = _cc_cost.getAllByPagination(page, pageSize, HeaderId);
            return Ok(Pagination);
        }
    }
}
