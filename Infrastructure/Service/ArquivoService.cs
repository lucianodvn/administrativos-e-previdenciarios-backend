using Domain.Entities;
using Domain.Interfaces.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Infrastructure.Service
{
    public class ArquivoService : IArquivoService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ArquivoService(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _env = env;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<(string url, string nomeArquivo)> SalvarArquivoComSubpastaAsync(IFormFile arquivo, string nomeCliente)
        {
            if (arquivo == null || string.IsNullOrWhiteSpace(nomeCliente))
                throw new ArgumentException("Arquivo ou nome do cliente inválido.");

            var nomeClienteSanitizado = SanitizarNome(nomeCliente);
            var nomeArquivoOriginal = Path.GetFileNameWithoutExtension(arquivo.FileName);
            var nomeArquivoSanitizado = SanitizarNome(nomeArquivoOriginal);
            var raiz = _env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

            var pastaBase = Path.Combine(raiz, "arquivos", nomeClienteSanitizado);
            Directory.CreateDirectory(pastaBase);

            var nomeFinal = nomeArquivoOriginal + Path.GetExtension(arquivo.FileName);
            var caminhoCompleto = Path.Combine(pastaBase, nomeFinal);

            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            var url = $"/arquivos/{nomeClienteSanitizado}/{nomeFinal}";
            return (url, nomeFinal);
        }


        private string SanitizarNome(string nome)
        {
            var nomeLimpo = nome.Normalize(NormalizationForm.FormD);
            var chars = nomeLimpo.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray();
            nomeLimpo = new string(chars);
            return Regex.Replace(nomeLimpo, @"[^a-zA-Z0-9_\-]", "_").ToLower();
        }

        public async Task<IEnumerable<ArquivoDto>> ListarArquivosPorClienteAsync(string nomeCliente)
        {
            var nomeClienteSanitizado = SanitizarNome(nomeCliente);
            var raiz = _env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var pastaBase = Path.Combine(raiz, "arquivos", nomeClienteSanitizado);

            if (!Directory.Exists(pastaBase))
                return Enumerable.Empty<ArquivoDto>();

            var arquivos = Directory.GetFiles(pastaBase);

            var lista = arquivos.Select(arquivo => new ArquivoDto
            {
                Url = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}/arquivos/{nomeClienteSanitizado}/{Path.GetFileName(arquivo)}",
                NomeArquivo = Path.GetFileName(arquivo)
            });

            return await Task.FromResult(lista);
        }
    }
}
