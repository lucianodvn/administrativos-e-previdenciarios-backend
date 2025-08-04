using Application.DTOs.Login;
using Application.DTOs.Usuarios;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ILoginUseCase
    {
        Task<UsuarioResponse> ConsultarLogin(LoginRequest loginRequest);
    }
}
