using Application.DTOs.Clientes;
using Application.DTOs.VinculoClienteBeneficioEtapa;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("vincular-cliente-beneficio-etapa")]
    public class VincularClienteBeneficioEtapaController : ControllerBase
    {
        private readonly IUseCaseGeneric<VinculoClienteBeneficioEtapaRequest, VinculoClienteBeneficioEtapaResponse> _useCaseGeneric;
        private VinculoClienteService _vinculoClienteService;

        public VincularClienteBeneficioEtapaController(IUseCaseGeneric<VinculoClienteBeneficioEtapaRequest, 
            VinculoClienteBeneficioEtapaResponse> useCaseGeneric,
            VinculoClienteService vinculoClienteService)
        {
            _useCaseGeneric = useCaseGeneric;
            _vinculoClienteService = vinculoClienteService;
        }

        [HttpPost("salvar")]
        public async Task<IActionResult> Salvar([FromBody] VinculoClienteBeneficioEtapaRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _useCaseGeneric.Salvar(request);
            return Ok(response);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }
            var response = await _vinculoClienteService.ConsultarPorId(id);
            if (response == null)
            {
                return NotFound("Nenhum vinculo encontrado.");
            }
            return Ok(response);
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarTodos()
        {
            var response = await _vinculoClienteService.ConsultarTodos();
            if (response == null || !response.Any())
            {
                return NotFound("Nenhum vinculo encontrado.");
            }
            return Ok(response);
        }

        [HttpPut("alterar")]
        public async Task<IActionResult> AlterarCliente([FromBody] VinculoClienteBeneficioEtapaRequest request)
        {
            if (request == null)
            {
                return BadRequest("Nenhum vinculo existente");
            }

            await _useCaseGeneric.Alterar(request.Id, request);
            return Ok();

        }
    }
    
}
