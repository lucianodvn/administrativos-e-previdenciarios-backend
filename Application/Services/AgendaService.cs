using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AgendaService
    {
        private readonly IServiceGeneric<Cliente> _clienteService;
        private readonly IServiceGeneric<ContasAReceber> _contasService;

        public AgendaService(IServiceGeneric<Cliente> clienteService, IServiceGeneric<ContasAReceber> contasService)
        {
            _clienteService = clienteService;
            _contasService = contasService;
        }

        public async Task<IEnumerable<AgendaResponse>> ObterAgenda()
        {
            var clientes = await _clienteService.ConsultarTodos();
            var contas = await _contasService.ConsultarTodos();
            var agenda = from cliente in clientes
                         join conta in contas on cliente.Id equals conta.ClienteId into contasCliente
                         from conta in contasCliente.DefaultIfEmpty()
                         where conta != null && conta.DataVencimento.Month == DateTime.Now.Month && conta.DataVencimento.Year == DateTime.Now.Year
                         select new AgendaResponse
                         {
                             NomeDoCliente = cliente.NomeCompleto,
                             DataDoAgendamento = conta.DataPagamento.HasValue ? conta.DataPagamento.Value : conta.DataVencimento,
                             DataDoVencimento = conta.DataVencimento,
                             ValorAReceber = conta.Valor,
                             NumeroDaParcela = conta.QuantidadeParcelas
                         };
            return agenda.ToList();
        }
    }
}
