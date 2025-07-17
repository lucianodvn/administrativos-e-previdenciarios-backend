using Application.DTOs.Clientes;
using Application.Interfaces;
using Application.UseCases;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> Salvar(Cliente cliente)
        {
            return await _clienteRepository.SalvarAsync(cliente);
        }
    }
}
