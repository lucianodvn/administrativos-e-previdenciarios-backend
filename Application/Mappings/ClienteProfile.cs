using Application.DTOs.Clientes;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<ClienteRequest, Cliente>();
            CreateMap<Cliente, ClienteResponse>();
        }
    }
}
