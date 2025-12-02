using Application.DTOs.Clientes;
using Application.Interfaces.Logging;
using Application.Interfaces.UseCase;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IUseCaseGeneric<ClienteRequest, ClienteResponse> _useCaseGeneric;
        private readonly ILoggerManager _logger;
        private readonly ClienteService _clienteService;

        public ClienteController(IUseCaseGeneric<ClienteRequest, ClienteResponse> useCaseGeneric, ILoggerManager logger, ClienteService clienteService)
        {
            _useCaseGeneric = useCaseGeneric;
            _logger = logger;
            _clienteService = clienteService;
        }

        [HttpPost("salvar")]
        public async Task<IActionResult> SalvarCliente([FromBody] ClienteRequest clienteRequest)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando SalvarCliente");

            if (!ModelState.IsValid)
            {
                _logger.LogWarn("ModelState inválido");
                return BadRequest(ModelState);
            }

            try
            {
                var clienteResponse = await _useCaseGeneric.Salvar(clienteRequest);
                _logger.LogInfo($"Cliente {clienteResponse} salvo com sucesso.");
                return Ok(clienteResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao salvar cliente: {ex.Message}");
                return StatusCode(500, "Erro interno ao salvar cliente.");
            }
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarClientePorId(int id)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando Consulta do Cliente: {id}.");

            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }

            try
            {
                var clienteResponse = await _clienteService.ConsultarPorId(id);
                if (clienteResponse == null)
                {
                    _logger.LogWarn($"Cliente com {id} não encontrado.");
                    return NotFound("Cliente não encontrado.");
                }

                _logger.LogInfo($"Consulta do Cliente: {id}: {clienteResponse}");
                return Ok(clienteResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar cliente: {ex.Message}");
                return StatusCode(500, "Erro interno ao consultar cliente.");
            }
        }

        [HttpGet("buscarpornome")]
        public async Task<IActionResult> BuscarClientePorNome(string nome)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando Consulta do Cliente: {nome}.");

            if (string.IsNullOrEmpty(nome))
            {
                return BadRequest("nome inválido.");
            }

            try
            {
                var clienteResponse = await _clienteService.ConsultarPorNome(nome);
                if (clienteResponse == null)
                {
                    _logger.LogWarn($"Cliente com {nome} não encontrado.");
                    return NotFound("Cliente não encontrado.");
                }

                _logger.LogInfo($"Consulta do Cliente: {nome}: {clienteResponse}");
                return Ok(clienteResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar cliente: {ex.Message}");
                return StatusCode(500, "Erro interno ao consultar cliente.");
            }
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarTodosClientes()
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando Consulta do Cliente.");

            try
            {
                var clientesResponse = await _clienteService.ConsultarTodos();
                if (clientesResponse == null || !clientesResponse.Any())
                {
                    _logger.LogWarn("ModelState cliente inválido");
                    return NotFound("Nenhum cliente encontrado.");
                }

                _logger.LogInfo($"Retorno da consulta de clientes: {clientesResponse}");
                return Ok(clientesResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar cliente: {ex.Message}");
                return StatusCode(500, "Erro interno ao consultar cliente.");
            }
        }

        [HttpPut("alterar")]
        public async Task<IActionResult> AlterarCliente([FromBody] ClienteRequest clienteRequest)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando alteração do Cliente.");

            if (clienteRequest == null)
            {
                _logger.LogWarn("clienteRequest é nulo");
                return BadRequest("Cliente Inexistente");
            }

            try
            {
                await _useCaseGeneric.Alterar(clienteRequest.Id, clienteRequest);
                _logger.LogInfo($"Cliente Alterado com sucesso.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao alterar cliente: {ex.Message}");
                return StatusCode(500, "Erro interno ao alterar cliente.");
            }
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> ExcluirClinte(int id)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando exclusão do Cliente.");

            try
            {
                var response = await _useCaseGeneric.Excluir(id);
                if (!response)
                {
                    return NotFound("Erro ao Excluir Cliente.");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao excluir cliente: {ex.Message}");
                return StatusCode(500, "Erro interno ao excluir cliente.");
            }
        }
    }
}
