using Business.PY;
using Entities.ViewModels.PY;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.PY
{
    [Route("api/[controller]")]
    [ApiController]
    public class PyInstallmentController : ControllerBase
    {

        private PyInstallmentService _InstallmentService;

        public PyInstallmentController(PyInstallmentService InstallmentService)
        {
            _InstallmentService = InstallmentService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] PyInstallmentVM Installment)
        {
            var _response = _InstallmentService.Add(Installment);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] PyInstallmentVM Installment)
        {
            var _response = _InstallmentService.Update(Installment);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _InstallmentService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allInstallment = _InstallmentService.GetAll();
            return Ok(allInstallment);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var Installment = _InstallmentService.GetById(id);
            return Ok(Installment);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var Installment = _InstallmentService.GetAllByPagination(page, pageSize);
            return Ok(Installment);
        }

    }
}
