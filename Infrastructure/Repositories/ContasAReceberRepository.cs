using Application.DTOs.ContasAPagar;
using Application.DTOs.ContasAReceber;
using Application.Interfaces.Repository;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
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
            var response = await _context.ContasAReceber
                .Include(x => x.Cliente)
                .ToListAsync();

            if (response == null)
            {
                return null;
            }

            var dto = _mapper.Map<List<ContasAReceberResponse>>(response);
            return dto;
        }

        public async Task<ContasAReceberResponse> ConsultarId(int id)
        {
            var response = await _context.ContasAReceber
               .Include(x => x.Cliente)
               .FirstOrDefaultAsync(x => x.Id == id);

            if (response == null)
            {
                return null;
            }

            return _mapper.Map<ContasAReceberResponse>(response);
        }

        public async Task<List<ContasAReceberResponse>> ConsultarPoClienteId(int id)
        {
            var response = await _context.ContasAReceber
                 .Include(v => v.Cliente)
                 .Where(v => v.ClienteId == id)
                 .ToListAsync();

            if (response == null)
            {
                return null;
            }

            var dto = _mapper.Map<List<ContasAReceberResponse>>(response);
            return dto;
        }

        public async Task SalvarTodos(List<ContasAReceberRequest> request)
        {
            try
            {
                var entidades = _mapper.Map<List<ContasAReceber>>(request);
                await _context.ContasAReceber.AddRangeAsync(entidades);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar contas a receber: " + ex.Message);
            }
        }

        public async Task<List<ContasAReceberResponse>> ConsultarPorTipoAsync(int tipo)
        {
            var inicioMesAtual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var inicioProximoMes = inicioMesAtual.AddMonths(1);

            var response = await _context.ContasAReceber
                 .Include(v => v.Cliente)
                 .ToListAsync();
            if (response == null)
            {
                return null;
            }

            switch (tipo)
            {
                case 1:
                    break;
                case 2:
                    response = response
                        .Where(v => v.StatusPagamento == false
                                 && v.DataVencimento.HasValue
                                 && v.DataVencimento.Value < inicioProximoMes)
                        .ToList();

                    break;
                case 3:
                    response = response
                        .Where(v => v.StatusPagamento == false
                                 && v.DataVencimento.HasValue
                                 && v.DataVencimento.Value >= inicioProximoMes)
                        .ToList();

                    break;
                case 4:
                    response = response.Where(v => v.StatusPagamento == true).ToList();
                    break;
            }

            var dto = _mapper.Map<List<ContasAReceberResponse>>(response);
            return dto;
        }
    }
}
