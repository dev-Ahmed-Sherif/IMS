using Business.Pro;
using Entities.ViewModels.Pro;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.Pro
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProTenderController : ControllerBase
    {
        private ProTenderService _pro;

        public ProTenderController(ProTenderService AddService)
        {
            _pro = AddService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] ProTenderGeneralVM add)
        {
            var _response = _pro.Add(add);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] ProTenderVM update)
        {
            var _response = _pro.Update(update);
            return new JsonResult(_response);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _pro.Delete(id);
            return new JsonResult(_response);
        }


        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllSTR_Add = _pro.GetAll();
            return Ok(AllSTR_Add);
        }
        [HttpGet("get/{id}")]

        public IActionResult GetById(int id)
        {
            var add = _pro.GetById(id);
            return Ok(add);

        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] ProSearchGeneral searchModel)
        {
            var AllSTR_Add_Details = _pro.Search(searchModel);
            return Ok(AllSTR_Add_Details);
        }
        [HttpGet("AutoCode")]
        public IActionResult GetLastNo()
        {
            var _response = _pro.GetLastNo();
            return new JsonResult(_response);
        }
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var Pagination = _pro.getAllByPagination(page, pageSize);
            return Ok(Pagination);
        }
    }
}
