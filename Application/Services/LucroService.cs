using Application.DTOs;
using Application.DTOs.Lucro;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Application.Services
{
    public class LucroService
    {
        private readonly IServiceGeneric<ContasAPagar> _contasPagarService;
        private readonly IServiceGeneric<ContasAReceber> _contasService;

        public LucroService(IServiceGeneric<ContasAPagar> contasPagarService, IServiceGeneric<ContasAReceber> contasService)
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
                double totalPagar = contaAPagar.Where(x => x.DataVencimento.Month == DateTime.Now.Month && x.DataVencimento.Year == DateTime.Now.Year).Sum(x => x.Valor);
                double totalReceber = contasReceber.Where(x => x.DataVencimento.Month == DateTime.Now.Month && x.DataVencimento.Year == DateTime.Now.Year).Sum(x => x.Valor);

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
