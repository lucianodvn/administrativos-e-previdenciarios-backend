using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("lucro")]
    public class LucroController : ControllerBase
    {
        private readonly LucroService _lucroService;
        public LucroController(LucroService lucroService)
        {
            _lucroService = lucroService;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarLucro()
        {
            //var response = await _lucroService.ObterLucro();
            //if (response == null)
            //{
            //    return NotFound();
            //}
            return Ok();
        }
    }
}
