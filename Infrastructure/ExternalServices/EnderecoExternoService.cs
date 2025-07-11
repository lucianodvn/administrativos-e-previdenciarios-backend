using Application.DTOs;
using Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.ExternalServices
{
    public class EnderecoExternoService : IEnderecoExternoService
    {
        private readonly HttpClient _httpClient;

        public EnderecoExternoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<EnderecoResponse> ConsultarCepAsync(string cep)
        {
            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<EnderecoResponse>(content);
            }

            return default;
        }
    }
}
