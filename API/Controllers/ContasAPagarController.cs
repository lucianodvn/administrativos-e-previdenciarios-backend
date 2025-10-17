using Application.DTOs.ContasAPagar;
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
        public ContasAPagarController(IUseCaseGeneric<ContasAPagarRequest, ContasAPagarResponse> useCaseGeneric, ContasAPagarService contasAPagar)
        {
            _useCaseGeneric = useCaseGeneric;
            _contasAPagar = contasAPagar;
        }

        [HttpPost("salvar")]
        public async Task<IActionResult> SalvarContaAPagar([FromBody] ContasAPagarRequest contasAPagarRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var contasAPagarResponse = await _useCaseGeneric.Salvar(contasAPagarRequest);
            return Ok(contasAPagarResponse);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarTodasContasAPagar()
        {
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
                .Where(x => x.DataVencimento.Month == DateTime.Now.Month && x.DataVencimento.Year == DateTime.Now.Year && x.IsPago == false)
                .Any();

            return Ok(possuiContasVencendoHoje);
        }

    }
}
