using Business.TR.Plan;
using Entities.ViewModels.TR.Plan;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.TR.Plan
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrPlanFinancierController : ControllerBase
    {
        private TrPlanFinancierService _Tr_PlanFinancierService;

        public TrPlanFinancierController(TrPlanFinancierService AddTrPlanFinancier)
        {
            _Tr_PlanFinancierService = AddTrPlanFinancier;
        }
        [HttpPost("Add")]
        public IActionResult Add([FromBody] TrPlanFinancierVM add)
        {
            var _response = _Tr_PlanFinancierService.Add(add);
            return new JsonResult(_response);
        }
        [HttpPut("update")]
        public IActionResult Update([FromBody] TrPlanFinancierVM update)
        {
            var _response = _Tr_PlanFinancierService.Update(update);
            return new JsonResult(_response);
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _Tr_PlanFinancierService.Delete(id);
            return new JsonResult(_response);
        }
        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllSTR_Add = _Tr_PlanFinancierService.GetAll();
            return Ok(AllSTR_Add);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var add = _Tr_PlanFinancierService.GetById(id);
            return Ok(add);
        }
        [HttpGet("get/by/header/{id}")]
        public IActionResult GetByHeaderId(int id)
        {
            var add = _Tr_PlanFinancierService.GetByHeaderId(id);
            return Ok(add);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var Exchange = _Tr_PlanFinancierService.getAllByPagination(page, pageSize);
            return Ok(Exchange);
        }
    }
}
