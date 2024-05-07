using Business.STR.StoreOpen;
using Entities.ViewModels.STR.StoreOpen;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.STR.StoreOpen
{
    [Route("api/[controller]")]
    [ApiController]
    public class StrUserStoreController : ControllerBase
    {
        private StrUserStoreService _UserStoreService;

        public StrUserStoreController(StrUserStoreService storeService)
        {
            _UserStoreService = storeService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] StrUserStoreGeneralVM store)
        {
            var _response = _UserStoreService.Add(store);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] StrUserStoreVM store)
        {
            var _response = _UserStoreService.Update(store);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _UserStoreService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allStore = _UserStoreService.GetAll();
            return Ok(allStore);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var store = _UserStoreService.GetById(id);
            return Ok(store);
        }
        [HttpGet("get/User/Store/{Userid}")]
        public IActionResult GetByUser(int Userid)
        {
            var store = _UserStoreService.GetByUser(Userid);
            return Ok(store);
        }

    }
}
