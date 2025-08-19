

using Application.Arquivos;
using Application.DTOs.Clientes;
using Application.DTOs.Contrato;
using Application.DTOs.Parceiro;
using Application.DTOs.Usuarios;
using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Application.UseCases;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Service;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IArquivoService, ArquivoService>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ILoginUseCase, LoginUseCase>();
builder.Services.AddScoped<IUseCaseGeneric<ClienteRequest, ClienteResponse>, UseCaseGeneric<Cliente, ClienteRequest, ClienteResponse>>();
builder.Services.AddScoped<IUseCaseGeneric<ContratoRequest, ContratoResponse>, UseCaseGeneric<Contrato, ContratoRequest, ContratoResponse>>();
builder.Services.AddScoped<IUseCaseGeneric<UsuarioRequest, UsuarioResponse>, UseCaseGeneric<Usuarios, UsuarioRequest, UsuarioResponse>>();
builder.Services.AddScoped<IUseCaseGeneric<ParceiroRequest, ParceiroResponse>, UseCaseGeneric<Parceiro, ParceiroRequest, ParceiroResponse>>();
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<ProfileMapper>());
builder.Services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));
builder.Services.AddScoped(typeof(IServiceGeneric<>), typeof(ServiceGeneric<>));
builder.Services.AddMediatR(typeof(UploadMultiplosArquivosCommandHandler).Assembly);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:4200");
    });
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

app.UseAuthorization();

app.MapControllers();

app.Run();
