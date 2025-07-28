using Application.DTOs.Clientes;
using Application.DTOs.Contrato;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("contratos")]
    public class ContratoController : ControllerBase
    {

        private readonly IUseCaseGeneric<ContratoRequest, ContratoResponse> _useCaseGeneric;

        public ContratoController (IUseCaseGeneric<ContratoRequest, ContratoResponse> useCaseGeneric)
        {
            _useCaseGeneric = useCaseGeneric;
        }

        [HttpPost("salvar")]
        public async Task<IActionResult> SalvarContrato([FromBody] ContratoRequest request)
        {
            var contratoResponse = await _useCaseGeneric.Salvar(request);

            return Ok(contratoResponse);
        }

    }
}
