using Application.DTOs.Clientes;
using Application.DTOs.Contrato;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<ClienteRequest, Cliente>();
            CreateMap<Cliente, ClienteResponse>();
            CreateMap<ContratoRequest, Contrato>();
            CreateMap<Contrato, ContratoResponse>();
        }
    }
}
