using Application.DTOs.Fornecedor;
using Application.Interfaces.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("fornecedor")]
    public class FornecedorController : ControllerBase
    {
        private readonly IUseCaseGeneric<FornecedorRequest, FornecedorResponse> _useCaseGeneric;

        public FornecedorController(IUseCaseGeneric<FornecedorRequest, FornecedorResponse> useCaseGeneric)
        {
            _useCaseGeneric = useCaseGeneric;
        }

        [HttpPost("salvar")]
        public async Task<IActionResult> SalvarParceiro([FromBody] FornecedorRequest fornecedorRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fornecedorResponse = await _useCaseGeneric.Salvar(fornecedorRequest);
            return Ok(fornecedorResponse);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarTodosParceiros()
        {
            var fornecedorResponse = await _useCaseGeneric.ConsultarTodos();
            if (fornecedorResponse == null || !fornecedorResponse.Any())
            {
                return NotFound("Nenhum fornecedor encontrado.");
            }
            return Ok(fornecedorResponse);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarParceiroPorId(int id)
        {
            var fornecedorResponse = await _useCaseGeneric.ConsultarPorId(id);
            if (fornecedorResponse == null)
            {
                return NotFound("Nenhum fornecedor encontrado.");
            }
            return Ok(fornecedorResponse);
        }

        [HttpPut("alterar")]
        public async Task<IActionResult> AlterarParceiro([FromBody] FornecedorRequest fornecedorRequest)
        {
            if (fornecedorRequest == null)
            {
                return BadRequest("Fornecedor Inexistente");
            }
            await _useCaseGeneric.Alterar(fornecedorRequest.Id, fornecedorRequest);
            return Ok(new { mensagem = "Fornecedor alterado com sucesso." });
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> ExcluirParceiro(int id)
        {
            var fornecedorResponse = await _useCaseGeneric.ConsultarPorId(id);
            if (fornecedorResponse == null)
            {
                return NotFound("fornecedor não encontrado.");
            }
            var resultado = await _useCaseGeneric.Excluir(id);
            if (!resultado)
            {
                return BadRequest("Erro ao excluir fornecedor.");
            }
            return Ok(new { mensagem = "Fornecedor excluído com sucesso." });
        }
    }
}

