using Application.DTOs.ContasAPagar;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("contas-a-pagar")]
    public class ContasAPagarController : ControllerBase
    {
        private readonly IUseCaseGeneric<ContasAPagarRequest, ContasAPagarResponse> _useCaseGeneric;
        public ContasAPagarController(IUseCaseGeneric<ContasAPagarRequest, ContasAPagarResponse> useCaseGeneric)
        {
            _useCaseGeneric = useCaseGeneric;
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
            var contasAPagarResponse = await _useCaseGeneric.ConsultarTodos();
            if (contasAPagarResponse == null || !contasAPagarResponse.Any())
            {
                return NotFound("Nenhuma conta a pagar encontrada.");
            }
            return Ok(contasAPagarResponse);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarContaAPagarPorId(int id)
        {
            var contasAPagarResponse = await _useCaseGeneric.ConsultarPorId(id);
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

        [HttpDelete("deletar/{id}")]
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
    }
}
