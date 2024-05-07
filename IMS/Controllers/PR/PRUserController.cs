using Business.PR;
using Entities.ViewModels;
using Entities.ViewModels.PR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IMS.Controllers.PR
{
    [Route("api/[controller]")]
    [ApiController]
    public class PRUserController : ControllerBase
    {
        private PrUserService _usersService;
        public PRUserController(PrUserService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("Add")]
        public IActionResult AddUser([FromBody] PrUserVM user)
        {
            var _response = _usersService.Add(user);
            return new JsonResult(_response);
        }


        [HttpPut("update")]
        public IActionResult UpdateUser([FromBody] PrUserVM User)
        {
            var _response = _usersService.Update(User);
            return new JsonResult(_response);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var _response = _usersService.Delete(id);
            return new JsonResult(_response);
        }
        //[Authorize(Roles = "المستخدمين")]
        [HttpGet("get/all")]
        public IActionResult GetAllUsers([FromQuery]UserFilter filter)
        {
            var allUsers = _usersService.GetAll(filter);
            return Ok(allUsers);
        }

        [HttpGet("get/ByPagination")]
        [ProducesResponseType(200, Type = typeof(PaginatedResult<PrUserVM>))]
        public IActionResult GetAllPaginated(int pageIndex, int PageSize, [FromQuery] UserFilter filter)
        {
            var result = _usersService.GetAllPaginated(pageIndex, PageSize, filter);
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetUserById(int id)
        {
            var _response = _usersService.GetById(id);
            return Ok(_response);
        }

        [HttpGet("get/with/group/{id}")]
        public IActionResult Get_User_With_Groups(int id)
        {
            var _response = _usersService.GetUserGroup(id);
            return Ok(_response);
        }

    }
}
