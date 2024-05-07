using Business.TR.General;
using Entities.ViewModels.TR.General;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.TR.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrBudgetController : ControllerBase
    {
        private TrBudgetService _TrBudgetService;

        public TrBudgetController(TrBudgetService TrBudgetService)
        {
            _TrBudgetService = TrBudgetService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] TrBudgetGeneralVM add)
        {
            var _response = _TrBudgetService.Add(add);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] TrBudgetVM update)
        {
            var _response = _TrBudgetService.Update(update);
            return new JsonResult(_response);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _TrBudgetService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllSTR_Add = _TrBudgetService.GetAll();
            return Ok(AllSTR_Add);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var add = _TrBudgetService.GetById(id);
            return Ok(add);
        }

    }
}
