using Business.HR;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HrDisciplinaryController : ControllerBase
    {

        private HrDisciplinaryService _DisciplinaryService;

        public HrDisciplinaryController(HrDisciplinaryService DisciplinaryService)
        {
            _DisciplinaryService = DisciplinaryService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrDisciplinaryVM Disciplinary)
        {
            var _response = _DisciplinaryService.Add(Disciplinary);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrDisciplinaryVM Disciplinary)
        {
            var _response = _DisciplinaryService.Update(Disciplinary);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _DisciplinaryService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allDisciplinary = _DisciplinaryService.GetAll();
            return Ok(allDisciplinary);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var Disciplinary = _DisciplinaryService.GetById(id);
            return Ok(Disciplinary);
        }

    }
}
