using Business.SE;
using Entities.ViewModels.SE;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.Controllers.SE
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImsSectionController : ControllerBase
    {
        private readonly ImsSectionService _imsSectionService;
        public ImsSectionController(ImsSectionService imsSectionService)
        {
            _imsSectionService = imsSectionService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ImsSectionGeneralVM>))]
        public async Task<ActionResult<List<ImsSectionGeneralVM>>> GetAllAsync()
        {
            return await _imsSectionService.GetAllAsync();
        }
    }
}
