using Application.DTOs.Clientes;
using Application.DTOs.ContasAPagar;
using Application.Interfaces.Repository;
using AutoMapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IMapper _mapper;
        private readonly DataDbContext _context;

        public ClienteRepository(IMapper mapper, DataDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ClienteResponse> ConsultarPorId(int id)
        {
            var response = await _context.Clientes
                 .Include(v => v.Beneficio)
                 .Include(v => v.Etapa)
                 .FirstOrDefaultAsync(v => v.Id == id);

            if (response == null)
            {
                return null;
            }

            return _mapper.Map<ClienteResponse>(response);
        }

        public async Task<ClienteResponse> ConsultarPorNome(string nome)
        {
            var response = await _context.Clientes
                 .Include(v => v.Beneficio)
                 .Include(v => v.Etapa)
                 .FirstOrDefaultAsync(v => v.NomeCompleto == nome);

            if (response == null)
            {
                return null;
            }

            return _mapper.Map<ClienteResponse>(response);
        }

        public async Task<List<ClienteResponse>> ConsultarTodosAsync()
        {
            var response = await _context.Clientes
               .Include(v => v.Beneficio)
               .Include(v => v.Etapa)
               .OrderBy(x => x.NomeCompleto)
               .ToListAsync();

            if (response == null)
            {
                return null;
            }

            return _mapper.Map<List<ClienteResponse>>(response);
        }
    }
}
