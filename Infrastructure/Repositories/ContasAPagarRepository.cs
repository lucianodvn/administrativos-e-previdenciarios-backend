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

        public async Task<List<ContasAPagarResponse>> ConsultarTodosAsync()
        {
            var response = await _context.ContasAPagar
                .Include(v => v.FornecedorEmpresa)
                .Include(v => v.Fornecedor)
                .Where(v => v.DataVencimento.HasValue && v.DataVencimento.Value.Month == DateTime.Now.Month && v.IsPago == false)
                .OrderBy(v => v.DataVencimento)
                .ToListAsync();

            if (response == null)
            {
                return null;
            }

            return _mapper.Map<List<ContasAPagarResponse>>(response);
        }
    }
}
