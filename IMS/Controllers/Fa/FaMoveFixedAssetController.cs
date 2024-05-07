using Business.Fa;
using Entities.ViewModels.Fa;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.Fa
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaMoveFixedAssetController : ControllerBase
    {
        private FaMoveFixedAssetService _fa_fix;

        public FaMoveFixedAssetController(FaMoveFixedAssetService AddService)
        {
            _fa_fix = AddService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] FaMoveFixedAssetGeneralVM add)
        {
            var _response = _fa_fix.Add(add);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] FaMoveFixedAssetVM update)
        {
            var _response = _fa_fix.Update(update);
            return new JsonResult(_response);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _fa_fix.Delete(id);
            return new JsonResult(_response);
        }


        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllSTR_Add = _fa_fix.GetAll();
            return Ok(AllSTR_Add);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var add = _fa_fix.GetById(id);
            return Ok(add);
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] SearchGeneralMove searchModel)
        {
            var AllSTR_Add_Details = _fa_fix.Search(searchModel);
            return Ok(AllSTR_Add_Details);
        }
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var allItems = _fa_fix.GetAllByPagination(page, pageSize);
            return Ok(allItems);
        }
    }
}
