using Application.DTOs.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteResponse> SalvarAsync(ClienteRequest clienteRequest);
    }
}
