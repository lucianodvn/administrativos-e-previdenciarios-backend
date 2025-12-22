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
    }
}