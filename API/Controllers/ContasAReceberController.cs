using Application.DTOs.ContasAPagar;
using Application.DTOs.ContasAReceber;
using Application.Interfaces.Logging;
using Application.Interfaces.UseCase;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("contas-a-receber")]
    public class ContasAReceberController : ControllerBase
    {
        private readonly IUseCaseGeneric<ContasAReceberRequest, ContasAReceberResponse> _useCaseGeneric;
        private ContasAReceberService _contasAReceberService;
        private readonly ILoggerManager _logger;

        public ContasAReceberController(ContasAReceberService contasAReceberService, IUseCaseGeneric<ContasAReceberRequest, ContasAReceberResponse> useCaseGeneric, ILoggerManager logger)
        {
            _useCaseGeneric = useCaseGeneric;
            _contasAReceberService = contasAReceberService;
            _logger = logger;
        }

        [HttpPut("alterar")]
        public async Task<IActionResult> AlterarContasAReceber([FromBody] ContasAReceberRequest contasAReceberRequest)
        {
            if (contasAReceberRequest == null)
            {
                return BadRequest("Conta a Receber Inexistente.");
            }
            await _useCaseGeneric.Alterar(contasAReceberRequest.Id, contasAReceberRequest);
            return Ok();
        }

        [HttpPost("salvar")]
        public async Task<IActionResult> SalvarContasAReceber([FromBody] ContasAReceberRequest contasAReceberRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var contasAReceberResponse = await _useCaseGeneric.Salvar(contasAReceberRequest);
            return Ok(contasAReceberResponse);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarContasAReceberPorId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Conta a Receber inválida.");
            }
            var contasAReceberResponse = await _contasAReceberService.ConsultarPorId(id);
            if (contasAReceberResponse == null)
            {
                return NotFound("Conta a Receber não encontrada.");
            }
            return Ok(contasAReceberResponse);
        }

        [HttpGet("buscar-cliente/{id}")]
        public async Task<IActionResult> BuscarContasAReceberPorIdCliente(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Conta a Receber inválida.");
            }
            var contasAReceberResponse = await _contasAReceberService.ConsultarPorIdCliente(id);
            if (contasAReceberResponse == null)
            {
                return NotFound("Conta a Receber não encontrada.");
            }
            return Ok(contasAReceberResponse);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> BuscarTodasContasAReceber()
        {
            var contasAReceberResponse = await _contasAReceberService.ConsultarTodos();
            if (contasAReceberResponse == null)
            {
                return NotFound("Nenhuma Conta a Receber encontrada.");
            }

            return Ok(contasAReceberResponse);
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> ExcluirContasAReceber(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }
            await _useCaseGeneric.Excluir(id);
            return Ok();
        }

        [HttpPost("salvar-lista")]
        public async Task<IActionResult> SalvarListaContasAReceber([FromBody] List<ContasAReceberRequest> contasAReceberRequest)
        {
            if (contasAReceberRequest == null || !contasAReceberRequest.Any())
            {
                return BadRequest("Lista de Contas a Receber inválida.");
            }
            await _contasAReceberService.SalvarTodos(contasAReceberRequest);
            return Ok();
        }

        [HttpGet("buscar-por-tipo/{tipo}")]
        public async Task<IActionResult> BuscarContasAReceberPorTipo(int tipo)
        {
            var contasAReceberResponse = await _contasAReceberService.ConsultarPorTipoAsync(tipo);
            if (contasAReceberResponse == null)
            {
                return NotFound("Nenhuma Conta a Receber encontrada para o tipo especificado.");
            }
            return Ok(contasAReceberResponse);
        }

        [HttpGet("somatotal")]
        public async Task<IActionResult> SomarTotalContasAReceber()
        {
            var total = await _contasAReceberService.SomaTotalAReceber();
            return Ok(total);
        }

        [HttpGet("valor-recebido-mes-atual")]
        public async Task<IActionResult> ValorRecebidoNoMesAtual()
        {
            var valor = await _contasAReceberService.ValorRecebidoNoMesAtual();
            return Ok(valor);
        }

        [HttpGet("contas-para-migrar/{idEmpresa}/{mes}/{ano}")]
        public async Task<IActionResult> ConsultarContasAMigrar(int idEmpresa, int mes, int ano)
        {
            var username = User.FindFirst("username")?.Value;
            _logger.LogInfo($"Usuário {username}: Iniciando Consulta Contas a Migrar");

            try
            {
                var contasAMigrar = await _contasAReceberService.ConsultarContasAMigrar(idEmpresa, mes, ano);
                if (contasAMigrar == null || !contasAMigrar.Any())
                {
                    _logger.LogWarn("Nenhuma conta a receber encontrada para migrar");
                    return NotFound("Nenhuma conta a receber encontrada para migrar.");
                }
                _logger.LogInfo("Obtido Contas a Migrar");
                return Ok(contasAMigrar);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar contas a migrar: {ex.Message}");
                return StatusCode(500, "Erro interno ao consultar contas a migrar.");
            }
        }

        [HttpPost("migrar-contas")]
        public async Task<IActionResult> MigrarContas([FromBody] List<ContasAReceberRequest> contasAReceberRequest)
        {
            var username = User.FindFirst("username")?.Value;
            _logger.LogInfo($"Usuário {username}: Iniciando Migração de Contas a Receber");
            if (contasAReceberRequest == null || !contasAReceberRequest.Any())
            {
                _logger.LogWarn("Lista de contas a receber para migração é inválida");
                return BadRequest("Lista de contas a receber para migração é inválida.");
            }
            try
            {
                await _contasAReceberService.SalvarTodos(contasAReceberRequest);
                _logger.LogInfo("Migração de Contas a Receber concluída com sucesso");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao migrar contas a receber: {ex.Message}");
                return StatusCode(500, "Erro interno ao migrar contas a receber.");
            }
        }
    }
}
