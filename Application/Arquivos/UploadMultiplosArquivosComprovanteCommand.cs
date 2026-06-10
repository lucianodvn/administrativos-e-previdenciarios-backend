using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Arquivos
{
    public record UploadMultiplosArquivosCommandComprovante(List<IFormFile> Arquivos, string NomeCliente, string id) : IRequest<List<UploadArquivoResultComprovante>>;

    public record UploadArquivoResultComprovante(string Url, string NomeArquivo, string id);
}
