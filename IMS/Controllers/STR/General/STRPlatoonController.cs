using Business.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.STR.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class STRPlatoonController : ControllerBase
    {

        private StrPlatoonService _platoonsService;

        public STRPlatoonController(StrPlatoonService platoonsService)
        {
            _platoonsService = platoonsService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] StrPlatoonVM platoon)
        {
            var _response = _platoonsService.Add(platoon);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] StrPlatoonVM platoon)
        {
            var _response = _platoonsService.Update(platoon);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _platoonsService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allPlatoons = _platoonsService.GetAll();
            return Ok(allPlatoons);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var platoon = _platoonsService.GetById(id);
            return Ok(platoon);
        }

        [HttpGet("get/with/groups/{id}")]
        public IActionResult GetWithGroups(int id)
        {
            var _response = _platoonsService.GetWithGroups(id);
            return Ok(_response);
        }

        [HttpGet("AutoCode")]
        public IActionResult GetLastNo(int GradeId)
        {
            var _response = _platoonsService.GetLastNo(GradeId);
            return new JsonResult(_response);
        }

    }

}
