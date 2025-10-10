using Application.DTOs.ContasAReceber;
using Application.Interfaces.UseCase;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("contas-a-receber")]
    public class ContasAReceberController : ControllerBase
    {
        private readonly IUseCaseGeneric<ContasAReceberRequest, ContasAReceberResponse> _useCaseGeneric;
        private ContasAReceberService _contasAReceberService;

        public ContasAReceberController(IUseCaseGeneric<ContasAReceberRequest, ContasAReceberResponse> useCaseGeneric, ContasAReceberService contasAReceberService)
        {
            _useCaseGeneric = useCaseGeneric;
            _contasAReceberService = contasAReceberService;
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

        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarTodasContasAReceber()
        {
            var contasAReceberResponse = await _contasAReceberService.ConsultarTodos();
            if (contasAReceberResponse == null || !contasAReceberResponse.Any())
            {
                return NotFound("Nenhuma Conta a Receber encontrada.");
            }

            var contasDoMesVigente = contasAReceberResponse
                .Where(x => x.DataVencimento.Month == DateTime.Now.Month && x.DataVencimento.Year == DateTime.Now.Year)
                .ToList();

            var totalAReceber = contasDoMesVigente.Sum(x => x.Valor);

            return Ok(new
            {
                Contas = contasDoMesVigente,
                TotalAReceber = totalAReceber
            });
        }
    }
}
