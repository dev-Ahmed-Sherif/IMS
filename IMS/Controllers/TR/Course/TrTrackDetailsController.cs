using Business.TR.Course;
using Entities.ViewModels.TR.Course;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.TR.Course
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrTrackDetailsController : ControllerBase
    {
        private TrTrackDetailService _Service;

        public TrTrackDetailsController(TrTrackDetailService AddService)
        {
            _Service = AddService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] TrTrackDetailsGeneralVM add)
        {
            var _response = _Service.Add(add);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] TrTrackDetailsVM update)
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
        [HttpGet("get/by/header/{id}")]
        public IActionResult GetByHeader(int id)
        {
            var TrackHeader = _Service.GetByHeader(id);
            return Ok(TrackHeader);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] search searchModel)
        {
            var search = _Service.Search(searchModel);
            return Ok(search);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var Exchange = _Service.getAllByPagination(page, pageSize);
            return Ok(Exchange);
        }
    }
}
