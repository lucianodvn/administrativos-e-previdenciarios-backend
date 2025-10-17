using Application.DTOs.Contrato;
using Application.Interfaces.UseCase;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("contratos")]
    public class ContratoController : ControllerBase
    {
        private readonly IUseCaseGeneric<ContratoRequest, ContratoResponse> _useCaseGeneric;
        private ContratoService _contratoService;

        public ContratoController(IUseCaseGeneric<ContratoRequest, ContratoResponse> useCaseGeneric, ContratoService contratoService)
        {
            _useCaseGeneric = useCaseGeneric;
            _contratoService = contratoService;
        }

        [HttpPost("salvar")]
        public async Task<IActionResult> SalvarContrato([FromBody] ContratoRequest request)
        {
            var contratoResponse = await _useCaseGeneric.Salvar(request);
            contratoResponse.DataCriacao = DateTime.Now;

            return Ok(contratoResponse);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarContratos()
        {
            var contratos = await _contratoService.ConsultarTodos();
            return Ok(contratos);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarContratoPorId(int id)
        {
            var contrato = await _contratoService.ConsultarPorId(id);
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
        public async Task<IActionResult> AtualizarContrato([FromBody] ContratoRequest request)
        {
            if (request == null)
            {
                return BadRequest("Contrato Inexistente");
            }

            await _useCaseGeneric.Alterar(request.Id, request);
            return Ok(new { mensagem = "Contrato Salvo com sucesso." });
        }

        [HttpPut("atualizar-contrato")]
        public async Task<IActionResult> AtualizarSomenteNecessario([FromBody] ContratoRequest request)
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
