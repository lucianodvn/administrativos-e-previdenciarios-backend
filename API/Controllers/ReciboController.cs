using Application.DTOs.Clientes;
using Application.DTOs.Recibo;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("recibo")]
    public class ReciboController : ControllerBase
    {
        private readonly IUseCaseGeneric<ReciboRequest, ReciboResponse> _useCaseGeneric;
        private readonly IUseCaseGeneric<ClienteRequest, ClienteResponse> _useCaseClienteGeneric;
        public ReciboController(IUseCaseGeneric<ReciboRequest, ReciboResponse> useCaseGeneric, IUseCaseGeneric<ClienteRequest, ClienteResponse> useCaseClienteGeneric)
        {
            _useCaseGeneric = useCaseGeneric;
            _useCaseClienteGeneric = useCaseClienteGeneric;
        }

        [HttpPost("salvar")]
        public async Task<IActionResult> SalvarRecibo([FromBody] ReciboRequest reciboRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var reciboResponse = await _useCaseGeneric.Salvar(reciboRequest);
            return Ok(reciboResponse);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarReciboPorId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Recibo inválido.");
            }
            var reciboResponse = await _useCaseGeneric.ConsultarPorId(id);
            if (reciboResponse == null)
            {
                return NotFound("Recibo não encontrado.");
            }

            if (reciboResponse.ClienteId > 0)
            {
                var clienteResponse = await _useCaseClienteGeneric.ConsultarPorId(reciboResponse.ClienteId);
                reciboResponse.ClienteResponse = clienteResponse;
            }
            return Ok(reciboResponse);
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarTodosRecibos()
        {
            var recibosResponse = await _useCaseGeneric.ConsultarTodos();
            if (recibosResponse == null || !recibosResponse.Any())
            {
                return NotFound("Nenhum recibo encontrado.");
            }

            foreach (var recibo in recibosResponse)
            {
                if (recibo.ClienteId > 0)
                {
                    var clienteResponse = await _useCaseClienteGeneric.ConsultarPorId(recibo.ClienteId);
                    recibo.ClienteResponse = clienteResponse;
                }
            }
            return Ok(recibosResponse);
        }

        [HttpPut("alterar")]
        public async Task<IActionResult> AlterarRecibo([FromBody] ReciboRequest reciboRequest)
        {
            if (reciboRequest == null)
            {
                return BadRequest("Recibo Inexistente.");
            }
            await _useCaseGeneric.Alterar(reciboRequest.Id, reciboRequest);
            return Ok();
        }

        [HttpGet("existe/{NumeroRecibo}")]
        public async Task<IActionResult> VerificarExistenciaRecibo(string NumeroRecibo)
        {
            if (string.IsNullOrWhiteSpace(NumeroRecibo))
            {
                return BadRequest("Número do Recibo inválido.");
            }
            var existe = await _useCaseGeneric.Existe(NumeroRecibo);
            return Ok(existe);
        }
    }
}
