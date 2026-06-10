using Application.Arquivos;
using Domain.Interfaces.Service;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("upload")]
    public class UploadController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IArquivoService _arquivoService;

        public UploadController(ISender mediator, IArquivoService arquivoService)
        {
            _mediator = mediator;
            _arquivoService = arquivoService;
        }

        [HttpPost("salvararquivos")]
        public async Task<IActionResult> UploadMultiplos([FromForm] List<IFormFile> arquivos, [FromForm] string nomeCliente)
        {
            var resultado = await _mediator.Send(new UploadMultiplosArquivosCommand(arquivos, nomeCliente));
            return Ok(resultado);
        }

        [HttpGet("listararquivos/{cliente}")]
        public async Task<IActionResult> ListarArquivos(string cliente)
        {
            var arquivos = await _arquivoService.ListarArquivosPorClienteAsync(cliente);
            return Ok(arquivos);
        }

        [HttpPost("salvarcomprovante")]
        public async Task<IActionResult> UploadMultiplosComprovante([FromForm] List<IFormFile> arquivos, [FromForm] string nomeCliente, [FromForm] int id)
        {
            var resultado = await _mediator.Send(new UploadMultiplosArquivosCommandComprovante(arquivos, nomeCliente, id.ToString()));
            return Ok(resultado);
        }

        [HttpGet("listararquivoscomprovantes/{cliente}/{mesAno}/{id}")]
        public async Task<IActionResult> ListarArquivosComprovantes(string cliente, string mesAno, int id)
        {
            var arquivos = await _arquivoService.ListarArquivosPorComprovanteAsync(cliente, mesAno, id.ToString());
            return Ok(arquivos);
        }
    }
}