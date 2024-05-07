using Business.TR.Plan;
using Entities.ViewModels.TR.Plan;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.TR.Plan
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrPlanCourseDataController : ControllerBase
    {
        private TrPlanCourseDataService _Tr_PlanCourseDataService;
        public TrPlanCourseDataController(TrPlanCourseDataService AddTrPlanCourseData)
        {
            _Tr_PlanCourseDataService = AddTrPlanCourseData;
        }
        [HttpPost("Add")]
        public IActionResult Add([FromBody] TrPlanCourseDataVM add)
        {
            var _response = _Tr_PlanCourseDataService.Add(add);
            return new JsonResult(_response);
        }
        [HttpPut("update")]
        public IActionResult Update([FromBody] TrPlanCourseDataVM update)
        {
            var _response = _Tr_PlanCourseDataService.Update(update);
            return new JsonResult(_response);
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _Tr_PlanCourseDataService.Delete(id);
            return new JsonResult(_response);
        }
        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllSTR_Add = _Tr_PlanCourseDataService.GetAll();
            return Ok(AllSTR_Add);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var add = _Tr_PlanCourseDataService.GetById(id);
            return Ok(add);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var Exchange = _Tr_PlanCourseDataService.getAllByPagination(page, pageSize);
            return Ok(Exchange);
        }

    }

}
