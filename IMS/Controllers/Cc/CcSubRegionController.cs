using Business.Cc;
using Entities.ViewModels.Cc;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.Cc
{
    [Route("api/[controller]")]
    [ApiController]
    public class CcSubRegionController : ControllerBase
    {
        private CcSubRegionService _cc_sub;

        public CcSubRegionController(CcSubRegionService AddService)
        {
            _cc_sub = AddService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] CcSubRegionGeneralVM add)
        {
            var _response = _cc_sub.Add(add);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] CcSubRegionVM update)
        {
            var _response = _cc_sub.Update(update);
            return new JsonResult(_response);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _cc_sub.Delete(id);
            return new JsonResult(_response);
        }


        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllSTR_Add = _cc_sub.GetAll();
            return Ok(AllSTR_Add);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var add = _cc_sub.GetById(id);
            return Ok(add);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var Pagination = _cc_sub.getAllByPagination(page, pageSize);
            return Ok(Pagination);
        }
    }
}
