using Business.FI.General;
using Entities.ViewModels.FI.General;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.FI.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiJournalTypeController : ControllerBase
    {
        private FiJournalTypeService _item;

        public FiJournalTypeController(FiJournalTypeService FiJournalTypeService)
        {
            _item = FiJournalTypeService;
        }

        [HttpGet("get/all")]
        public IActionResult GetAllItem()
        {
            var allItems = _item.GetAll();
            return Ok(allItems);
        }
    }
}
