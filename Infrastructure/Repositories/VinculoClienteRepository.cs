using Application.DTOs.Usuarios;
using Application.DTOs.VinculoClienteBeneficioEtapa;
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
    public class VinculoClienteRepository: IVinculoClienteRepository
    {
        private readonly IMapper _mapper;
        protected readonly DataDbContext _context;

        public VinculoClienteRepository(IMapper mapper, DataDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<VinculoClienteBeneficioEtapaResponse> ConsultarPorId(int id)
        {
            var response = await _context.VinculoClienteBeneficioEtapas
                .Include(v => v.Cliente)
                .Include(v => v.EtapaServico)
                .Include(v => v.BeneficiosServicos)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (response == null)
            {
                return null;
            }

            return _mapper.Map<VinculoClienteBeneficioEtapaResponse>(response);
        }

        public async Task<List<VinculoClienteBeneficioEtapaResponse>> ConsultarTodosAsync()
        {
            var response = await _context.VinculoClienteBeneficioEtapas
                .Include(v => v.Cliente)
                .Include(v => v.EtapaServico)
                .Include(v => v.BeneficiosServicos)
                .ToListAsync();

            if(response == null)
            {
                return null;
            }

            return _mapper.Map<List<VinculoClienteBeneficioEtapaResponse>>(response);
        }
    }
}
