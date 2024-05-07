using Business.FI.Account;
using Entities.ViewModels.FI.Account;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.FI.Account
{
    [Route("api/[controller]")]
    [ApiController]

    public class FiAccountItemCategoryController : ControllerBase
    {
        private FiAccountItemCategoryService _FiAccountItemCategoryService;
        public FiAccountItemCategoryController(FiAccountItemCategoryService FiAccountItemCategoryService)
        {
            _FiAccountItemCategoryService = FiAccountItemCategoryService;
        }

        [HttpPost("Add")]
        public IActionResult AddAccount([FromBody] FiAccountItemCategoryVM id)
        {
            var _response = _FiAccountItemCategoryService.Add(id);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult UpdateAccountItem([FromBody] FiAccountItemCategoryVM id)
        {
            var _response = _FiAccountItemCategoryService.Update(id);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteAccountItem(int id)
        {
            var _response = _FiAccountItemCategoryService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAllAccountItem()
        {
            var allAccount = _FiAccountItemCategoryService.GetAll();
            return Ok(allAccount);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetAccountItemById(int id)
        {
            var Account = _FiAccountItemCategoryService.GetById(id);
            return Ok(Account);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var Pagination = _FiAccountItemCategoryService.getAllByPagination(page, pageSize);
            return Ok(Pagination);
        }
    }
}
