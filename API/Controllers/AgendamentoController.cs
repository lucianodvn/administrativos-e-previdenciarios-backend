using Application.DTOs.Agendamento;
using Application.Interfaces.Logging;
using Application.Interfaces.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("agenda")]
    public class AgendamentoController : ControllerBase
    {
        private readonly IUseCaseGeneric<AgendamentoRequest, AgendamentoResponse> _useCaseGeneric;
        private readonly ILoggerManager _logger;
        public AgendamentoController(IUseCaseGeneric<AgendamentoRequest, AgendamentoResponse> useCaseGeneric, ILoggerManager logger)
        {
            _useCaseGeneric = useCaseGeneric;
            _logger = logger;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarAgenda()
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando Consulta da Agenda");

            try
            {
                var resultado = await _useCaseGeneric.ConsultarTodos();
                if (resultado == null || !resultado.Any())
                {
                    _logger.LogInfo("Nenhum agendamento encontrado.");
                    return NotFound("Nenhum agendamento encontrado.");
                }
                return Ok(resultado.OrderBy(x => x.DataHoraDoAgendamento));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar agenda: {ex.Message}");
                return StatusCode(500, "Erro interno ao consultar agenda.");
            }
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CriarAgendamento([FromBody] AgendamentoRequest agendamentoRequest)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando Consulta da Agenda");

            if (!ModelState.IsValid)
            {
                _logger.LogWarn("ModelState inválido");
                return BadRequest(ModelState);
            }

            try
            {
                var agendamentoResponse = await _useCaseGeneric.Salvar(agendamentoRequest);
                _logger.LogInfo($"Agenda salva com sucesso.");
                return Ok(agendamentoResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao salvar agenda: {ex.Message}");
                return StatusCode(500, "Erro interno ao salvar agenda.");
            }
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> ObterAgendamentoPorId(int id)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando Consulta da Agenda");

            if (id <= 0)
            {
                _logger.LogWarn("ID inválido");
                return BadRequest("ID inválido.");
            }

            try
            {
                var agendamentoResponse = await _useCaseGeneric.ConsultarPorId(id);
                if (agendamentoResponse == null)
                {
                    _logger.LogInfo("Agendamento não encontrado.");
                    return NotFound("Agendamento não encontrado.");
                }
                return Ok(agendamentoResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar agenda: {ex.Message}");
                return StatusCode(500, "Erro interno ao consultar agenda.");
            }
        }

        [HttpPut("alterar")]
        public async Task<IActionResult> AtualizarAgendamento([FromBody] AgendamentoRequest agendamentoRequest)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando alterar a Agenda");

            if (!ModelState.IsValid)
            {
                _logger.LogWarn("ModelState inválido");
                return BadRequest(ModelState);
            }

            try
            {
                await _useCaseGeneric.Alterar(agendamentoRequest.Id, agendamentoRequest);
                _logger.LogInfo($"Agenda {agendamentoRequest} alterada com sucesso.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao alterar agenda: {ex.Message}");
                return StatusCode(500, "Erro interno ao alterar agenda.");
            }
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> DeletarAgendamento(int id)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando exclusão da Agenda");

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
                    _logger.LogInfo("Agendamento não encontrado.");
                    return NotFound("Agendamento não encontrado.");
                }
                return Ok(new { mensagem = "Agendamento excluído com sucesso." });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao excluir agenda: {ex.Message}");
                return StatusCode(500, "Erro interno ao excluir agenda.");
            }
        }

        [HttpGet("registros")]
        public async Task<int> ConsultarQuantidadeRegistros()
        {
            try
            {
                var response = await _useCaseGeneric.ConsultarTodos();
                return response.Where(x => x.IsAtendido == false && x.DataHoraDoAgendamento.Date <= DateTime.Now.AddDays(3).Date).Count();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao excluir agenda: {ex.Message}");
                throw new ApplicationException(ex.Message);
            }
        }

        [HttpGet("consultaragendamento")]
        public async Task<JsonResult> ConsultarAgendamento()
        {
            var response = await _useCaseGeneric.ConsultarTodos();
            var diaAtual = response.Any(r => r.DataHoraDoAgendamento.Date == DateTime.Now.Date && r.IsAtendido == false);
            var umDiaAposDiaAtual = response.Any(r => r.DataHoraDoAgendamento.Date == DateTime.Now.AddDays(1).Date && r.IsAtendido == false);
            var doisDiasAposDiaAtual = response.Any(r => r.DataHoraDoAgendamento.Date == DateTime.Now.AddDays(2).Date && r.IsAtendido == false);
            var tresDiasAposDiaAtual = response.Any(r => r.DataHoraDoAgendamento.Date == DateTime.Now.AddDays(3).Date && r.IsAtendido == false);

            string resultado;
            switch (true)
            {
                case true when diaAtual:
                    resultado = "hoje";
                    break;
                case true when umDiaAposDiaAtual:
                    resultado = "amanha";
                    break;
                case true when doisDiasAposDiaAtual:
                    resultado = "em2dias";
                    break;
                case true when tresDiasAposDiaAtual:
                    resultado = "em3dias";
                    break;
                default:
                    resultado = "semagendamentosproximos";
                    break;
            }
            return new JsonResult(resultado);
        }

        [HttpGet("buscarpornome")]
        public async Task<IActionResult> ObterAgendamentoPorNome([FromQuery] string nome)
        {
            var username = User.FindFirst("username")?.Value;

            _logger.LogInfo($"Usuário {username}: Iniciando Consulta da Agenda");

            if (string.IsNullOrEmpty(nome))
            {
                _logger.LogWarn("Nome inválido");
                return BadRequest("Nome inválido.");
            }

            try
            {
                var agendamentoResponse = await _useCaseGeneric.ConsultarPorNome(nome);
                if (agendamentoResponse == null)
                {
                    _logger.LogInfo("Agendamento não encontrado.");
                    return NotFound("Agendamento não encontrado.");
                }
                return Ok(agendamentoResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao consultar agenda: {ex.Message}");
                return StatusCode(500, "Erro interno ao consultar agenda.");
            }
        }
    }
}
