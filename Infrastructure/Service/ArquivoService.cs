using Domain.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class ArquivoService : IArquivoService
    {
        private readonly IWebHostEnvironment _env;

        public ArquivoService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<(string url, string nomeArquivo)> SalvarArquivoComSubpastaAsync(IFormFile arquivo, string nomeCliente)
        {
            if (arquivo == null || string.IsNullOrWhiteSpace(nomeCliente))
                throw new ArgumentException("Arquivo ou nome do cliente inválido.");

            var nomeClienteSanitizado = SanitizarNome(nomeCliente);
            var nomeArquivoOriginal = Path.GetFileNameWithoutExtension(arquivo.FileName);
            var nomeArquivoSanitizado = SanitizarNome(nomeArquivoOriginal);
            var raiz = _env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

            var pastaBase = Path.Combine(raiz, "arquivos", nomeClienteSanitizado, nomeArquivoSanitizado);
            Directory.CreateDirectory(pastaBase);

            var nomeFinal = Guid.NewGuid() + Path.GetExtension(arquivo.FileName);
            var caminhoCompleto = Path.Combine(pastaBase, nomeFinal);

            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            var url = $"/arquivos/{nomeClienteSanitizado}/{nomeArquivoSanitizado}/{nomeFinal}";
            return (url, nomeFinal);
        }


        private string SanitizarNome(string nome)
        {
            var nomeLimpo = nome.Normalize(System.Text.NormalizationForm.FormD);
            var chars = nomeLimpo.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray();
            nomeLimpo = new string(chars);
            return Regex.Replace(nomeLimpo, @"[^a-zA-Z0-9_\-]", "_").ToLower();
        }
    }

}
