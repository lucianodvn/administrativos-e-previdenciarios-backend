using Domain.Interfaces.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Arquivos
{
    public class UploadMultiplosArquivosComprovanteCommandHandler 
        : IRequestHandler<UploadMultiplosArquivosCommandComprovante, List<UploadArquivoResultComprovante>>
    {
        private readonly IArquivoService _arquivoService;

        public UploadMultiplosArquivosComprovanteCommandHandler(IArquivoService arquivoService)
        {
            _arquivoService = arquivoService;
        }

        public async Task<List<UploadArquivoResultComprovante>> Handle(UploadMultiplosArquivosCommandComprovante request, CancellationToken cancellationToken)
        {
            var resultados = new List<UploadArquivoResultComprovante>();

            foreach (var arquivo in request.Arquivos)
            {
                var (url, nomeArquivo) = await _arquivoService
                    .SalvarArquivoComSubpastaComprovanteAsync(arquivo, request.NomeCliente, request.id);

                resultados.Add(new UploadArquivoResultComprovante(url, nomeArquivo, request.id));
            }

            return resultados;
        }
    }
}
