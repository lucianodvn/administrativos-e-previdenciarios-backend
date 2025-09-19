using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class Usuarios : IdentityUser
    {
        public Usuarios() : base() { }
        public bool IsAdmin { get; set; }
    }
}
