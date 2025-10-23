using Application.Arquivos;
using Application.DTOs.Agendamento;
using Application.DTOs.BeneficiosServicos;
using Application.DTOs.Clientes;
using Application.DTOs.ContasAPagar;
using Application.DTOs.Contrato;
using Application.DTOs.EtapaServico;
using Application.DTOs.Fornecedor;
using Application.DTOs.Parceiro;
using Application.DTOs.Recibo;
using Application.DTOs.Usuarios;
using Application.DTOs.VinculoClienteBeneficioEtapa;
using Application.DTOs.VinculoClienteParceiro;
using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Application.Interfaces.UseCase;
using Application.Mappings;
using Application.Services;
using Application.UseCases;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using Infrastructure.Context;
using Infrastructure.Context.Identity;
using Infrastructure.Repositories;
using Infrastructure.Service;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IArquivoService, ArquivoService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IVinculoClienteRepository, VinculoClienteRepository>();
builder.Services.AddScoped<IVinculoClienteParceiroRepository, VinculoClienteParceiroRepository>();
builder.Services.AddScoped<IContasAPagarRepository, ContasAPagarRepository>();
builder.Services.AddScoped<IContasAReceberRepository, ContasAReceberRepository>();
builder.Services.AddScoped<IContratoRepository, ContratoRepository>();
builder.Services.AddScoped<IContratoJudicialRepository, ContratoJudicialRepository>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<LucroService>();
builder.Services.AddScoped<VinculoClienteService>();
builder.Services.AddScoped<VinculoClienteParceiroService>();
builder.Services.AddScoped<ContasAPagarService>();
builder.Services.AddScoped<ContasAReceberService>();
builder.Services.AddScoped<ContratoService>();
builder.Services.AddScoped<ContratoJudicialService>();
builder.Services.AddScoped<IUseCaseGeneric<BeneficiosServicosRequest, BeneficiosServicosResponse>, UseCaseGeneric<BeneficiosServicos, BeneficiosServicosRequest, BeneficiosServicosResponse>>();
builder.Services.AddScoped<IUseCaseGeneric<ContratoJudicialRequest, ContratoJudicialResponse>, UseCaseGeneric<ContratoJudicial, ContratoJudicialRequest, ContratoJudicialResponse>>();
builder.Services.AddScoped<IUseCaseGeneric<ContasAPagarRequest, ContasAPagarResponse>, UseCaseGeneric<ContasAPagar, ContasAPagarRequest, ContasAPagarResponse>>();
builder.Services.AddScoped<IUseCaseGeneric<EtapaServicoRequest, EtapaServicoResponse>, UseCaseGeneric<EtapaServico, EtapaServicoRequest, EtapaServicoResponse>>();
builder.Services.AddScoped<IUseCaseGeneric<ClienteRequest, ClienteResponse>, UseCaseGeneric<Cliente, ClienteRequest, ClienteResponse>>();
builder.Services.AddScoped<IUseCaseGeneric<ContratoRequest, ContratoResponse>, UseCaseGeneric<Contrato, ContratoRequest, ContratoResponse>>();
builder.Services.AddScoped<IUseCaseGeneric<UsuarioRequest, UsuarioResponse>, UseCaseGeneric<Usuarios, UsuarioRequest, UsuarioResponse>>();
builder.Services.AddScoped<IUseCaseGeneric<ParceiroRequest, ParceiroResponse>, UseCaseGeneric<Parceiro, ParceiroRequest, ParceiroResponse>>();
builder.Services.AddScoped<IUseCaseGeneric<ReciboRequest, ReciboResponse>, UseCaseGeneric<Recibo, ReciboRequest, ReciboResponse>>();
builder.Services.AddScoped<IUseCaseGeneric<FornecedorRequest, FornecedorResponse>, UseCaseGeneric<Fornecedor, FornecedorRequest, FornecedorResponse>>();
builder.Services.AddScoped<IUseCaseGeneric<VinculoClienteBeneficioEtapaRequest, VinculoClienteBeneficioEtapaResponse>, UseCaseGeneric<VinculoClienteBeneficioEtapa, VinculoClienteBeneficioEtapaRequest, VinculoClienteBeneficioEtapaResponse>>();
builder.Services.AddScoped<IUseCaseGeneric<VinculoClienteParceiroRequest, VinculoClienteParceiroResponse>, UseCaseGeneric<VinculoClienteParceiro, VinculoClienteParceiroRequest, VinculoClienteParceiroResponse>>();
builder.Services.AddScoped<IUseCaseGeneric<AgendamentoRequest, AgendamentoResponse>, UseCaseGeneric<Agendamento, AgendamentoRequest, AgendamentoResponse>>();
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<ProfileMapper>());
builder.Services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));
builder.Services.AddScoped(typeof(IServiceGeneric<>), typeof(ServiceGeneric<>));
builder.Services.AddMediatR(typeof(UploadMultiplosArquivosCommandHandler).Assembly);
builder.Services.AddIdentity<Usuarios, IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<TokenService>();

var secretKey = builder.Configuration["SymmetricSecurityKey"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SymmetricSecurityKey"])),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddCors(options =>
{
    //options.AddPolicy("CorsPolicy", policy =>
    //{
    //    policy.WithOrigins("http://localhost:4200")
    //          .AllowAnyHeader()
    //          .AllowAnyMethod();
    //});
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins("http://192.168.0.158:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });

});

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDbContext<DataDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();


app.UseCors("CorsPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

//var app = builder.Build();

//app.UseRouting();
//app.UseCors("CorsPolicy");
//app.UseAuthentication();
//app.UseAuthorization();

//app.UseSwagger();
//app.UseSwaggerUI();

//app.MapControllers();

//app.Run();
