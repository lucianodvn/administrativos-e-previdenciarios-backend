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
        public async Task<ContasAReceberResponse> ConsultarPorId(int id)
        {
            var response = await _context.ContasAReceber
                 .Include(v => v.Cliente)
                 .Include(v => v.Parceiro)
                 .Include(v => v.Fornecedor)
                 .FirstOrDefaultAsync(v => v.Id == id);

            if (response == null)
            {
                return null;
            }

            return _mapper.Map<ContasAReceberResponse>(response);
        }

        public async Task<List<ContasAReceberResponse>> ConsultarTodosAsync()
        {
            var response = await _context.ContasAReceber
                .Include(v => v.Cliente)
                .Include(v => v.Parceiro)
                .Include(v => v.Fornecedor)
                .ToListAsync();

            if (response == null)
            {
                return null;
            }

            return _mapper.Map<List<ContasAReceberResponse>>(response);
        }
    }
}
