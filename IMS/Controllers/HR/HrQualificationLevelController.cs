using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.HR
{

    [Route("api/[controller]")]
    [ApiController]
    public class HrQualificationLevelController : ControllerBase
    {

        private HrQualificationLevelService _QualificationLevelService;

        public HrQualificationLevelController(HrQualificationLevelService QualificationLevelService)
        {
            _QualificationLevelService = QualificationLevelService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrQualificationLevelVM ID)
        {
            var _response = _QualificationLevelService.Add(ID);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrQualificationLevelVM ID)
        {
            var _response = _QualificationLevelService.Update(ID);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int ID)
        {
            var _response = _QualificationLevelService.Delete(ID);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allQualificationLevel = _QualificationLevelService.GetAll();
            return Ok(allQualificationLevel);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int ID)
        {
            var QualificationLevel = _QualificationLevelService.GetById(ID);
            return Ok(QualificationLevel);
        }

    }
}
