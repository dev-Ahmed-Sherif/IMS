using Business.TR.General;
using Entities.ViewModels.TR.General;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.TR.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrCoporteClientController : ControllerBase
    {
        private TrCoporateClientService _Service;

        public TrCoporteClientController(TrCoporateClientService AddService)
        {
            _Service = AddService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] TrCorporateCLientGeneralVM add)
        {
            var _response = _Service.Add(add);
            return new JsonResult(_response);
        }



        [HttpPut("update")]
        public IActionResult Update([FromBody] TrCorporateCLientVM update)
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
