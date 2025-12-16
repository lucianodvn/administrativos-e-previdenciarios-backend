using Application.DTOs.ContasAPagar;
using Application.DTOs.FornecedorEmpresa;
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
    public class FornecedorEmpresaRepository : IFornecedorEmpresaRepository
    {
        private readonly IMapper _mapper;
        private readonly DataDbContext _context;

        public FornecedorEmpresaRepository(IMapper mapper, DataDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<FornecedorEmpresaResponse> ConsultarPorId(int id)
        {
            var response = await _context.FornecedorEmpresa
                 .Include(v => v.Empresa)
                 .FirstOrDefaultAsync(v => v.Id == id);

            if (response == null)
            {
                return null;
            }

            return _mapper.Map<FornecedorEmpresaResponse>(response);
        }

        public async Task<List<FornecedorEmpresaResponse>> ConsultarPorEmpresaId(int id)
        {
            var response = await _context.FornecedorEmpresa
                 .Include(v => v.Empresa)
                 .Where(v => v.Empresa.Id == id)
                 .ToListAsync();

            if (response == null)
            {
                return null;
            }

            var dto = _mapper.Map<List<FornecedorEmpresaResponse>>(response);
            return dto;
        }

        public async Task<List<FornecedorEmpresaResponse>> ConsultarTodosAsync()
        {
            var response = await _context.FornecedorEmpresa
                .Include(v => v.Empresa)
                .ToListAsync();

            if (response == null)
            {
                return null;
            }

            return _mapper.Map<List<FornecedorEmpresaResponse>>(response);
        }
    }
}

