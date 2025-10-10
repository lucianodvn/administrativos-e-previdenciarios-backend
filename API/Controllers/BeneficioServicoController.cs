using Application.DTOs.BeneficiosServicos;
using Application.Interfaces.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("beneficioservico")]
    public class BeneficioServicoController : ControllerBase
    {
        private readonly IUseCaseGeneric<BeneficiosServicosRequest, BeneficiosServicosResponse> _useCaseGeneric;

        public BeneficioServicoController(IUseCaseGeneric<BeneficiosServicosRequest, BeneficiosServicosResponse> useCaseGeneric)
        {
            _useCaseGeneric = useCaseGeneric;
        }

        [HttpPost("salvar")]
        public async Task<IActionResult> SalvarBeneficioServico([FromBody] BeneficiosServicosRequest beneficiosServicosRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var beneficiosServicosResponse = await _useCaseGeneric.Salvar(beneficiosServicosRequest);
            return Ok(beneficiosServicosResponse);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarTodosBeneficiosServicos()
        {
            var beneficiosServicosResponse = await _useCaseGeneric.ConsultarTodos();
            if (beneficiosServicosResponse == null || !beneficiosServicosResponse.Any())
            {
                return NotFound("Nenhum benefício ou serviço encontrado.");
            }
            return Ok(beneficiosServicosResponse);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarBeneficioServicoPorId(int id)
        {
            var beneficiosServicosResponse = await _useCaseGeneric.ConsultarPorId(id);
            if (beneficiosServicosResponse == null)
            {
                return NotFound("Nenhum benefício ou serviço encontrado.");
            }
            return Ok(beneficiosServicosResponse);
        }

        [HttpPut("alterar")]
        public async Task<IActionResult> AlterarBeneficioServico([FromBody] BeneficiosServicosRequest beneficiosServicosRequest)
        {
            if (beneficiosServicosRequest == null)
            {
                return BadRequest("Benefício ou serviço inexistente");
            }
            await _useCaseGeneric.Alterar(beneficiosServicosRequest.id, beneficiosServicosRequest);
            return Ok(new { mensagem = "Benefício ou serviço alterado com sucesso." });
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> ExcluirBeneficioServico(int id)
        {
            var sucesso = await _useCaseGeneric.Excluir(id);
            if (!sucesso)
            {
                return NotFound("Nenhum benefício ou serviço encontrado.");
            }
            return Ok(new { mensagem = "Benefício ou serviço excluído com sucesso." });
        }
    }
}
