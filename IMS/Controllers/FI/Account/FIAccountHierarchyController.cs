using Business.FI.Account;
using Entities.ViewModels.FI.Account;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.FI.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class FIAccountHierarchyController : ControllerBase
    {
        private FiAccountHierarchyService _FiAccountHierarchyService;
        public FIAccountHierarchyController(FiAccountHierarchyService FiAccountHierarchyService)
        {
            _FiAccountHierarchyService = FiAccountHierarchyService;
        }

        [HttpPost("Add")]
        public IActionResult AddAccount([FromBody] FiAccountHierarchyVM AccountHierarchy)
        {
            var _response = _FiAccountHierarchyService.Add(AccountHierarchy);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult UpdateAccountHierarchy([FromBody] FiAccountHierarchyVM Account)
        {
            var _response = _FiAccountHierarchyService.Update(Account);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteAccountHierarchy(int id)
        {
            var _response = _FiAccountHierarchyService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAllAccountHierarchy()
        {
            var allAccount = _FiAccountHierarchyService.GetAll();
            return Ok(allAccount);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetAccountHierarchyById(int id)
        {
            var Account = _FiAccountHierarchyService.GetById(id);
            return Ok(Account);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var Pagination = _FiAccountHierarchyService.getAllByPagination(page, pageSize);
            return Ok(Pagination);
        }
    }
}
