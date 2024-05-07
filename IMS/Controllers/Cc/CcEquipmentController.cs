using Business.Cc;
using Entities.ViewModels.Cc;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.Cc
{
    [Route("api/[controller]")]
    [ApiController]
    public class CcEquipmentController : ControllerBase
    {
        private CcEquipmentService _cc_equi;

        public CcEquipmentController(CcEquipmentService AddService)
        {
            _cc_equi = AddService;
        }
        [HttpPost("Add")]
        public IActionResult Add([FromBody] CcEquipmentGeneralVM add)
        {
            var _response = _cc_equi.Add(add);
            return new JsonResult(_response);
        }
        [HttpPut("update")]
        public IActionResult Update([FromBody] CcEquipmentVM update)
        {
            var _response = _cc_equi.Update(update);
            return new JsonResult(_response);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _cc_equi.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllSTR_Add = _cc_equi.GetAll();
            return Ok(AllSTR_Add);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var add = _cc_equi.GetById(id);
            return Ok(add);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var Pagination = _cc_equi.getAllByPagination(page, pageSize);
            return Ok(Pagination);
        }
    }
}
