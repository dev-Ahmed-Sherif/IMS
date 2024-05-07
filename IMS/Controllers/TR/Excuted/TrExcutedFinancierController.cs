using Business.TR.Excuted;
using Entities.ViewModels.TR.Excuted;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.TR.Excuted
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrExcutedFinancierController : ControllerBase
    {
        private TrExcutedFinancierService _TrExcutedService;

        public TrExcutedFinancierController(TrExcutedFinancierService TrExcutedService)
        {
            _TrExcutedService = TrExcutedService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] TrExcutedFinancierGeneralVM add)
        {
            var _response = _TrExcutedService.Add(add);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] TrExcutedFinancierVM update)
        {
            var _response = _TrExcutedService.Update(update);
            return new JsonResult(_response);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _TrExcutedService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllSTR_Add = _TrExcutedService.GetAll();
            return Ok(AllSTR_Add);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var add = _TrExcutedService.GetById(id);
            return Ok(add);
        }
    }
}
