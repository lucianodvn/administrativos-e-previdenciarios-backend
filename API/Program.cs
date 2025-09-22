using Application.Arquivos;
using Application.DTOs.BeneficiosServicos;
using Application.DTOs.Clientes;
using Application.DTOs.ContasAPagar;
using Application.DTOs.ContasAReceber;
using Application.DTOs.Contrato;
using Application.DTOs.EtapaServico;
using Application.DTOs.Parceiro;
using Application.DTOs.Recibo;
using Application.DTOs.Usuarios;
using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Application.UseCases;
using Domain.Entities;
using Domain.Interfaces;
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
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<AgendaService>();
builder.Services.AddScoped<IUseCaseGeneric<BeneficiosServicosRequest, BeneficiosServicosResponse>, UseCaseGeneric<BeneficiosServicos, BeneficiosServicosRequest, BeneficiosServicosResponse>>();
builder.Services.AddScoped<IUseCaseGeneric<ContasAPagarRequest, ContasAPagarResponse>, UseCaseGeneric<ContasAPagar, ContasAPagarRequest, ContasAPagarResponse>>();
builder.Services.AddScoped<IUseCaseGeneric<EtapaServicoRequest, EtapaServicoResponse>, UseCaseGeneric<EtapaServico, EtapaServicoRequest, EtapaServicoResponse>>();
builder.Services.AddScoped<IUseCaseGeneric<ClienteRequest, ClienteResponse>, UseCaseGeneric<Cliente, ClienteRequest, ClienteResponse>>();
builder.Services.AddScoped<IUseCaseGeneric<ContratoRequest, ContratoResponse>, UseCaseGeneric<Contrato, ContratoRequest, ContratoResponse>>();
builder.Services.AddScoped<IUseCaseGeneric<UsuarioRequest, UsuarioResponse>, UseCaseGeneric<Usuarios, UsuarioRequest, UsuarioResponse>>();
builder.Services.AddScoped<IUseCaseGeneric<ParceiroRequest, ParceiroResponse>, UseCaseGeneric<Parceiro, ParceiroRequest, ParceiroResponse>>();
builder.Services.AddScoped<IUseCaseGeneric<ReciboRequest, ReciboResponse>, UseCaseGeneric<Recibo, ReciboRequest, ReciboResponse>>();
builder.Services.AddScoped<IUseCaseGeneric<ContasAReceberRequest, ContasAReceberResponse>, UseCaseGeneric<ContasAReceber, ContasAReceberRequest, ContasAReceberResponse>>();
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<ProfileMapper>());
builder.Services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));
builder.Services.AddScoped(typeof(IServiceGeneric<>), typeof(ServiceGeneric<>));
builder.Services.AddMediatR(typeof(UploadMultiplosArquivosCommandHandler).Assembly);
builder.Services.AddIdentity<Usuarios, IdentityRole> ()
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
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:4200");
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

// Configure the HTTP request pipeline.
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
