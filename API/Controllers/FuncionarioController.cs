using Application.DTOs.Clientes;
using Application.DTOs.Funcionario;
using Application.Interfaces.Logging;
using Application.Interfaces.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("funcionario")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IUseCaseGeneric<FuncionarioRequest, FuncionarioResponse> _useCaseGeneric;
        private readonly ILoggerManager _logger;
        public FuncionarioController(IUseCaseGeneric<FuncionarioRequest, FuncionarioResponse> useCaseGeneric, ILoggerManager logger)
        {
            _useCaseGeneric = useCaseGeneric;
            _logger = logger;
        }

        [HttpPost("salvar")]
        public async Task<IActionResult> SalvarFuncionario([FromBody] FuncionarioRequest funcionarioRequest)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Funcionario {username}: Iniciando SalvarFuncionario");

            if (!ModelState.IsValid)
            {
                _logger.LogWarn("ModelState inválido");
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _useCaseGeneric.Salvar(funcionarioRequest);
                _logger.LogInfo($"Funcionário {response} salvo com sucesso.");
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao salvar funcionario: {ex.Message}");
                return StatusCode(500, "Erro interno ao salvar funcionário.");
            }
        }

        [HttpPut("alterar")]
        public async Task<IActionResult> AlterarFuncionario([FromBody] FuncionarioRequest funcionarioRequest)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando alteração do Funcionario.");

            if (funcionarioRequest == null)
            {
                _logger.LogWarn("funcionarioRequest é nulo");
                return BadRequest("Funcionário Inexistente");
            }

            try
            {
                await _useCaseGeneric.Alterar(funcionarioRequest.Id, funcionarioRequest);
                _logger.LogInfo($"Funcionário Alterado com sucesso.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao alterar funcionario: {ex.Message}");
                return StatusCode(500, "Erro interno ao alterar funcionário.");
            }
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> ExcluirFuncionario(int id)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Funcionario {username}: Iniciando exclusão do Funcionario.");

            try
            {
                var response = await _useCaseGeneric.Excluir(id);
                if (!response)
                {
                    return NotFound("Erro ao Excluir Funcionário.");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao excluir funcionario: {ex.Message}");
                return StatusCode(500, "Erro interno ao excluir funcionário.");
            }
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarFuncionarioPorId(int id)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Funcionario {username}: Iniciando consulta do Funcionario.");

            try
            {
                var response = await _useCaseGeneric.ConsultarPorId(id);
                if (response == null)
                {
                    return NotFound("Erro ao Consultar Funcionário.");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar funcionario: {ex.Message}");
                return StatusCode(500, "Erro interno ao consultar funcionário.");
            }
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarTodos()
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Funcionario {username}: Iniciando consulta de todos Funcionario.");

            try
            {
                var response = await _useCaseGeneric.ConsultarTodos();
                if (response == null)
                {
                    return NotFound("Erro ao Consultar Funcionário.");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar funcionario: {ex.Message}");
                return StatusCode(500, "Erro interno ao consultar funcionário.");
            }
        }
    }
}
