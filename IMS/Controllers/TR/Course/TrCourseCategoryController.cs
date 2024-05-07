using Business.TR.Course;
using Entities.ViewModels.TR.Course;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.TR.Course
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrCourseCategoryController : ControllerBase
    {
        private TrCourseCategoryService _Service;
        public TrCourseCategoryController(TrCourseCategoryService AddTrack)
        {
            _Service = AddTrack;
        }
        [HttpPost("Add")]
        public IActionResult Add([FromBody] TrCourseCategoryVM add)
        {
            var _response = _Service.Add(add);
            return new JsonResult(_response);
        }
        [HttpPut("update")]
        public IActionResult Update([FromBody] TrCourseCategoryVM update)
        {
            var _response = _Service.Update(update);
            return new JsonResult(_response);
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _Service.Delete(id);
            return new JsonResult(_response);
        }
        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllSTR_Add = _Service.GetAll();
            return Ok(AllSTR_Add);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var add = _Service.GetById(id);
            return Ok(add);
        }

    }
}
