using Application.DTOs.Contrato;
using Application.Interfaces.Repository;
using AutoMapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ContratoRepository : IContratoRepository
    {
        private readonly IMapper _mapper;
        private readonly DataDbContext _context;

        public ContratoRepository(IMapper mapper, DataDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ContratoResponse> ConsultarPorId(int id)
        {
            var response = await _context.Contrato
                 .Include(v => v.Cliente)
                 .Include(v => v.Beneficios)
                 .FirstOrDefaultAsync(v => v.Id == id);

            if (response == null)
            {
                return null;
            }

            return _mapper.Map<ContratoResponse>(response);
        }

        public async Task<List<ContratoResponse>> ConsultarTodosAsync()
        {
            var response = await _context.Contrato
                .Include(v => v.Cliente)
                .Include(v => v.Beneficios)
                .ToListAsync();

            if (response == null)
            {
                return null;
            }

            return _mapper.Map<List<ContratoResponse>>(response);
        }
    }
}
