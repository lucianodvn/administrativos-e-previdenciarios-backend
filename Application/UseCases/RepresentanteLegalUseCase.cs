using Application.DTOs.TipoDeRepresentante;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class RepresentanteLegalUseCase
    {
        private IRepositoryRepresentanteLegal _repositoryRepresentanteLegal;
        private readonly IMapper _mapper;

        public RepresentanteLegalUseCase(IRepositoryRepresentanteLegal repositoryRepresentanteLegal, IMapper mapper)
        {
            _repositoryRepresentanteLegal = repositoryRepresentanteLegal;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RepresentanteLegalResponse>> ConsultarTodos()
        {
            var entidades = await _repositoryRepresentanteLegal.ConsultarTodos();
            var resultado = _mapper.Map<IEnumerable<RepresentanteLegalResponse>>(entidades);
            return resultado;
        }
    }
}
