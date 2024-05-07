using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.HR
{


    [Route("api/[controller]")]
    [ApiController]

    public class HrPositionController : ControllerBase
    {

        private HrPositionService _PositionService;

        public HrPositionController(HrPositionService PositionService)
        {
            _PositionService = PositionService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrPositionVM ID)
        {
            var _response = _PositionService.Add(ID);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrPositionVM ID)
        {
            var _response = _PositionService.Update(ID);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int ID)
        {
            var _response = _PositionService.Delete(ID);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allPosition = _PositionService.GetAll();
            return Ok(allPosition);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int ID)
        {
            var Position = _PositionService.GetById(ID);
            return Ok(Position);
        }

    }
}
