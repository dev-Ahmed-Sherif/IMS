using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrBankController : ControllerBase
    {
        private HrBankService _BankService;

        public HrBankController(HrBankService HrBankService)
        {
            _BankService = HrBankService;
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allBanks = _BankService.GetAll();
            return Ok(allBanks);
        }
    }
}
