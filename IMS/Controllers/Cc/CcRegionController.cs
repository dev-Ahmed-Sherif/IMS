using Business.Cc;
using Entities.ViewModels.Cc;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.Cc
{
    [Route("api/[controller]")]
    [ApiController]
    public class CcRegionController : ControllerBase
    {
        private CcRegionService _cc_reg;

        public CcRegionController(CcRegionService AddService)
        {
            _cc_reg = AddService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] CcRegionGeneralVM add)
        {
            var _response = _cc_reg.Add(add);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] CcRegionVM update)
        {
            var _response = _cc_reg.Update(update);
            return new JsonResult(_response);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _cc_reg.Delete(id);
            return new JsonResult(_response);
        }


        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllSTR_Add = _cc_reg.GetAll();
            return Ok(AllSTR_Add);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var add = _cc_reg.GetById(id);
            return Ok(add);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var Pagination = _cc_reg.getAllByPagination(page, pageSize);
            return Ok(Pagination);
        }
    }
}
