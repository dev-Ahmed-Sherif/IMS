using Business.TR.Plan;
using Entities.ViewModels.TR.Plan;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.TR.Plan
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrPlanController : ControllerBase
    {
        private TrPlanService _TrPlanService;

        public TrPlanController(TrPlanService TrPlanService)
        {
            _TrPlanService = TrPlanService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] TrPlanGeneralVM add)
        {
            var _response = _TrPlanService.Add(add);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] TrPlanVM update)
        {
            var _response = _TrPlanService.Update(update);
            return new JsonResult(_response);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _TrPlanService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllSTR_Add = _TrPlanService.GetAll();
            return Ok(AllSTR_Add);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var add = _TrPlanService.GetById(id);
            return Ok(add);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var Exchange = _TrPlanService.getAllByPagination(page, pageSize);
            return Ok(Exchange);
        }
    }
}
