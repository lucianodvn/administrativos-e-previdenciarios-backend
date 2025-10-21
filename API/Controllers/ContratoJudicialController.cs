using Application.DTOs.Contrato;
using Application.Interfaces.UseCase;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("contrato-judicial")]
    public class ContratoJudicialController : ControllerBase
    {
        private readonly IUseCaseGeneric<ContratoJudicialRequest, ContratoJudicialResponse> _useCaseGeneric;
        private ContratoJudicialService _contratoJudicialService;

        public ContratoJudicialController(IUseCaseGeneric<ContratoJudicialRequest, ContratoJudicialResponse> useCaseGeneric, ContratoJudicialService contratoJudicialService)
        {
            _useCaseGeneric = useCaseGeneric;
            _contratoJudicialService = contratoJudicialService;
        }

        [HttpPost("salvar")]
        public async Task<IActionResult> SalvarContrato([FromBody] ContratoJudicialRequest request)
        {
            var contratoResponse = await _useCaseGeneric.Salvar(request);

            return Ok(contratoResponse);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarContratos()
        {
            var contratos = await _contratoJudicialService.ConsultarTodos();
            if (contratos == null)
            {
                return NotFound("Nenhum contrato encontrado.");
            }
            return Ok(contratos);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarContratoPorId(int id)
        {
            var contrato = await _contratoJudicialService.ConsultarPorId(id);
            if (contrato == null)
            {
                return NotFound("Nenhum contrato encontrado.");
            }
            return Ok(contrato);
        }

        [HttpDelete("deletar/{id}")]
        public async Task<IActionResult> DeletarContrato(int id)
        {
            var contrato = await _useCaseGeneric.Excluir(id);
            if (contrato == null)
            {
                return NotFound("Nenhum contrato encontrado.");
            }
            return Ok(contrato);
        }

        [HttpPut("alterar")]
        public async Task<IActionResult> AtualizarContrato([FromBody] ContratoJudicialRequest request)
        {
            if (request == null)
            {
                return BadRequest("Contrato Inexistente");
            }

            await _useCaseGeneric.Alterar(request.Id, request);
            return Ok(new { mensagem = "Contrato Salvo com sucesso." });
        }

        [HttpPut("atualizar-contrato")]
        public async Task<IActionResult> AtualizarSomenteNecessario([FromBody] ContratoJudicialRequest request)
        {
            if (request == null)
            {
                return BadRequest("Contrato Inexistente");
            }

            await _useCaseGeneric.AlterarSomenteNecessario(request, request.Id);
            return Ok(new { mensagem = "Contrato Salvo com sucesso." });
        }
    }
}
