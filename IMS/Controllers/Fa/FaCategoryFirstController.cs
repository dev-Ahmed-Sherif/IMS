using Business.Fa;
using Entities.ViewModels.Fa;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.Fa
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaCategoryFirstController : ControllerBase
    {
        private FaCategoryFirstService _fa_cat;

        public FaCategoryFirstController(FaCategoryFirstService AddService)
        {
            _fa_cat = AddService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] FaCategoryFirstGeneralVM add)
        {
            var _response = _fa_cat.Add(add);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] FaCategoryFirstVM update)
        {
            var _response = _fa_cat.Update(update);
            return new JsonResult(_response);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _fa_cat.Delete(id);
            return new JsonResult(_response);
        }


        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllSTR_Add = _fa_cat.GetAll();
            return Ok(AllSTR_Add);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var add = _fa_cat.GetById(id);
            return Ok(add);
        }
        [HttpGet("AutoCode")]
        public IActionResult GetLastNo()
        {
            var _response = _fa_cat.GetLastNo();
            return new JsonResult(_response);
        }
    }
}
