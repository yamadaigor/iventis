using Iventis.Domain.DTO;
using Iventis.Domain.Validators;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Iventis.Domain.Services
{
    public class AuthenticationService : BaseService
    {
        public readonly UserManager<IdentityUser> UserManager;
        public readonly SignInManager<IdentityUser> SignInManager;

        public AuthenticationService(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager
            )
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public async Task<ErrorMessageDTO> RegisterUser(UsuarioRegistroDTO usuarioRegistro)
        {
            var response = new ErrorMessageDTO();

            var (IsValid, errorMessages) = Validate(new UsuarioRegistroValidator(), usuarioRegistro);

            if (IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = usuarioRegistro.Email,
                    Email = usuarioRegistro.Email,
                    EmailConfirmed = true
                };

                var result = await UserManager.CreateAsync(user, usuarioRegistro.Senha);

                if (!result.Succeeded)
                {
                    response.Success = result.Succeeded;
                    response.ErrorMessages.AddRange(result.Errors.Select(e=> e.Description).ToList());
                }
            }
            else
            {
                response.Success = IsValid;
                response.ErrorMessages.AddRange(errorMessages);
            }
            return response;
        }

        public async Task<string> CreateToken(string email)
        {
            var user = await UserManager.FindByEmailAsync(email);
            var claims = await UserManager.GetClaimsAsync(user);

            await AddClaims(claims, user);

            // valores fixos somente para fins de implementação
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("chave-token-0510202574859612365478523698"));// colocar depois no appsettings ou variáveis de ambiente do CI/CD
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "iventis-issuer",// colocar depois no appsettings ou variáveis de ambiente do CI/CD
                audience: "iventis-audience", // colocar depois no appsettings ou variáveis de ambiente do CI/CD
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task AddClaims(ICollection<Claim> claims, IdentityUser user)
        {
            var userRoles = await UserManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.UtcNow.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(),
                ClaimValueTypes.Integer64));
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }
        }
    }
}
