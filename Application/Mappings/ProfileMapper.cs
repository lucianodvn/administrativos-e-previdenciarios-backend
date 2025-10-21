﻿using Application.DTOs.Agendamento;
using Application.DTOs.BeneficiosServicos;
using Application.DTOs.Clientes;
using Application.DTOs.ContasAPagar;
using Application.DTOs.ContasAReceber;
using Application.DTOs.Contrato;
using Application.DTOs.EtapaServico;
using Application.DTOs.Fornecedor;
using Application.DTOs.Parceiro;
using Application.DTOs.Recibo;
using Application.DTOs.Usuarios;
using Application.DTOs.VinculoClienteBeneficioEtapa;
using Application.DTOs.VinculoClienteParceiro;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Mappings
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<ClienteRequest, Cliente>();
            CreateMap<Cliente, ClienteResponse>();
            CreateMap<ContratoRequest, Contrato>();
            CreateMap<Contrato, ContratoResponse>()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente));
            CreateMap<UsuarioRequest, Usuarios>();
            CreateMap<Usuarios, UsuarioResponse>()
                .ForMember(dest => dest.NomeDoUsuario, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.SenhaDoUsuario, opt => opt.Ignore());
            CreateMap<ParceiroRequest, Parceiro>();
            CreateMap<Parceiro, ParceiroResponse>();
            CreateMap<ReciboRequest, Recibo>();
            CreateMap<Recibo, ReciboResponse>();
            CreateMap<ContasAReceberRequest, ContasAReceber>();
            CreateMap<ContasAReceber, ContasAReceberResponse>()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente))
                .ForMember(dest => dest.Fornecedor, opt => opt.MapFrom(src => src.Fornecedor))
                .ForMember(dest => dest.Parceiro, opt => opt.MapFrom(src => src.Parceiro))
                .ForMember(dest => dest.Contrato, opt => opt.MapFrom(src => src.Contrato));
            CreateMap<BeneficiosServicosRequest, BeneficiosServicos>();
            CreateMap<BeneficiosServicos, BeneficiosServicosResponse>();
            CreateMap<EtapaServicoRequest, EtapaServico>();
            CreateMap<EtapaServico, EtapaServicoResponse>();
            CreateMap<ContasAPagarRequest, ContasAPagar>();
            CreateMap<ContasAPagar, ContasAPagarResponse>()
                .ForMember(dest => dest.Fornecedor, opt => opt.MapFrom(src => src.Fornecedor))
                .ForMember(dest => dest.Parceiro, opt => opt.MapFrom(src => src.Parceiro));
            CreateMap<AgendamentoRequest, Agendamento>();
            CreateMap<Agendamento, AgendamentoResponse>();
            CreateMap<VinculoClienteBeneficioEtapaRequest, VinculoClienteBeneficioEtapa>();
            CreateMap<FornecedorRequest, Fornecedor>();
            CreateMap<Fornecedor, FornecedorResponse>();
            CreateMap<VinculoClienteBeneficioEtapa, VinculoClienteBeneficioEtapaResponse>()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente))
                .ForMember(dest => dest.EtapaServico, opt => opt.MapFrom(src => src.EtapaServico))
                .ForMember(dest => dest.BeneficiosServicos, opt => opt.MapFrom(src => src.BeneficiosServicos));
            CreateMap<VinculoClienteParceiroRequest, VinculoClienteParceiro>();
            CreateMap<VinculoClienteParceiro, VinculoClienteParceiroResponse>()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente))
                .ForMember(dest => dest.Parceiro, opt => opt.MapFrom(src => src.Parceiro));
            CreateMap<ContratoJudicialRequest, ContratoJudicial>()
                .ForMember(dest => dest.TipoDeContrato, opt => opt.MapFrom(src => src.TipoDeContrato.ToTipoDeContratoEnum()));
            CreateMap<ContratoJudicial, ContratoJudicialResponse>()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente))
                .ForMember(dest => dest.Parceiro, opt => opt.MapFrom(src => src.Parceiro));
        }
    }
}
