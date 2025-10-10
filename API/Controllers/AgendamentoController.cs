using Application.DTOs.Agendamento;
using Application.Interfaces.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("agenda")]
    public class AgendamentoController : ControllerBase
    {
        private readonly IUseCaseGeneric<AgendamentoRequest, AgendamentoResponse> _useCaseGeneric;
        public AgendamentoController(IUseCaseGeneric<AgendamentoRequest, AgendamentoResponse> useCaseGeneric)
        {
            _useCaseGeneric = useCaseGeneric;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarAgenda()
        {
            var resultado = await _useCaseGeneric.ConsultarTodos();
            if (resultado == null || !resultado.Any())
            {
                return NotFound("Nenhum agendamento encontrado.");
            }
            return Ok(resultado.Where(x => x.IsAtendido == false).OrderBy(x => x.DataHoraDoAgendamento));
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CriarAgendamento([FromBody] AgendamentoRequest agendamentoRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var agendamentoResponse = await _useCaseGeneric.Salvar(agendamentoRequest);
            return Ok(agendamentoResponse);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> ObterAgendamentoPorId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }
            var agendamentoResponse = await _useCaseGeneric.ConsultarPorId(id);
            if (agendamentoResponse == null)
            {
                return NotFound("Agendamento não encontrado.");
            }
            return Ok(agendamentoResponse);
        }

        [HttpPut("alterar")]
        public async Task<IActionResult> AtualizarAgendamento([FromBody] AgendamentoRequest agendamentoRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _useCaseGeneric.Alterar(agendamentoRequest.Id, agendamentoRequest);
            return Ok();
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> DeletarAgendamento(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }
            var sucesso = await _useCaseGeneric.Excluir(id);
            if (!sucesso)
            {
                return NotFound("Agendamento não encontrado.");
            }
            return Ok(new { mensagem = "Agendamento excluído com sucesso." });
        }

        [HttpGet("registros")]
        public async Task<int> ConsultarQuantidadeRegistros()
        {
            var response = await _useCaseGeneric.ConsultarTodos();
            return response.Where(x => x.IsAtendido == false && x.DataHoraDoAgendamento.Date <= DateTime.Now.AddDays(3).Date).Count();
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
    }
}
