using Application.DTOs.BeneficiosServicos;
using Application.Interfaces.Logging;
using Application.Interfaces.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("beneficioservico")]
    public class BeneficioServicoController : ControllerBase
    {
        private readonly IUseCaseGeneric<BeneficiosServicosRequest, BeneficiosServicosResponse> _useCaseGeneric;
        private readonly ILoggerManager _logger;

        public BeneficioServicoController(IUseCaseGeneric<BeneficiosServicosRequest, BeneficiosServicosResponse> useCaseGeneric, ILoggerManager logger)
        {
            _useCaseGeneric = useCaseGeneric;
            _logger = logger;
        }

        [HttpPost("salvar")]
        public async Task<IActionResult> SalvarBeneficioServico([FromBody] BeneficiosServicosRequest beneficiosServicosRequest)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Salvar BeneficioServico");

            if (!ModelState.IsValid)
            {
                _logger.LogWarn("ModelState inválido");
                return BadRequest(ModelState);
            }

            try
            {
                var beneficiosServicosResponse = await _useCaseGeneric.Salvar(beneficiosServicosRequest);
                _logger.LogInfo("BeneficioServico salvo com sucesso.");
                return Ok(beneficiosServicosResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao salvar BeneficioServico: {ex.Message}");
                return StatusCode(500, "Erro interno ao salvar BeneficioServico.");
            }
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarTodosBeneficiosServicos()
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Listar BeneficioServico");

            try
            {
                var beneficiosServicosResponse = await _useCaseGeneric.ConsultarTodos();
                if (beneficiosServicosResponse == null || !beneficiosServicosResponse.Any())
                {
                    _logger.LogWarn("Nenhum benefício ou serviço encontrado.");
                    return NotFound("Nenhum benefício ou serviço encontrado.");
                }

                _logger.LogInfo($"Listar BeneficioServico: {beneficiosServicosResponse}");
                return Ok(beneficiosServicosResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao listar BeneficioServico: {ex.Message}");
                return StatusCode(500, "Erro interno ao listar BeneficioServico.");
            }

        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarBeneficioServicoPorId(int id)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Consultar BeneficioServico");

            try
            {
                var beneficiosServicosResponse = await _useCaseGeneric.ConsultarPorId(id);
                if (beneficiosServicosResponse == null)
                {
                    _logger.LogWarn("Nenhum benefício ou serviço encontrado.");
                    return NotFound("Nenhum benefício ou serviço encontrado.");
                }

                _logger.LogInfo($"BeneficioServico: {beneficiosServicosResponse}");
                return Ok(beneficiosServicosResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar BeneficioServico: {ex.Message}");
                return StatusCode(500, "Erro interno ao consultar BeneficioServico.");
            }
        }

        [HttpPut("alterar")]
        public async Task<IActionResult> AlterarBeneficioServico([FromBody] BeneficiosServicosRequest beneficiosServicosRequest)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: alterar BeneficioServico");

            if (beneficiosServicosRequest == null)
            {
                _logger.LogWarn("Benefício ou serviço inexistente.");
                return BadRequest("Benefício ou serviço inexistente.");
            }

            try
            {
                await _useCaseGeneric.Alterar(beneficiosServicosRequest.id, beneficiosServicosRequest);
                _logger.LogInfo($"Alterado BeneficioServico {beneficiosServicosRequest} com sucesso.");
                return Ok(new { mensagem = "Benefício ou serviço alterado com sucesso." });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao alterar BeneficioServico: {ex.Message}");
                return StatusCode(500, "Erro interno ao alterar BeneficioServico.");
            }

        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> ExcluirBeneficioServico(int id)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: excluir BeneficioServico");

            try
            {
                var sucesso = await _useCaseGeneric.Excluir(id);
                if (!sucesso)
                {
                    _logger.LogInfo("Nenhum benefício ou serviço encontrado.");
                    return NotFound("Nenhum benefício ou serviço encontrado.");
                }

                _logger.LogInfo("Benefício ou serviço excluído com sucesso.");
                return Ok(new { mensagem = "Benefício ou serviço excluído com sucesso." });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao excluir BeneficioServico: {ex.Message}");
                return StatusCode(500, "Erro interno ao excluir BeneficioServico.");
            }
        }
    }
}
