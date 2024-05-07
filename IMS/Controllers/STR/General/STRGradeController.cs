using Business.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.STR.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class STRGradeController : ControllerBase
    {

        private StrGradeService _gradesService;

        public STRGradeController(StrGradeService gradesService)
        {
            _gradesService = gradesService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] StrGradeVM grade)
        {
            var _response = _gradesService.Add(grade);
            return new JsonResult(_response);
        }


        [HttpPut("update")]
        public IActionResult Update([FromBody] StrGradeVM grade)
        {
            var _response = _gradesService.Update(grade);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _gradesService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allGrades = _gradesService.GetAll();
            return Ok(allGrades);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var grade = _gradesService.GetById(id);
            return Ok(grade);
        }

        [HttpGet("get/with/Platoon/{id}")]
        public IActionResult GetWithPlatoons(int id)
        {
            var _response = _gradesService.GetWithPlatoons(id);
            return Ok(_response);
        }
        [HttpGet("AutoCode")]
        public IActionResult GetLastNo(int commidtyId)
        {
            var _response = _gradesService.GetLastNo(commidtyId);
            return new JsonResult(_response);
        }
    }

}
