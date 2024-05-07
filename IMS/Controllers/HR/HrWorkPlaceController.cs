using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrWorkPlaceController : ControllerBase
    {

        private HrWorkPlaceService _WorkPlaceService;

        public HrWorkPlaceController(HrWorkPlaceService WorkPlaceService)
        {
            _WorkPlaceService = WorkPlaceService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrWorkPlaceVM ID)
        {
            var _response = _WorkPlaceService.Add(ID);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrWorkPlaceVM ID)
        {
            var _response = _WorkPlaceService.Update(ID);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteWorkPlace(int ID)
        {
            var _response = _WorkPlaceService.Delete(ID);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allWorkPlace = _WorkPlaceService.GetAll();
            return Ok(allWorkPlace);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int ID)
        {
            var WorkPlaceService = _WorkPlaceService.GetById(ID);
            return Ok(WorkPlaceService);
        }

    }
}
