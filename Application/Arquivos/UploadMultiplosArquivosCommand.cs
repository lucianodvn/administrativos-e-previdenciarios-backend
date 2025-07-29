using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Arquivos
{
    public record UploadMultiplosArquivosCommand(List<IFormFile> Arquivos, string NomeCliente) : IRequest<List<UploadArquivoResult>>;
   
    public record UploadArquivoResult(string Url, string NomeArquivo);
}
