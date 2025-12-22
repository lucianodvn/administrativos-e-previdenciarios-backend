using Application.DTOs.Agendamento;
using Application.DTOs.FornecedorEmpresa;
using Application.Interfaces.Logging;
using Application.Interfaces.UseCase;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("fornecedorEmpresa")]
    public class FornecedorEmpresaController : ControllerBase
    {
        private readonly IUseCaseGeneric<FornecedorEmpresaRequest, FornecedorEmpresaResponse> _useCaseGeneric;
        private FornecedorEmpresaService _fornecedorEmpresaService;
        private readonly ILoggerManager _logger;
        public FornecedorEmpresaController(IUseCaseGeneric<FornecedorEmpresaRequest, FornecedorEmpresaResponse> useCaseGeneric, ILoggerManager logger, FornecedorEmpresaService fornecedorEmpresaService)
        {
            _useCaseGeneric = useCaseGeneric;
            _logger = logger;
            _fornecedorEmpresaService = fornecedorEmpresaService;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarFornecedor()
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando Consulta da Fornecedor Empresa");

            try
            {
                var resultado = await _fornecedorEmpresaService.ConsultarTodos();
                if (resultado == null || !resultado.Any())
                {
                    _logger.LogInfo("Nenhum Fornecedor Empresa encontrado.");
                    return NotFound("Nenhum Fornecedor Empresa encontrado.");
                }
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar Fornecedor Empresa: {ex.Message}");
                return StatusCode(500, "Erro interno ao consultar Fornecedor Empresa.");
            }
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CriarFornecedor([FromBody] FornecedorEmpresaRequest request)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando Consulta do Fornecedor Empresa");

            if (!ModelState.IsValid)
            {
                _logger.LogWarn("ModelState inválido");
                return BadRequest(ModelState);
            }

            try
            {
                var agendamentoResponse = await _useCaseGeneric.Salvar(request);
                _logger.LogInfo($"Fornecedor Empresa salva com sucesso.");
                return Ok(agendamentoResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao salvar Fornecedor Empresa: {ex.Message}");
                return StatusCode(500, "Erro interno ao salvar Fornecedor Empresa.");
            }
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> ObterFornecedorPorId(int id)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando Consulta do Fornecedor Empresa");

            if (id <= 0)
            {
                _logger.LogWarn("ID inválido");
                return BadRequest("ID inválido.");
            }

            try
            {
                var agendamentoResponse = await _fornecedorEmpresaService.ConsultarPorId(id);
                if (agendamentoResponse == null)
                {
                    _logger.LogInfo("Fornecedor Empresa não encontrado.");
                    return NotFound("Fornecedor Empresa não encontrado.");
                }
                return Ok(agendamentoResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar Fornecedor Empresa: {ex.Message}");
                return StatusCode(500, "Erro interno ao consultar Fornecedor Empresa.");
            }
        }

        [HttpPut("alterar")]
        public async Task<IActionResult> AtualizarFornecedor([FromBody] FornecedorEmpresaRequest request)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando alterar Fornecedor Empresa");

            if (!ModelState.IsValid)
            {
                _logger.LogWarn("ModelState inválido");
                return BadRequest(ModelState);
            }

            try
            {
                await _useCaseGeneric.Alterar(request.Id, request);
                _logger.LogInfo($"Fornecedor Empresa {request} alterada com sucesso.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao alterar agenda: {ex.Message}");
                return StatusCode(500, "Erro interno ao alterar agenda.");
            }
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> DeletarFornecedor(int id)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando exclusão do Fornecedor Empresa");

            if (id <= 0)
            {
                _logger.LogWarn("ID inválido");
                return BadRequest("ID inválido.");
            }
            try
            {
                var sucesso = await _useCaseGeneric.Excluir(id);
                if (!sucesso)
                {
                    _logger.LogInfo("Fornecedor Empresa não encontrado.");
                    return NotFound("Fornecedor Empresa não encontrado.");
                }
                return Ok(new { mensagem = "Fornecedor Empresa excluído com sucesso." });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao excluir Fornecedor Empresa: {ex.Message}");
                return StatusCode(500, "Erro interno ao excluir Fornecedor Empresa.");
            }
        }

        [HttpGet("consultar-por-empresa/{idEmpresa}")]
        public async Task<IActionResult> ConsultarPorEmpresaId(int idEmpresa)
        {
            var username = User.FindFirst("username")?.Value;
            _logger.LogInfo($"Usuário {username}: Iniciando Consulta do Fornecedor Empresa por Empresa ID");
            if (idEmpresa <= 0)
            {
                _logger.LogWarn("ID da Empresa inválido");
                return BadRequest("ID da Empresa inválido.");
            }
            try
            {
                var resultado = await _fornecedorEmpresaService.ConsultarPorEmpresaId(idEmpresa);
                if (resultado == null || !resultado.Any())
                {
                    _logger.LogInfo("Nenhum Fornecedor Empresa encontrado para a Empresa especificada.");
                    return NotFound("Nenhum Fornecedor Empresa encontrado para a Empresa especificada.");
                }
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar Fornecedor Empresa por Empresa ID: {ex.Message}");
                return StatusCode(500, "Erro interno ao consultar Fornecedor Empresa por Empresa ID.");
            }
        }
    }
}
