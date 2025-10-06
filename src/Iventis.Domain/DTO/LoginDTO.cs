using System.ComponentModel.DataAnnotations;

namespace Iventis.Domain.DTO
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
