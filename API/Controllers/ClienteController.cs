using Application.DTOs.Clientes;
using Application.Interfaces;
using Application.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IUseCaseGeneric<ClienteRequest, ClienteResponse> _useCaseGeneric;

        public ClienteController(IUseCaseGeneric<ClienteRequest, ClienteResponse> useCaseGeneric)
        {
            _useCaseGeneric = useCaseGeneric;
        }

        [HttpPost("salvar")]
        public async Task<IActionResult> SalvarCliente([FromBody]ClienteRequest clienteRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                
            var clienteResponse = await _useCaseGeneric.Salvar(clienteRequest);
            return Ok(clienteResponse);
        }

    }
}
