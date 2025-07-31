using Application.DTOs.Clientes;
using Application.DTOs.Usuarios;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUseCaseGeneric<UsuarioRequest, UsuarioResponse> _useCaseGeneric;

        public UsuarioController(IUseCaseGeneric<UsuarioRequest, UsuarioResponse> useCaseGeneric)
        {
            _useCaseGeneric = useCaseGeneric;
        }

        [HttpPost("salvar")]
        public async Task<IActionResult> SalvarCliente([FromBody] UsuarioRequest usuarioRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuarioResponse = await _useCaseGeneric.Salvar(usuarioRequest);
            return Ok(usuarioResponse);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarTodosUsuarios()
        {
            var usuarioResponse = await _useCaseGeneric.ConsultarTodos();
            if (usuarioResponse == null || !usuarioResponse.Any())
            {
                return NotFound("Nenhum usuário encontrado.");
            }
            return Ok(usuarioResponse);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarUsuarioPorId(int id)
        {
            var usuarioResponse = await _useCaseGeneric.ConsultarPorId(id);
            if (usuarioResponse == null)
            {
                return NotFound("Nenhum usuário encontrado.");
            }
            return Ok(usuarioResponse);

        }

        [HttpPut("alterar")]
        public async Task<IActionResult> AlterarUsuario([FromBody] UsuarioRequest usuarioRequest)
        {
            if(usuarioRequest == null)
            {
                return BadRequest("Usuário Inexistente");
            }

            await _useCaseGeneric.Alterar(usuarioRequest.Id, usuarioRequest);
            return Ok();
        }

        [HttpDelete("excluir")]
        public async Task<IActionResult> ExcluirUsuario(int id)
        {
            var usuarioResponse = await _useCaseGeneric.Excluir(id);
            return Ok(usuarioResponse);
        }
    }
}
