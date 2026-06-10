using Application.DTOs.ControleDePonto;
using Application.DTOs.Funcionario;
using Application.Interfaces.Logging;
using Application.Interfaces.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("controle-de-ponto")]
    public class ControleDePontoController : ControllerBase
    {
        private readonly IUseCaseGeneric<ControleDePontoRequest, ControleDePontoResponse> _useCaseGeneric;
        private readonly ILoggerManager _logger;
        public ControleDePontoController(IUseCaseGeneric<ControleDePontoRequest, ControleDePontoResponse> useCaseGeneric, ILoggerManager logger)
        {
            _useCaseGeneric = useCaseGeneric;
            _logger = logger;
        }

        [HttpPost("salvar")]
        public async Task<IActionResult> SalvarControleDePonto([FromBody] ControleDePontoRequest controleDePontoRequest)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Controle de Ponto {username}: Iniciando Controle de Ponto");

            if (!ModelState.IsValid)
            {
                _logger.LogWarn("ModelState inválido");
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _useCaseGeneric.Salvar(controleDePontoRequest);
                _logger.LogInfo($"Controle de Ponto {response} salvo com sucesso.");
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao salvar controle de ponto: {ex.Message}");
                return StatusCode(500, "Erro interno ao salvar controle de ponto.");
            }
        }

        [HttpPut("alterar")]
        public async Task<IActionResult> AlterarControleDePonto([FromBody] ControleDePontoRequest controleDePontoRequest)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando alteração do controle de ponto.");

            if (controleDePontoRequest == null)
            {
                _logger.LogWarn("controle de ponto é nulo");
                return BadRequest("Controle de Ponto Inexistente");
            }

            try
            {
                await _useCaseGeneric.Alterar(controleDePontoRequest.Id, controleDePontoRequest);
                _logger.LogInfo($"Controle de Ponto Alterado com sucesso.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao alterar controle de ponto: {ex.Message}");
                return StatusCode(500, "Erro interno ao alterar controle de ponto.");
            }
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> ExcluirControleDePonto(int id)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Controle de Ponto {username}: Iniciando exclusão do Controle de Ponto.");

            try
            {
                var response = await _useCaseGeneric.Excluir(id);
                if (!response)
                {
                    return NotFound("Erro ao Excluir Controle de Ponto.");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao excluir controle de ponto: {ex.Message}");
                return StatusCode(500, "Erro interno ao excluir controle de ponto.");
            }
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarControleDePontoPorId(int id)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Controle de Ponto {username}: Iniciando consulta do Controle de Ponto.");

            try
            {
                var response = await _useCaseGeneric.ConsultarPorId(id);
                if (response == null)
                {
                    return NotFound("Erro ao Consultar Controle de Ponto.");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar controle de ponto: {ex.Message}");
                return StatusCode(500, "Erro interno ao consultar controle de ponto.");
            }
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarTodos()
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Controle de Ponto {username}: Iniciando consulta de todos Controle de Ponto.");

            try
            {
                var response = await _useCaseGeneric.ConsultarTodos();
                if (response == null)
                {
                    return NotFound("Erro ao Consultar Controle de Ponto.");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar controle de ponto: {ex.Message}");
                return StatusCode(500, "Erro interno ao consultar controle de ponto.");
            }
        }
    }
}

