using Application.DTOs.Login;
using Application.DTOs.Usuarios;
using Application.Interfaces;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginUseCase _loginUseCase;

        public LoginController(ILoginUseCase loginUseCase)
        {
            _loginUseCase = loginUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Usuario) || string.IsNullOrEmpty(loginRequest.SenhaDoUsuario))
            {
                return BadRequest("Usuário e senha são obrigatórios.");
            }
               
            var usuario = await _loginUseCase.ConsultarLogin(loginRequest);

            if (usuario == null)
            {
                return Unauthorized("Usuário ou senha inválidos.");
            }
                
            return Ok(usuario);
        }
    }
}
