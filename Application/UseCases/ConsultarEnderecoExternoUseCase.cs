using Application.DTOs;
using Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class ConsultarEnderecoExternoUseCase
    {
        private readonly IEnderecoExternoService _enderecoExternoService;
        public ConsultarEnderecoExternoUseCase(IEnderecoExternoService enderecoExternoService)
        {
            _enderecoExternoService = enderecoExternoService;
        }
        public async Task<EnderecoResponse> ConsultarCepAsync(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
            {
                throw new ArgumentException("CEP não pode ser vazio ou nulo.", nameof(cep));
            }
            return await _enderecoExternoService.ConsultarCepAsync(cep);
        }
    }
}
