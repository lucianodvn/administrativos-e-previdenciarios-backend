using Application.DTOs.TipoDeRepresentante;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("representantelegal")]
    public class ControllerRepresentanteLegal : ControllerBase
    {
       private readonly IUseCaseGeneric<RepresentanteLegalRequest, RepresentanteLegalResponse> _useCase;
        public ControllerRepresentanteLegal(IUseCaseGeneric<RepresentanteLegalRequest, RepresentanteLegalResponse> useCase)
        {
            _useCase = useCase;
        }

        [HttpPost("salvar")]
        public async Task<IActionResult> SalvarRepresentanteLegal([FromBody] RepresentanteLegalRequest request)
        {
            if (request == null)
            {
                return BadRequest("Dados inválidos.");
            }
            var response = await _useCase.Salvar(request);
            return Ok(response);
        }
        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> ConsultarPorId(int id)
        {
            var response = await _useCase.ConsultarPorId(id);
            if (response == null)
            {
                return NotFound("Representante legal não encontrado.");
            }
            return Ok(response);
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> ConsultarTodos()
        {
            var response = await _useCase.ConsultarTodos();
            if (response == null || !response.Any())
            {
                return NotFound("Nenhum representante legal não encontrado.");
            }
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Alterar(int id, [FromBody] RepresentanteLegalRequest request)
        {
            if (request == null || id != request.Id)
            {
                return BadRequest("Dados inválidos.");
            }
            await _useCase.Alterar(id, request);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var result = await _useCase.Excluir(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
