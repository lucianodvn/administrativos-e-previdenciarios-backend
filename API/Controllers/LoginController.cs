using Application.DTOs.Login;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("acesso")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest dto)
        {
            var token = await _loginService.Login(dto);
            return Ok(token);
        }
    }
}
