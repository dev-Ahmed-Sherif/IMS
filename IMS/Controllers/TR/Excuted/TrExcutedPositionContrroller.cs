using Business.TR.Excuted;
using Entities.ViewModels.TR.Excuted;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.TR.Excuted
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrExcutedPositionController : ControllerBase
    {
        private TrExcutedPositionService _sTR_AddService;

        public TrExcutedPositionController(TrExcutedPositionService AddService)
        {
            _sTR_AddService = AddService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] TrExcutedPositionGeneralVM add)
        {
            var _response = _sTR_AddService.Add(add);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] TrExcutedPositionVM update)
        {
            var _response = _sTR_AddService.Update(update);
            return new JsonResult(_response);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _sTR_AddService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllSTR_Add = _sTR_AddService.GetAll();
            return Ok(AllSTR_Add);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var add = _sTR_AddService.GetById(id);
            return Ok(add);
        }
        [HttpGet("get/By/Header/{id}")]
        public IActionResult getByHeader(int id)
        {
            var CostCenter = _sTR_AddService.GetByHeaderId(id);
            return Ok(CostCenter);
        }
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var allItems = _sTR_AddService.GetAllByPagination(page, pageSize);
            return Ok(allItems);
        }
    }
}
