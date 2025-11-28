using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TokenService
    {
        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(Usuarios usuario)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id),
                new Claim(ClaimTypes.Role, usuario.IsAdmin ? "Admin" : "User"),
                new Claim("loginTimestamp", DateTime.UtcNow.ToString())
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SymmetricSecurityKey"]));

            var signingCredentials =
                new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    claims: claims,
                    signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
