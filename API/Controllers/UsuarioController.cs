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
    }
}
