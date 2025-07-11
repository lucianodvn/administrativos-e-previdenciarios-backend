using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> SalvarAsync(Cliente cliente);
        Task<Cliente> AtualizarAsync(Cliente cliente);
        Task<Cliente> ObterPorIdAsync(int id);
        Task<IEnumerable<Cliente>> ObterTodosCLientesAsync();
        Task<bool> ExcluirAsync(int id);
    }
}
