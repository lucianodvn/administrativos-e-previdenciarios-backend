using Application.DTOs.Parceiro;
using Application.DTOs.Usuarios;
using Application.Interfaces.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("parceiro")]
    public class ParceiroController : ControllerBase
    {
        private readonly IUseCaseGeneric<ParceiroRequest, ParceiroResponse> _useCaseGeneric;

        public ParceiroController(IUseCaseGeneric<ParceiroRequest, ParceiroResponse> useCaseGeneric)
        {
            _useCaseGeneric = useCaseGeneric;
        }

        [HttpPost("salvar")]
        public async Task<IActionResult> SalvarParceiro([FromBody] ParceiroRequest parceiroRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var parceiroResponse = await _useCaseGeneric.Salvar(parceiroRequest);
            return Ok(parceiroResponse);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarTodosParceiros()
        {
            var parceiroResponse = await _useCaseGeneric.ConsultarTodos();
            if (parceiroResponse == null || !parceiroResponse.Any())
            {
                return NotFound("Nenhum parceiro encontrado.");
            }
            return Ok(parceiroResponse);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarParceiroPorId(int id)
        {
            var parceiroResponse = await _useCaseGeneric.ConsultarPorId(id);
            if (parceiroResponse == null)
            {
                return NotFound("Nenhum parceiro encontrado.");
            }
            return Ok(parceiroResponse);
        }

        [HttpPut("alterar")]
        public async Task<IActionResult> AlterarParceiro([FromBody] ParceiroRequest parceiroRequest)
        {
            if (parceiroRequest == null)
            {
                return BadRequest("Parceiro Inexistente");
            }
            await _useCaseGeneric.Alterar(parceiroRequest.Id, parceiroRequest);
            return Ok(new { mensagem = "Parceiro alterado com sucesso." });
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> ExcluirParceiro(int id)
        {
            var parceiroResponse = await _useCaseGeneric.ConsultarPorId(id);
            if (parceiroResponse == null)
            {
                return NotFound("Parceiro não encontrado.");
            }
            var resultado = await _useCaseGeneric.Excluir(id);
            if (!resultado)
            {
                return BadRequest("Erro ao excluir parceiro.");
            }
            return Ok(new { mensagem = "Parceiro excluído com sucesso." });
        }
    }
}
