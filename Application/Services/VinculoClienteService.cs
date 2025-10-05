using Application.DTOs.VinculoClienteBeneficioEtapa;
using Application.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class VinculoClienteService
    {
        private readonly IVinculoClienteRepository _repository;

        public VinculoClienteService(IMapper mapper, IVinculoClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<VinculoClienteBeneficioEtapaResponse>> ConsultarTodos()
        {
            var response = await _repository.ConsultarTodosAsync();
            if(response == null)
            {
                return null;
            }
            return response;
        }

        public async Task<VinculoClienteBeneficioEtapaResponse> ConsultarPorId(int id)
        {
            var response = await _repository.ConsultarPorId(id);
            if (response == null)
            {
                return null;
            }

            return response;
        }
    }
}
