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
                .Where(x => x.DataVencimento?.Month == DateTime.Now.Month && x.DataVencimento?.Year == DateTime.Now.Year && x.IsPago == false)
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

        [HttpGet("empresa/buscar/{id}")]
        public async Task<IActionResult> BuscarContaAPagarPorEmpresaId(int id)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando Consulta Contas a Pagar");

            var contasAPagarResponse = await _contasAPagar.ConsultarPorEmpresaId(id);
            if (contasAPagarResponse == null)
            {
                return NotFound("Nenhuma conta a pagar encontrada.");
            }
            return Ok(contasAPagarResponse);
        }

        [HttpGet("empresa/buscar/contas-ano-anterior/{id}")]
        public async Task<IActionResult> ListarContasDoAnoAnterior(int id)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando Consulta Contas a Pagar");

            var contasAPagarResponse = await _contasAPagar.ListarContasDoAnoAnterior(id);
            if (contasAPagarResponse == null)
            {
                return NotFound("Nenhuma conta a pagar encontrada.");
            }
            return Ok(contasAPagarResponse);
        }

        [HttpGet("empresa/buscarpormesano/{id}/{mes}/{ano}")]
        public async Task<IActionResult> BuscarContaAPagarPorEmpresaIdPorMesAno(int id, int mes, int ano)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando Consulta Contas a Pagar");

            if (mes > DateTime.Now.Month)
            {
                return Ok("Nenhuma conta a pagar encontrada.");
            }

            var contasAPagarResponse = await _contasAPagar.ConsultarPorEmpresaIdMesAnos(id, mes, ano);
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
                .Where(x => x.DataVencimento?.Day == DateTime.Now.Day && x.DataVencimento?.Month == DateTime.Now.Month && x.DataVencimento?.Year == DateTime.Now.Year && x.IsPago == false)
                .Any();

            return Ok(possuiContasVencendoHoje);
        }

        [HttpGet("total/{idEmpresa}/mes/{mes}")]
        public async Task<IActionResult> ObterValoresAPagar(int idEmpresa, int mes)
        {
            var username = User.FindFirst("username")?.Value;
            _logger.LogInfo($"Usuário {username}: Iniciando Obter Valores a Pagar");

            if (mes > DateTime.Now.Month)
            {
                _logger.LogInfo($"Usuário {username}: Iniciando Obter Valores a Pagar mês clicado maior que o atual.");
                return Ok(0);
            }

            try
            {
                var valorAPagar = await _contasAPagar.ObterValoresAPagar(idEmpresa, mes);
                _logger.LogInfo("Obtido Valores a Pagar");
                return Ok(valorAPagar);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao obter valores a pagar: {ex.Message}");
                return StatusCode(500, "Erro interno ao obter valores a pagar.");
            }
        }

        [HttpGet("empresa/totalpago-ano-anterior/{idEmpresa}")]
        public async Task<IActionResult> SomaTotalContasApgarAnoAnterior(int idEmpresa)
        {
            var username = User.FindFirst("username")?.Value;
            _logger.LogInfo($"Usuário {username}: Iniciando Soma Total Contas a Pagar Ano Anterior");
            try
            {
                var valorAPagar = await _contasAPagar.SomaTotalContasApgarAnoAnterior(idEmpresa);
                _logger.LogInfo("Obtido Soma Total Contas a Pagar Ano Anterior");
                return Ok(valorAPagar);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao obter soma total contas a pagar ano anterior: {ex.Message}");
                return StatusCode(500, "Erro interno ao obter soma total contas a pagar ano anterior.");
            }
        }

        [HttpGet("contas-para-migrar/{idEmpresa}/{mes}/{ano}")]
        public async Task<IActionResult> ConsultarContasAMigrar(int idEmpresa, int mes, int ano)
        {
            var username = User.FindFirst("username")?.Value;
            _logger.LogInfo($"Usuário {username}: Iniciando Consulta Contas a Migrar");

            try
            {
                var contasAMigrar = await _contasAPagar.ConsultarContasAMigrar(idEmpresa, mes, ano);
                if (contasAMigrar == null || !contasAMigrar.Any())
                {
                    _logger.LogWarn("Nenhuma conta a pagar encontrada para migrar");
                    return NotFound("Nenhuma conta a pagar encontrada para migrar.");
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
        public async Task<IActionResult> MigrarContas([FromBody] List<ContasAPagarRequest> contasAPagarRequests)
        {
            var username = User.FindFirst("username")?.Value;
            _logger.LogInfo($"Usuário {username}: Iniciando Migração Contas a Pagar");
            if (contasAPagarRequests == null || !contasAPagarRequests.Any())
            {
                _logger.LogWarn("Nenhuma conta a pagar fornecida para migração");
                return BadRequest("Nenhuma conta a pagar fornecida para migração.");
            }
            try
            {
                await _useCaseGeneric.SalvarLista(contasAPagarRequests);

                _logger.LogInfo("Migração de Contas a Pagar concluída com sucesso");
                return Ok(new { mensagem = "Migração de contas a pagar concluída com sucesso." });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao migrar contas a pagar: {ex.Message}");
                return StatusCode(500, "Erro interno ao migrar contas a pagar.");
            }
        }
    }
}
