using Application.DTOs.Clientes;
using Application.DTOs.ContasAReceber;
using Application.DTOs.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository
{
    public interface IClienteRepository
    {
        Task<List<ClienteResponse>> ConsultarTodosAsync();
        Task<ClienteResponse> ConsultarPorId(int id);
        Task<ClienteResponse> ConsultarPorNome(string nome);
    }
}
