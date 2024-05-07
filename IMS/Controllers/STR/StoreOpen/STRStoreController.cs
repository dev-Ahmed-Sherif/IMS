using Business.STR.Add;
using Business.STR.StoreOpen;
using Entities.Models.STR.StoreOpen;
using Entities.ViewModels.STR.StoreOpen;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace IMS.Controllers.STR.StoreOpen
{
    [Route("api/[controller]")]
    [ApiController]
    public class STRStoreController : ControllerBase
    {

        private StrStoreService _storeService;

        public STRStoreController(StrStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] StrStoreVM store)
        {
            var _response = _storeService.Add(store);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] StrStoreVM store)
        {
            var _response = _storeService.Update(store);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _storeService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allStore = _storeService.GetAll();
            return Ok(allStore);
        }
    
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var store = _storeService.GetById(id);
            return Ok(store);
        }
        [HttpGet("AutoCode/{sectionId}")]
        public IActionResult GetLastNo(int sectionId)
        {
            var _response = _storeService.GetLastNo(sectionId);
            return new JsonResult(_response);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] StoreSearch search)
        {
            var Add = _storeService.Search(search);
            return Ok(Add);
        }
    }

}
