using Application.DTOs.Clientes;
using Application.Interfaces;
using Application.UseCases;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ClienteUseCase _clienteUseCase;
        private readonly IMapper _mapper;

        public ClienteService(ClienteUseCase clienteUseCase, IMapper mapper)
        {
            _mapper = mapper;
            _clienteUseCase = clienteUseCase;
        }

        public async Task<ClienteResponse> SalvarAsync(ClienteRequest clienteRequest)
        {
            var cliente = _mapper.Map<Cliente>(clienteRequest);
            var resultado = await _clienteUseCase.SalvarAsync(cliente);
            return _mapper.Map<ClienteResponse>(resultado);
        }
    }
}
