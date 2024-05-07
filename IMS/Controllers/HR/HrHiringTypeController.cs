using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.HR
{


    [Route("api/[controller]")]
    [ApiController]

    public class HrHiringTypeController : ControllerBase
    {

        private HrHiringTypeService _HiringTypeService;

        public HrHiringTypeController(HrHiringTypeService HiringTypeService)
        {
            _HiringTypeService = HiringTypeService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrHiringTypeVM ID)
        {
            var _response = _HiringTypeService.Add(ID);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrHiringTypeVM ID)
        {
            var _response = _HiringTypeService.Update(ID);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _HiringTypeService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAllHiringType()
        {
            var allHiringType = _HiringTypeService.GetAll();
            return Ok(allHiringType);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetHiringTypeById(int ID)
        {
            var HiringType = _HiringTypeService.GetById(ID);
            return Ok(HiringType);
        }

    }
}
