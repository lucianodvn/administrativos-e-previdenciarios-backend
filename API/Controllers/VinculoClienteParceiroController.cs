using Application.DTOs.VinculoClienteParceiro;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("vinculo-cliente-parceiro")]
    public class VinculoClienteParceiroController : ControllerBase
    {
        private readonly IUseCaseGeneric<VinculoClienteParceiroRequest, VinculoClienteParceiroResponse> _useCaseGeneric;
        private VinculoClienteParceiroService _service;

        public VinculoClienteParceiroController(IUseCaseGeneric<VinculoClienteParceiroRequest, VinculoClienteParceiroResponse> useCaseGeneric,
            VinculoClienteParceiroService service)
        {
            _useCaseGeneric = useCaseGeneric;
            _service = service;
        }

        [HttpPost("salvar")]
        public async Task<IActionResult> Salvar([FromBody] VinculoClienteParceiroRequest request)
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
            var response = await _service.ConsultarPorId(id);
            if (response == null)
            {
                return NotFound("Nenhum vinculo encontrado.");
            }
            return Ok(response);
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarTodos()
        {
            var response = await _service.ConsultarTodos();
            if (response == null || !response.Any())
            {
                return NotFound("Nenhum vinculo encontrado.");
            }
            return Ok(response);
        }

        [HttpPut("alterar")]
        public async Task<IActionResult> AlterarCliente([FromBody] VinculoClienteParceiroRequest request)
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
