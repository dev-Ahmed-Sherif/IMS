using Business.STR.Employee;
using Entities.ViewModels.STR.Employee;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.STR.Employee
{
    [Route("api/[controller]")]
    [ApiController]
    public class STREmployeeOpeningCustodyDetailsController : ControllerBase
    {
        private StrEmployeeOpeningCustodyDetailsService _Employee_Opening_CustodyDetailsService;

        public STREmployeeOpeningCustodyDetailsController(StrEmployeeOpeningCustodyDetailsService Employee_Opening_CustodyDetailsService)
        {
            _Employee_Opening_CustodyDetailsService = Employee_Opening_CustodyDetailsService;
        }
        [HttpPost("Add")]
        public IActionResult Add([FromBody] StrEmployeeOpeningCustodyDetailsVM add)
        {
            var _response = _Employee_Opening_CustodyDetailsService.Add(add);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] StrEmployeeOpeningCustodyDetailsVM update)
        {
            var _response = _Employee_Opening_CustodyDetailsService.Update(update);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _Employee_Opening_CustodyDetailsService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllCustodyDetails = _Employee_Opening_CustodyDetailsService.GetAll();
            return Ok(AllCustodyDetails);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var getById = _Employee_Opening_CustodyDetailsService.GetById(id);
            return Ok(getById);
        }

        [HttpGet("search")]
        public IActionResult search([FromQuery] searchemployeeopeningcustody searchModel)
        {
            var AllSTR_Add_Details = _Employee_Opening_CustodyDetailsService.search(searchModel);
            return Ok(AllSTR_Add_Details);
        }
        [HttpGet("get/by/header/{id}")]
        public IActionResult GetByHeader(int id)
        {
            var AllSTR_Add_Details = _Employee_Opening_CustodyDetailsService.GetByHeader(id);
            return Ok(AllSTR_Add_Details);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize, int HeaderId)
        {
            var Pagination = _Employee_Opening_CustodyDetailsService.getAllByPagination(page, pageSize, HeaderId);
            return Ok(Pagination);
        }
    }
}
