using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UseCase
{
    public interface IUseCaseGeneric<TRequest, TResponse>
    {
        Task<TResponse> ConsultarPorId(int id);
        Task<IEnumerable<TResponse>> ConsultarTodos();
        Task<TResponse> Salvar(TRequest request);
        Task Alterar(int id, TRequest request);
        Task<bool> Excluir(int id);
        Task<bool> Existe(string numeroRecibo);
    }
}
