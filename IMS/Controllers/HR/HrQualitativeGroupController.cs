using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.HR
{

    [Route("api/[controller]")]
    [ApiController]
    public class HrQualitativeGroupController : ControllerBase
    {

        private HrQualitativeGroupService _QualitativeGroupService;

        public HrQualitativeGroupController(HrQualitativeGroupService QualitativeGroupService)
        {
            _QualitativeGroupService = QualitativeGroupService;
        }

        [HttpPost("Add")]
        public IActionResult AddQualitativeGroup([FromBody] HrQualitativeGroupVM ID)
        {
            var _response = _QualitativeGroupService.Add(ID);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult UpdateQualitativeGroup([FromBody] HrQualitativeGroupVM ID)
        {
            var _response = _QualitativeGroupService.Update(ID);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteQualitativeGroup(int ID)
        {
            var _response = _QualitativeGroupService.Delete(ID);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allQualitativeGroup = _QualitativeGroupService.GetAll();
            return Ok(allQualitativeGroup);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int ID)
        {
            var QualitativeGroup = _QualitativeGroupService.GetById(ID);
            return Ok(QualitativeGroup);
        }

    }
}
