using Library_API.BLL.Interfaces;
using Library_API.BLL.Services;
using Library_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library_API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IUserService userService; 

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            string token = await userService.Authenticate(loginModel.Username, loginModel.Password);

            if(token == null)
            {
                return Unauthorized();
            }

            return Ok(new { Token = token }); 
        }
    }
}
