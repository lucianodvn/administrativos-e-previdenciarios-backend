using Application.DTOs.ContasAPagar;

namespace Application.Interfaces.Repository
{
    public interface IContasAPagarRepository
    {
        Task<List<ContasAPagarResponse>> ConsultarTodosAsync();
        Task<ContasAPagarResponse> ConsultarPorId(int id);
        Task<List<ContasAPagarResponse>> ConsultarPorEmpresaId(int id);
        Task<List<ContasAPagarResponse>> ConsultarPorEmpresaIdMesAno(int id, int mes, int ano);
        Task<double> ObterValoresAPagar(int idEmpresa, int mes);
        Task<List<ContasAPagarResponse>> ListarContasDoAnoAnterior(int id);
        Task<double> SomaTotalContasApgarAnoAnterior(int id);
        Task<List<ContasAPagarResponse>> ConsultarContasAMigrar(int id, int mes, int ano);
    }
}
