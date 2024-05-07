using Business.Cc;
using Entities.ViewModels.Cc;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.Cc
{
    [Route("api/[controller]")]
    [ApiController]
    public class CcPlantComponentController : ControllerBase
    {
        private CcPlantComponentService _cc_plan;

        public CcPlantComponentController(CcPlantComponentService AddService)
        {
            _cc_plan = AddService;
        }
        [HttpPost("Add")]
        public IActionResult Add([FromBody] CcPlantComponentGeneralVM add)
        {
            var _response = _cc_plan.Add(add);
            return new JsonResult(_response);
        }
        [HttpPut("update")]
        public IActionResult Update([FromBody] CcPlantComponentVM update)
        {
            var _response = _cc_plan.Update(update);
            return new JsonResult(_response);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _cc_plan.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllSTR_Add = _cc_plan.GetAll();
            return Ok(AllSTR_Add);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var add = _cc_plan.GetById(id);
            return Ok(add);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var Pagination = _cc_plan.getAllByPagination(page, pageSize);
            return Ok(Pagination);
        }
    }
}
