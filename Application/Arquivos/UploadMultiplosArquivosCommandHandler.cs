using Domain.Interfaces.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Arquivos
{
    public class UploadMultiplosArquivosCommandHandler
    : IRequestHandler<UploadMultiplosArquivosCommand, List<UploadArquivoResult>>
    {
        private readonly IArquivoService _arquivoService;

        public UploadMultiplosArquivosCommandHandler(IArquivoService arquivoService)
        {
            _arquivoService = arquivoService;
        }

        public async Task<List<UploadArquivoResult>> Handle(
            UploadMultiplosArquivosCommand request,
            CancellationToken cancellationToken)
        {
            var resultados = new List<UploadArquivoResult>();

            foreach (var arquivo in request.Arquivos)
            {
                var (url, nomeArquivo) = await _arquivoService
                    .SalvarArquivoComSubpastaAsync(arquivo, request.NomeCliente);

                resultados.Add(new UploadArquivoResult(url, nomeArquivo));
            }

            return resultados;
        }
    }

}
