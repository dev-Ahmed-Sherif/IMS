using Business.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.STR.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class STRModelController : ControllerBase
    {
        private StrModelService _model;

        public STRModelController(StrModelService StrModelService)
        {
            _model = StrModelService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] StrModelGeneralVM model)
        {
            var _response = _model.Add(model);
            return new JsonResult(_response);
        }
        [HttpPut("update")]
        public IActionResult Update([FromBody] StrModelVM model)
        {
            var _response = _model.Update(model);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _model.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allItems = _model.GetAll();
            return Ok(allItems);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var CostCenter = _model.GetById(id);
            return Ok(CostCenter);
        }
    }
}
