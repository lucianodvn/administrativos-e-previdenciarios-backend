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
    public class LoginRepository : ILoginRepository
    {
        private readonly DataDbContext _context;
        public LoginRepository(DataDbContext context) 
        {
            _context = context;
        }

        public async Task<Usuarios> ConsultarLogin(string nome, string senha)
        {
            Usuarios login =  await _context.Usuarios.FirstOrDefaultAsync(x => x.Usuario == nome && x.SenhaDoUsuario == senha);
            return login;
        }
    }
}
