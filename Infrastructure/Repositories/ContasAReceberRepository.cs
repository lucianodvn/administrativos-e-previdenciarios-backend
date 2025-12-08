using Application.DTOs.ContasAReceber;
using Application.Interfaces.Repository;
using AutoMapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ContasAReceberRepository : IContasAReceberRepository
    {
        private readonly IMapper _mapper;
        private readonly DataDbContext _context;

        public ContasAReceberRepository(IMapper mapper, DataDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<ContasAReceberResponse>> ConsultarTodosAsync()
        {
            var contratoJudicial = await _context.ContratoJudicial
                .Include(x => x.Cliente)
                .Include(x => x.Parceiro)
                .ToListAsync();

            var contratoAdm = await _context.Contrato
                .Include(x => x.Cliente)
                .ToListAsync();

            ContasAReceberResponse contas = new ContasAReceberResponse();
            List<ContasAReceberResponse> listaDeContas = new List<ContasAReceberResponse>();

            if (contratoJudicial.Any())
            {
                foreach (var reponseJudicial in contratoJudicial)
                {
                    listaDeContas.Add(new ContasAReceberResponse
                    {
                        Id = reponseJudicial.Id,
                        TipoClienteOuParceiro = "Parceiro",
                        Nome = $"{reponseJudicial.Parceiro?.NomeParceiro}({reponseJudicial.Cliente?.NomeCompleto})",
                        TipoDeContrato = "Judicial",
                        ValorTotal = reponseJudicial.Valor,
                        ValorEntrada = 0,
                        ValorParcela = 0,
                        DataDeVencimentoTotal = null
                    });
                }
            }

            if (contratoAdm.Any())
            {
                foreach (var responseAdm in contratoAdm)
                {
                    listaDeContas.Add(new ContasAReceberResponse
                    {
                        Id = responseAdm.Id,
                        TipoClienteOuParceiro = "Cliente",
                        Nome = responseAdm.Cliente?.NomeCompleto,
                        TipoDeContrato = "Administrativo",
                        //ValorTotal = responseAdm.ValorTotal ?? 0,
                        //ValorEntrada = responseAdm.ValorEntrada ?? 0,
                        //ValorParcela = responseAdm.ValorDasParcelas ?? 0,
                        //DataDeVencimentoTotal = responseAdm.DataDoVencimentoTotal,
                        //DataDeVencimentoDaParcela = responseAdm.DataPagamentoDaParcela,
                        //DataDoVencimentoValorEntrada = responseAdm.DataDoVencimentoValorEntrada
                    });
                }
            }

            return listaDeContas;
        }
    }
}
