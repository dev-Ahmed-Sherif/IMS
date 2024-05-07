using Business.TR.General;
using Entities.ViewModels.TR.General;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.TR.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrPurposeController : ControllerBase
    {
        private TrpurposeService _TrpurposeService;

        public TrPurposeController(TrpurposeService TrpurposeService)
        {
            _TrpurposeService = TrpurposeService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] TrPurposeGeneralVM add)
        {
            var _response = _TrpurposeService.Add(add);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] TrPurposeVM update)
        {
            var _response = _TrpurposeService.Update(update);
            return new JsonResult(_response);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _TrpurposeService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllSTR_Add = _TrpurposeService.GetAll();
            return Ok(AllSTR_Add);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var add = _TrpurposeService.GetById(id);
            return Ok(add);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        //[HttpGet("get/by/pagination")]
        //public IActionResult getAllByPagination(int page, int pageSize)
        //{
        //    var Exchange = _TrpurposeService.getAllByPagination(page, pageSize);
        //    return Ok(Exchange);
        //}
    }
}
