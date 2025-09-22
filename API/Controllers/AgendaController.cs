using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("agenda")]
    public class AgendaController : ControllerBase
    {
        private readonly AgendaService _agendaService;
        public AgendaController(AgendaService agendaService)
        {
            _agendaService = agendaService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarAgenda()
        {
            var resultado = await _agendaService.ObterAgenda();
            if (resultado == null || !resultado.Any())
            {
                return NotFound("Nenhum agendamento encontrado para o mês atual.");
            }
            return Ok(resultado);
        }
    }
}
