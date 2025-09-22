using Application.DTOs.Login;
using Application.DTOs.Usuarios;
using Application.Interfaces;
using Application.Services;
using Application.UseCases;
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
        public async Task<IActionResult> LoginAsync(LoginRequest dto)
        {
            var token = await _loginService.Login(dto);
            return Ok(token);
        }
    }
}
