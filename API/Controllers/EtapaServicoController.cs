using Application.DTOs.EtapaServico;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("etapaservico")]
    public class EtapaServicoController : ControllerBase
    {
        private readonly IUseCaseGeneric<EtapaServicoRequest, EtapaServicoResponse> _useCaseGeneric;
        public EtapaServicoController(IUseCaseGeneric<EtapaServicoRequest, EtapaServicoResponse> useCaseGeneric)
        {
            _useCaseGeneric = useCaseGeneric;
        }

        [HttpPost("salvar")]
        public async Task<IActionResult> SalvarEtapaServico([FromBody] EtapaServicoRequest etapaServicoRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var etapaServicoResponse = await _useCaseGeneric.Salvar(etapaServicoRequest);
            return Ok(etapaServicoResponse);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarTodasEtapasServico()
        {
            var etapaServicoResponse = await _useCaseGeneric.ConsultarTodos();
            if (etapaServicoResponse == null || !etapaServicoResponse.Any())
            {
                return NotFound("Nenhuma etapa de serviço encontrada.");
            }
            return Ok(etapaServicoResponse);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarEtapaServicoPorId(int id)
        {
            var etapaServicoResponse = await _useCaseGeneric.ConsultarPorId(id);
            if (etapaServicoResponse == null)
            {
                return NotFound("Nenhuma etapa de serviço encontrada.");
            }
            return Ok(etapaServicoResponse);
        }

        [HttpPut("alterar")]
        public async Task<IActionResult> AlterarEtapaServico([FromBody] EtapaServicoRequest etapaServicoRequest)
        {
            if (etapaServicoRequest == null)
            {
                return BadRequest("Etapa de serviço inexistente");
            }
            await _useCaseGeneric.Alterar(etapaServicoRequest.id, etapaServicoRequest);
            return Ok(new { mensagem = "Etapa de serviço alterada com sucesso." });
        }

        [HttpDelete("deletar/{id}")]
        public async Task<IActionResult> DeletarEtapaServico(int id)
        {
            var etapaServicoResponse = await _useCaseGeneric.ConsultarPorId(id);
            if (etapaServicoResponse == null)
            {
                return NotFound("Nenhuma etapa de serviço encontrada.");
            }
            await _useCaseGeneric.Excluir(id);
            return Ok(new { mensagem = "Etapa de serviço deletada com sucesso." });
        }
    }
}
