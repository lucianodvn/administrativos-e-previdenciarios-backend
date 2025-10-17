using Application.DTOs.Clientes;
using Application.Interfaces.UseCase;
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
        public async Task<IActionResult> SalvarCliente([FromBody] ClienteRequest clienteRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clienteResponse = await _useCaseGeneric.Salvar(clienteRequest);
            return Ok(clienteResponse);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarClientePorId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }
            var clienteResponse = await _useCaseGeneric.ConsultarPorId(id);
            if (clienteResponse == null)
            {
                return NotFound("Cliente não encontrado.");
            }
            return Ok(clienteResponse);
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarTodosClientes()
        {
            var clientesResponse = await _useCaseGeneric.ConsultarTodos();
            if (clientesResponse == null || !clientesResponse.Any())
            {
                return NotFound("Nenhum cliente encontrado.");
            }
            return Ok(clientesResponse);
        }

        [HttpPut("alterar")]
        public async Task<IActionResult> AlterarCliente([FromBody] ClienteRequest clienteRequest)
        {
            if (clienteRequest == null)
            {
                return BadRequest("Cliente Inexistente");
            }

            await _useCaseGeneric.Alterar(clienteRequest.Id, clienteRequest);
            return Ok();
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> ExcluirClinte(int id)
        {
            var response = await _useCaseGeneric.Excluir(id);
            if (!response)
            {
                return NotFound("Erro ao Excluir Cliente.");
            }

            return Ok(response);
        }
    }
}
