using Application.DTOs.Clientes;
using Application.Interfaces;
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
    public class ClienteUseCase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteUseCase(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        public async Task<ClienteResponse> Salvar(ClienteRequest clienteRequest)
        {
            var cliente = _mapper.Map<Cliente>(clienteRequest);

            var clienteSalvo = await _clienteService.Salvar(cliente);

            return _mapper.Map<ClienteResponse>(clienteSalvo);
        }
    }
}
