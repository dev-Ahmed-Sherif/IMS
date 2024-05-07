using Business.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.STR.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class STRUnitController : ControllerBase
    {

        private StrUnitService _unitService;

        public STRUnitController(StrUnitService unitService)
        {
            _unitService = unitService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] StrUnitVM unit)
        {
            var _response = _unitService.Add(unit);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] StrUnitVM unit)
        {
            var _response = _unitService.Update(unit);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            string _response = _unitService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allUnit = _unitService.GetAll();
            return Ok(allUnit);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var unit = _unitService.GetById(id);
            return Ok(unit);
        }
    }

}
