using Application.Arquivos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("upload")]
    public class UploadController : ControllerBase
    {
        private readonly ISender _mediator;

        public UploadController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("salvararquivos")]
        public async Task<IActionResult> UploadMultiplos([FromForm] List<IFormFile> arquivos, [FromForm] string nomeCliente)
        {
            var resultado = await _mediator.Send(new UploadMultiplosArquivosCommand(arquivos, nomeCliente));
            return Ok(resultado);
        }
    }
}