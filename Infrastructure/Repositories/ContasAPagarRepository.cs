using Application.DTOs.ContasAPagar;
using Application.Interfaces.Repository;
using AutoMapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ContasAPagarRepository : IContasAPagarRepository
    {
        private readonly IMapper _mapper;
        private readonly DataDbContext _context;

        public ContasAPagarRepository(IMapper mapper, DataDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ContasAPagarResponse> ConsultarPorId(int id)
        {
            var response = await _context.ContasAPagar
                 .Include(v => v.FornecedorEmpresa)
                 .Include(v => v.Fornecedor)
                 .FirstOrDefaultAsync(v => v.Id == id);

            if (response == null)
            {
                return null;
            }

            return _mapper.Map<ContasAPagarResponse>(response);
        }

        public async Task<List<ContasAPagarResponse>> ConsultarPorEmpresaId(int id)
        {
            var response = await _context.ContasAPagar
                 .Include(v => v.FornecedorEmpresa)
                 .Include(v => v.Fornecedor)
                 .Where(v => v.IdFornecedor == id)
                 //.Where(v => v.DataVencimento.Month == DateTime.Now.Month && v.IsPago == false && v.IdFornecedor == id)
                 .OrderBy(v => v.DataVencimento)
                 .ToListAsync();

            if (response == null)
            {
                return null;
            }

            var dto = _mapper.Map<List<ContasAPagarResponse>>(response);
            return dto;
        }

        public async Task<List<ContasAPagarResponse>> ConsultarPorEmpresaIdMesAno(int id, int mes, int ano)
        {
            var hoje = DateTime.Now;

            var response = await _context.ContasAPagar
                .Include(v => v.FornecedorEmpresa)
                .Include(v => v.Fornecedor)
                .Where(v => v.IdFornecedor == id)
                .Where(v =>
                    (v.DataVencimento.HasValue &&
                     v.DataVencimento.Value.Month == mes &&
                     v.DataVencimento.Value.Year == ano)
                    ||
                    (v.DataVencimento.HasValue &&
                     (v.DataVencimento.Value < hoje && mes == hoje.Month && ano == hoje.Year) &&
                     v.IsPago == false)
                     ||
                     (v.DataPagamento.HasValue &&
                     v.DataPagamento.Value.Month == mes &&
                     v.DataPagamento.Value.Year == ano)
                )
                .OrderBy(v => v.DataVencimento)
                .ToListAsync();

            if (!response.Any())
            {
                return new List<ContasAPagarResponse>();
            }

            return _mapper.Map<List<ContasAPagarResponse>>(response);
        }

        public async Task<List<ContasAPagarResponse>> ConsultarTodosAsync()
        {
            var response = await _context.ContasAPagar
                .Include(v => v.FornecedorEmpresa)
                .Include(v => v.Fornecedor)
                .Where(v => v.DataVencimento.HasValue && v.DataVencimento.Value.Month == DateTime.Now.Month && (v.IsPago == false || v.IsPago == null))
                .OrderBy(v => v.DataVencimento)
                .ToListAsync();

            if (response == null)
            {
                return null;
            }

            return _mapper.Map<List<ContasAPagarResponse>>(response);
        }

        public async Task<double> ObterValoresAPagar(int id, int mes)
        {
            var response = await _context.ContasAPagar
                .Where(v => v.IdFornecedor == id && 
                    v.DataVencimento.HasValue &&
                    v.DataVencimento.Value.Month <= mes &&
                    v.IsPago == false)
                .SumAsync(x => x.Valor) ?? 0;

            if (response == 0)
            {
                return 0;
            }

            return response;
        }

        public async Task<List<ContasAPagarResponse>> ListarContasDoAnoAnterior(int id)
        {
            var hoje = DateTime.Now;

            var response = await _context.ContasAPagar
                .Include(v => v.FornecedorEmpresa)
                .Include(v => v.Fornecedor)
                .Where(v => v.IdFornecedor == id)
                .Where(v =>
                    (v.DataVencimento.HasValue &&
                     v.DataVencimento.Value.Year == hoje.Year - 1)
                )
                .OrderBy(v => v.DataVencimento)
                .ToListAsync();

            if (!response.Any())
            {
                return new List<ContasAPagarResponse>();
            }

            return _mapper.Map<List<ContasAPagarResponse>>(response);
        }

        public async Task<double> SomaTotalContasApgarAnoAnterior(int id)
        {
            var hoje = DateTime.Now;
            var response = await _context.ContasAPagar
                .Where(v => v.IdFornecedor == id && v.DataVencimento.HasValue && v.DataVencimento.Value.Year == hoje.Year - 1 && v.IsPago == true)
                .SumAsync(x => x.Valor) ?? 0;
            if (response == 0)
            {
                return 0;
            }
            return response;
        }

        public async Task<List<ContasAPagarResponse>> ConsultarContasAMigrar(int idEmpresa, int mes, int ano)
        {
            var response = await _context.ContasAPagar
                .Include(v => v.FornecedorEmpresa)
                .Include(v => v.Fornecedor)
                .Where(v => v.IdFornecedor == idEmpresa)
                .Where(v =>
                    (v.DataVencimento.HasValue &&
                     v.DataVencimento.Value.Month == mes &&
                     v.DataVencimento.Value.Year == ano))
                .OrderBy(v => v.DataVencimento)
                .ToListAsync();
            if (!response.Any())
            {
                return new List<ContasAPagarResponse>();
            }

            return _mapper.Map<List<ContasAPagarResponse>>(response);
        }
    }
}
