using Iventis.Domain.DTO;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Iventis.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<ErrorMessageDTO> RegisterUser(UsuarioRegistroDTO usuarioRegistro);
        Task<string> CreateToken(string email);
        Task AddClaims(ICollection<Claim> claims, IdentityUser user);
    }
}
