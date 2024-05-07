using Business.STR.Employee;
using Entities.ViewModels.STR.Employee;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.STR.Employee
{
    [Route("api/[controller]")]
    [ApiController]
    public class STREmployeeExchangeDetailsController : ControllerBase
    {
        private StrEmployeeExchangeDetailsService _Employee_Exchange_DetailsService;

        public STREmployeeExchangeDetailsController(StrEmployeeExchangeDetailsService exchdetService)
        {
            _Employee_Exchange_DetailsService = exchdetService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] StrEmployeeExchangeDetailsGeneralVM exch)
        {
            var _response = _Employee_Exchange_DetailsService.Add(exch);
            return new JsonResult(_response);
        }
        [HttpPut("update")]
        public IActionResult Update([FromBody] StrEmployeeExchangeDetailsVM exch)
        {
            var _response = _Employee_Exchange_DetailsService.Update(exch);
            return new JsonResult(_response);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteEmployeeExchange(int id)
        {
            var _response = _Employee_Exchange_DetailsService.Delete(id);
            return new JsonResult(_response);
        }
        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allEmployeeExchang = _Employee_Exchange_DetailsService.GetAll();
            return Ok(allEmployeeExchang);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var EmployeeExchange = _Employee_Exchange_DetailsService.GetById(id);
            return Ok(EmployeeExchange);
        }
        [HttpGet("get/by/header/{id}")]
        public IActionResult GetByHeader(int id)
        {
            var EmployeeExchange = _Employee_Exchange_DetailsService.GetByHeader(id);
            return Ok(EmployeeExchange);
        }
        [HttpGet("search")]
        public IActionResult searchemployeeExchangeDetails([FromQuery] searchemployeeexchange searchModel)
        {
            var resulr = _Employee_Exchange_DetailsService.search(searchModel);
            return Ok(resulr);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize, int HeaderId)
        {
            var Pagination = _Employee_Exchange_DetailsService.getAllByPagination(page, pageSize, HeaderId);
            return Ok(Pagination);
        }
    }
}
