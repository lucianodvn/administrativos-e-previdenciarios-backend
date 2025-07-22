using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RepresentanteLegalRepository : RepositoryGeneric<RepresentanteLegal>, IRepositoryRepresentanteLegal
    {
        private readonly DataDbContext _context;
        public RepresentanteLegalRepository(DataDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<RepresentanteLegal>> ConsultarTodos()
        {
            return await _context.Set<RepresentanteLegal>()
                .Include(r => r.Cliente)
                .ToListAsync();
        }
    }
}
