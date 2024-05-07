using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.HR
{


    [Route("api/[controller]")]
    [ApiController]

    public class HrJobTitleController : ControllerBase
    {

        private HrJobTitleService _JobTitleService;

        public HrJobTitleController(HrJobTitleService JobTitleService)
        {
            _JobTitleService = JobTitleService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrJobTitleVM ID)
        {
            var _response = _JobTitleService.Add(ID);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrJobTitleVM ID)
        {
            var _response = _JobTitleService.Update(ID);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{ID}")]
        public IActionResult Delete(int ID)
        {
            var _response = _JobTitleService.Delete(ID);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allJobTitle = _JobTitleService.GetAll();
            return Ok(allJobTitle);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int ID)
        {
            var JobTitle = _JobTitleService.GetById(ID);
            return Ok(JobTitle);
        }

    }
}
