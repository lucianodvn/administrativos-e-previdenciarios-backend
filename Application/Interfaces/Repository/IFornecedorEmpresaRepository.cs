using Application.DTOs.ContasAPagar;
using Application.DTOs.FornecedorEmpresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository
{
    public interface IFornecedorEmpresaRepository
    {
        Task<List<FornecedorEmpresaResponse>> ConsultarTodosAsync();
        Task<FornecedorEmpresaResponse> ConsultarPorId(int id);
        Task<List<FornecedorEmpresaResponse>> ConsultarPorEmpresaId(int id);
    }
}
