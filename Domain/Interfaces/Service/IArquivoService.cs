using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface IArquivoService
    {
        Task<(string url, string nomeArquivo)> SalvarArquivoComSubpastaAsync(IFormFile arquivo, string nomeCliente);
        Task<IEnumerable<ArquivoDto>> ListarArquivosPorClienteAsync(string nomeCliente);
    }
}
