using Business.PR;
using Entities.ViewModels.PR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private PrUserService _usersService;
        private IConfiguration _config;
        public LoginController(PrUserService usersService, IConfiguration config)
        {
            _usersService = usersService;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Authentication([FromBody] UserLogin userLogin)
        {
            var _response = await _usersService.authentication(userLogin);
            if (_response != null)
                return new JsonResult(_response);
            return Unauthorized();
        }

        [HttpGet("get/fisical/year")]
        public IActionResult GetFiscalYear(string fiscalyear)
        {

            var allReceipt = _usersService.GetFiscalYear(fiscalyear);
            return Ok(allReceipt);
        }
        //[AllowAnonymous]
        //[HttpPost("login")]
        //public IActionResult Login([FromBody] UserLogin userLogin)
        //{
        //    var user = Authenticate(userLogin);

        //    if (user != (null, null, null))
        //    {
        //        var token = Generate(user.Item1,user.Item2,user.Item3);
        //        return Ok(token);
        //    }

        //    return NotFound("مستخدم غير موجود");
        //}

        //private string Generate(PrUserVM user, List<int> Modules, List<int> roles)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //    var claims = new[]
        //    {
        //        //new Claim(ClaimTypes.NameIdentifier, user.Name),
        //        new Claim("Username", user.Name),
        //        new Claim("Modules", string.Join(",", Modules.Select(r => r.ToString()))),
        //        new Claim("Roles", string.Join(",", roles.Select(r => r.ToString())))
        //    };

        //    var token = new JwtSecurityToken(_config["JwtSettings:ValidIssuer"],
        //    _config["JwtSettings:ValidAudience"],
        //      claims,
        //      expires: DateTime.Now.AddMinutes(180),
        //      signingCredentials: credentials);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}

        //private (PrUserVM, List<int>, List<int>) Authenticate(UserLogin userLogin)
        //{
        //    var currentUser = _usersService.Auth(userLogin.Username, userLogin.Password);

        //    if (currentUser != (null, null, null))
        //    {
        //        return (currentUser.Item1, currentUser.Item2, currentUser.Item3);
        //    }

        //    return (null, null, null);
        //}
    }
}