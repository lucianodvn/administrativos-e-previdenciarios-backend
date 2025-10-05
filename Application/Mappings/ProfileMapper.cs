using Application.DTOs.BeneficiosServicos;
using Application.DTOs.Clientes;
using Application.DTOs.ContasAPagar;
using Application.DTOs.ContasAReceber;
using Application.DTOs.Contrato;
using Application.DTOs.EtapaServico;
using Application.DTOs.Parceiro;
using Application.DTOs.Recibo;
using Application.DTOs.Usuarios;
using Application.DTOs.VinculoClienteBeneficioEtapa;
using Application.DTOs.VinculoClienteParceiro;
using AutoMapper;
using Domain.Entities;

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
            CreateMap<UsuarioRequest, Usuarios>();
            CreateMap<Usuarios, UsuarioResponse>()
                .ForMember(dest => dest.NomeDoUsuario, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.SenhaDoUsuario, opt => opt.Ignore());
            CreateMap<ParceiroRequest, Parceiro>();
            CreateMap<Parceiro, ParceiroResponse>();
            CreateMap<ReciboRequest, Recibo>();
            CreateMap<Recibo, ReciboResponse>();
            CreateMap<ContasAReceberRequest, ContasAReceber>();
            CreateMap<ContasAReceber, ContasAReceberResponse>();
            CreateMap<BeneficiosServicosRequest, BeneficiosServicos>();
            CreateMap<BeneficiosServicos, BeneficiosServicosResponse>();
            CreateMap<EtapaServicoRequest, EtapaServico>();
            CreateMap<EtapaServico, EtapaServicoResponse>();
            CreateMap<ContasAPagarRequest, ContasAPagar>();
            CreateMap<ContasAPagar, ContasAPagarResponse>();
            CreateMap<VinculoClienteBeneficioEtapaRequest, VinculoClienteBeneficioEtapa>();
            CreateMap<VinculoClienteBeneficioEtapa, VinculoClienteBeneficioEtapaResponse>()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente))
                .ForMember(dest => dest.EtapaServico, opt => opt.MapFrom(src => src.EtapaServico))
                .ForMember(dest => dest.BeneficiosServicos, opt => opt.MapFrom(src => src.BeneficiosServicos));
            CreateMap<VinculoClienteParceiroRequest, VinculoClienteParceiro>();
            CreateMap<VinculoClienteParceiro, VinculoClienteParceiroResponse>()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente))
                .ForMember(dest => dest.Parceiro, opt => opt.MapFrom(src => src.Parceiro));
        }
    }
}
