using Business.STR.Product;
using Entities.ViewModels.STR.Product;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.STR.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class STRProductSerialController : ControllerBase
    {
        private StrProductSerialService _sTR_Productserial;
        public STRProductSerialController(StrProductSerialService AddService)
        {
            _sTR_Productserial = AddService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] StrProductSerialGeneralVM add)
        {
            var _response = _sTR_Productserial.Add(add);
            return new JsonResult(_response);
        }


        [HttpPut("update")]
        public IActionResult Update([FromBody] StrProductSerialVM update)
        {
            var _response = _sTR_Productserial.Update(update);
            return new JsonResult(_response);
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _sTR_Productserial.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllSTR_Add = _sTR_Productserial.GetAll();
            return Ok(AllSTR_Add);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var add = _sTR_Productserial.GetById(id);
            return Ok(add);
        }
    }
}
