using Application.DTOs.Contrato;
using Application.Interfaces.Repository;
using AutoMapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ContratoJudicialRepository : IContratoJudicialRepository
    {
        private readonly IMapper _mapper;
        private readonly DataDbContext _context;

        public ContratoJudicialRepository(IMapper mapper, DataDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ContratoJudicialResponse> ConsultarPorId(int id)
        {
            var response = await _context.ContratoJudicial
                 .Include(v => v.Cliente)
                 .Include(v => v.Parceiro)
                 .FirstOrDefaultAsync(v => v.Id == id);

            if (response == null)
            {
                return null;
            }

            return _mapper.Map<ContratoJudicialResponse>(response);
        }

        public async Task<List<ContratoJudicialResponse>> ConsultarTodosAsync()
        {
            var response = await _context.ContratoJudicial
                .Include(v => v.Cliente)
                .Include(v => v.Parceiro)
                .ToListAsync();

            if (response == null)
            {
                return null;
            }

            return _mapper.Map<List<ContratoJudicialResponse>>(response);
        }
    }
}
