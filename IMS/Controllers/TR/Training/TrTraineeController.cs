using Business.TR.Training;
using Entities.ViewModels.TR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.TR.Training
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrTraineeController : ControllerBase
    {
        private TrTraineeService _Service;

        public TrTraineeController(TrTraineeService TraineeService)
        {
            _Service = TraineeService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] TrTraineeVM add)
        {
            var _response = _Service.Add(add);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] TrTraineeVM update)
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
