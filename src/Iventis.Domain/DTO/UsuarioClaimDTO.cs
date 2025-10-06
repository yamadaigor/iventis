using System.Security.Claims;

namespace Iventis.Domain.DTO
{
    public class UsuarioClaimDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }
}
