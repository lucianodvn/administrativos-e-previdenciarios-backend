using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EnderecoExternoController : ControllerBase
    {
        private readonly ConsultarEnderecoExternoUseCase _consultarEnderecoExternoUseCase;
        public EnderecoExternoController(ConsultarEnderecoExternoUseCase consultarEnderecoExternoUseCase)
        {
            _consultarEnderecoExternoUseCase = consultarEnderecoExternoUseCase;
        }

        [HttpGet("consultar-cep/{cep}")]
        public async Task<IActionResult> ConsultarCep(string cep)
        {
            try
            {
                var endereco = await _consultarEnderecoExternoUseCase.ConsultarCepAsync(cep);
                if (endereco == null)
                {
                    return NotFound("CEP não encontrado.");
                }
                return Ok(endereco);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno do servidor: " + ex.Message);
            }
        }
    }
}
