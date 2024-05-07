using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.HR
{

    [Route("api/[controller]")]
    [ApiController]

    public class HrMillitryStateController : ControllerBase
    {

        private HrMillitryStateService _MillitryStateService;

        public HrMillitryStateController(HrMillitryStateService MillitryStateService)
        {
            _MillitryStateService = MillitryStateService;
        }

        [HttpPost("Add")]
        public IActionResult AddMillitryState([FromBody] HrMillitryStateVM ID)
        {
            var _response = _MillitryStateService.Add(ID);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult UpdateMillitryState([FromBody] HrMillitryStateVM ID)
        {
            var _response = _MillitryStateService.Update(ID);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteMillitryState(int id)
        {
            var _response = _MillitryStateService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allMillitryState = _MillitryStateService.GetAll();
            return Ok(allMillitryState);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var MillitryState = _MillitryStateService.GetById(id);
            return Ok(MillitryState);
        }

    }
}
