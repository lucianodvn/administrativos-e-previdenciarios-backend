using Application.DTOs.Lucro;
using Application.Interfaces.Service;
using Domain.Entities;

namespace Application.Services
{
    public class LucroService
    {
        private readonly IServiceGeneric<ContasAPagar> _contasPagarService;
        private readonly ContasAReceberService _contasService;

        public LucroService(IServiceGeneric<ContasAPagar> contasPagarService, ContasAReceberService contasService)
        {
            _contasPagarService = contasPagarService;
            _contasService = contasService;
        }

        public async Task<LucroResponse> ObterLucro()
        {
            var contaAPagar = await _contasPagarService.ConsultarTodos();
            var contasReceber = await _contasService.ConsultarTodos();

            if (contaAPagar == null || contasReceber == null)
            {
                return new LucroResponse();
            }
            else
            {
                double totalPagar = contaAPagar
                    .Where(x => x.DataVencimento?.Month == DateTime.Now.Month && x.DataVencimento?.Year == DateTime.Now.Year)
                    .Sum(x => x.Valor.GetValueOrDefault());

                double valorTotal = contasReceber.Sum(x => x.ValorTotal ?? 0);
                double valorentrada = contasReceber.Sum(x => x.ValorEntrada ?? 0);
                double valorParcela = contasReceber.Sum(x => x.ValorParcela ?? 0);

                double totalReceber = valorTotal + valorentrada + valorParcela;

                return new LucroResponse
                {
                    TotalPagar = totalPagar,
                    TotalReceber = totalReceber,
                    TotalLucro = totalReceber - totalPagar
                };
            }
        }
    }
}
