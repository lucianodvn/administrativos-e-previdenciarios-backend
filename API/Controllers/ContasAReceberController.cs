using Application.DTOs.ContasAPagar;
using Application.DTOs.ContasAReceber;
using Application.Interfaces.UseCase;
using Application.Services;
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

        public ContasAReceberController(ContasAReceberService contasAReceberService, IUseCaseGeneric<ContasAReceberRequest, ContasAReceberResponse> useCaseGeneric)
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
    }
}
