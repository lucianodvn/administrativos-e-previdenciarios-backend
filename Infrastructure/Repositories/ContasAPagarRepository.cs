﻿using Application.DTOs.ContasAPagar;
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
                 .Include(v => v.Parceiro)
                 .Include(v => v.Fornecedor)
                 .FirstOrDefaultAsync(v => v.Id == id);

            if (response == null)
            {
                return null;
            }

            return _mapper.Map<ContasAPagarResponse>(response);
        }

        public async Task<List<ContasAPagarResponse>> ConsultarTodosAsync()
        {
            var response = await _context.ContasAPagar
                .Include(v => v.Parceiro)
                .Include(v => v.Fornecedor)
                .ToListAsync();

            if (response == null)
            {
                return null;
            }

            return _mapper.Map<List<ContasAPagarResponse>>(response);
        }
    }
}
