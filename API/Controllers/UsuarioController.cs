using Application.DTOs.Login;
using Application.DTOs.Usuarios;
using Application.Interfaces.UseCase;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUseCaseGeneric<UsuarioRequest, UsuarioResponse> _useCaseGeneric;
        private LoginService _loginService;
        private UsuarioService _usuarioService;

        public UsuarioController(IUseCaseGeneric<UsuarioRequest, UsuarioResponse> useCaseGeneric, LoginService loginService, UsuarioService usuarioService)
        {
            _useCaseGeneric = useCaseGeneric;
            _loginService = loginService;
            _usuarioService = usuarioService;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastraUsuario
            (UsuarioRequest dto)
        {
            await _usuarioService.CadastraUsuario(dto);
            return Ok(new { mensagem = "Usuário cadastrado!" });

        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginRequest dto)
        {
            var token = await _loginService.Login(dto);
            return Ok(token);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarTodosUsuarios()
        {
            var usuarioResponse = await _usuarioService.ConsultaTodosUsuarios();
            if (usuarioResponse == null || !usuarioResponse.Any())
            {
                return NotFound("Nenhum usuário encontrado.");
            }
            return Ok(usuarioResponse);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarUsuarioPorId(Guid id)
        {
            var usuarioResponse = await _usuarioService.ConsultarPorId(id);
            if (usuarioResponse == null)
            {
                return NotFound("Nenhum usuário encontrado.");
            }
            return Ok(usuarioResponse);

        }

        [HttpPut("alterar")]
        public async Task<IActionResult> AlterarUsuario([FromBody] UsuarioRequest usuarioRequest)
        {
            if (usuarioRequest == null)
            {
                return BadRequest("Usuário Inexistente");
            }

            await _usuarioService.AlterarUsuario(usuarioRequest);
            return Ok();
        }

        [HttpDelete("excluir")]
        public async Task<IActionResult> ExcluirUsuario(Guid id)
        {
            try
            {
                await _usuarioService.ExcluirUsuario(id);
                return Ok(new { mensagem = "Usuário excluído com sucesso!" });
            }
            catch (ApplicationException ex)
            {
                return NotFound(new { mensagem = "Erro ao excluir Usuário!" });
            }
        }
    }
}
