using Application.DTOs.Clientes;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost("salvar")]
        public async Task<IActionResult> SalvarCliente([FromBody]ClienteRequest clienteRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                
            var clienteResponse = await _clienteService.SalvarAsync(clienteRequest);
            return Ok(clienteResponse);
        }

    }
}
