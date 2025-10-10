using Application.DTOs.Usuarios;
using Application.DTOs.VinculoClienteBeneficioEtapa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository
{
    public interface IVinculoClienteRepository
    {
        Task<List<VinculoClienteBeneficioEtapaResponse>> ConsultarTodosAsync();
        Task<VinculoClienteBeneficioEtapaResponse> ConsultarPorId(int id);
    }
}
