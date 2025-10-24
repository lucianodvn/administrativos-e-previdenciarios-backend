using Application.DTOs.ContasAPagar;
using Application.Interfaces.Logging;
using Application.Interfaces.UseCase;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("contas-a-pagar")]
    public class ContasAPagarController : ControllerBase
    {
        private readonly IUseCaseGeneric<ContasAPagarRequest, ContasAPagarResponse> _useCaseGeneric;
        private ContasAPagarService _contasAPagar;
        private readonly ILoggerManager _logger;
        public ContasAPagarController(IUseCaseGeneric<ContasAPagarRequest, ContasAPagarResponse> useCaseGeneric, ContasAPagarService contasAPagar, ILoggerManager logger)
        {
            _useCaseGeneric = useCaseGeneric;
            _contasAPagar = contasAPagar;
            _logger = logger;
        }

        [HttpPost("salvar")]
        public async Task<IActionResult> SalvarContaAPagar([FromBody] ContasAPagarRequest contasAPagarRequest)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando Salvar Contas a Pagar");

            if (!ModelState.IsValid)
            {
                _logger.LogWarn("ModelState inválido");
                return BadRequest(ModelState);
            }

            try
            {
                var contasAPagarResponse = await _useCaseGeneric.Salvar(contasAPagarRequest);
                _logger.LogInfo("Salvo Contas a Pagar");
                return Ok(contasAPagarResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao Salvo Contas a Pagar: {ex.Message}");
                return StatusCode(500, "Erro interno ao Salvar Contas a Pagar.");
            }
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarTodasContasAPagar()
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando Listar Contas a Pagar");

            var contasAPagarResponse = await _contasAPagar.ConsultarTodos();
            if (contasAPagarResponse == null || !contasAPagarResponse.Any())
            {
                return NotFound("Nenhuma conta a pagar encontrada.");
            }

            var contasDoMesVigente = contasAPagarResponse
                .Where(x => x.DataVencimento.Month == DateTime.Now.Month && x.DataVencimento.Year == DateTime.Now.Year && !x.IsPago)
                .ToList();

            return Ok(contasDoMesVigente);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarContaAPagarPorId(int id)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando Consulta Contas a Pagar");

            var contasAPagarResponse = await _contasAPagar.ConsultarPorId(id);
            if (contasAPagarResponse == null)
            {
                return NotFound("Nenhuma conta a pagar encontrada.");
            }
            return Ok(contasAPagarResponse);
        }

        [HttpPut("alterar")]
        public async Task<IActionResult> AlterarContaAPagar([FromBody] ContasAPagarRequest contasAPagarRequest)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando Alteração Contas a Pagar");

            if (contasAPagarRequest == null)
            {
                return BadRequest("Conta a pagar inexistente");
            }
            await _useCaseGeneric.Alterar(contasAPagarRequest.Id, contasAPagarRequest);
            return Ok(new { mensagem = "Conta a pagar alterada com sucesso." });
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> DeletarContaAPagar(int id)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando Exclusão Contas a Pagar");

            var contasAPagarResponse = await _useCaseGeneric.ConsultarPorId(id);
            if (contasAPagarResponse == null)
            {
                return NotFound("Nenhuma conta a pagar encontrada.");
            }
            await _useCaseGeneric.Excluir(id);
            return Ok(new { mensagem = "Conta a pagar excluída com sucesso." });
        }

        [HttpGet("contas-vencendo-hoje")]
        public async Task<IActionResult> VerficarContasVenceHoje()
        {
            var contasAPagarResponse = await _contasAPagar.ConsultarTodos();
            if (contasAPagarResponse == null || !contasAPagarResponse.Any())
            {
                return NotFound("Nenhuma conta a pagar encontrada.");
            }

            var possuiContasVencendoHoje = contasAPagarResponse
                .Where(x => x.DataVencimento.Day == DateTime.Now.Day && x.DataVencimento.Month == DateTime.Now.Month && x.DataVencimento.Year == DateTime.Now.Year && x.IsPago == false)
                .Any();

            return Ok(possuiContasVencendoHoje);
        }

    }
}
