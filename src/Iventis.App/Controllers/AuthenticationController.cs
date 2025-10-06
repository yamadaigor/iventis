using Iventis.Domain.DTO;
using Iventis.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Iventis.App.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        public AuthenticationService _authenticationService;
        public AuthenticationController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        // login com os dados do usuário
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var result = await _authenticationService.SignInManager.PasswordSignInAsync(login.Email, login.Senha,
                false, true);

            if (result.Succeeded)
            {
                var token = await _authenticationService.CreateToken(login.Email);
                return Ok(token);
            }

            return BadRequest("Erro ao auteticar. Por Favor, tente novamente.");
        }

        [HttpPost("registrar-usuario")]
        public async Task<ActionResult> RegistrarUsuario(UsuarioRegistroDTO usuarioRegistro)
        {
            try
            {
                // usar o validador aqui para validar se os dados do usuário estão preenchidos
                var result = await _authenticationService.RegisterUser(usuarioRegistro);

                if (result.Success)
                {
                    //depois de registrar, pega o usuário e retorna o token
                    var token = await _authenticationService.CreateToken(usuarioRegistro.Email);

                    return Ok(token);
                }
                return BadRequest(result.ErrorMessages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
