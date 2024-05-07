using Business.Cc;
using Entities.ViewModels.Cc;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.Cc
{

    [Route("api/[controller]")]
    [ApiController]
    public class CcFunctionController : ControllerBase

    {
        private CcFunctionService _cc_fun;

        public CcFunctionController(CcFunctionService AddService)
        {
            _cc_fun = AddService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] CcFunctionGeneralVM add)
        {
            var _response = _cc_fun.Add(add);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] CcFunctionVM update)
        {
            var _response = _cc_fun.Update(update);
            return new JsonResult(_response);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _cc_fun.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllSTR_Add = _cc_fun.GetAll();
            return Ok(AllSTR_Add);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var add = _cc_fun.GetById(id);
            return Ok(add);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var Pagination = _cc_fun.getAllByPagination(page, pageSize);
            return Ok(Pagination);
        }
    }
}
