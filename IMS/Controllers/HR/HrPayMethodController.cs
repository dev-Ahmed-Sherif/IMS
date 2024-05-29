using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrPayMethodController : ControllerBase
    {
    
        private HrPayMethodService _HrPayMethodService;

        public HrPayMethodController(HrPayMethodService HrPayMethodService)
        {
            _HrPayMethodService = HrPayMethodService;
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allBanks = _HrPayMethodService.GetAll();
            return Ok(allBanks);
        }
    }
}
