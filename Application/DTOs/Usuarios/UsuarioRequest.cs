using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTOs.Usuarios
{
    public class UsuarioRequest
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [Required]
        public string NomeDoUsuario { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string SenhaDoUsuario { get; set; }
        [Required]
        [Compare("SenhaDoUsuario")]
        public string ConfirmarSenha { get; set; }
        public bool IsAdmin { get; set; }
    }
}
