using Application.DTOs.VinculoClienteParceiro;
using Application.Interfaces;
using AutoMapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class VinculoClienteParceiroRepository : IVinculoClienteParceiroRepository
    {
        private readonly IMapper _mapper;
        protected readonly DataDbContext _context;

        public VinculoClienteParceiroRepository(IMapper mapper, DataDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<VinculoClienteParceiroResponse> ConsultarPorId(int id)
        {
            var response = await _context.VinculoClienteParceiros
                .Include(v => v.Cliente)
                .Include(v => v.Parceiro)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (response == null)
            {
                return null;
            }

            return _mapper.Map<VinculoClienteParceiroResponse>(response);
        }

        public async Task<List<VinculoClienteParceiroResponse>> ConsultarTodosAsync()
        {
            var response = await _context.VinculoClienteParceiros
                .Include(v => v.Cliente)
                .Include(v => v.Parceiro)
                .ToListAsync();

            if (response == null)
            {
                return null;
            }

            return _mapper.Map<List<VinculoClienteParceiroResponse>>(response);
        }
    }
}
