namespace Iventis.Domain.DTO
{
    public class UsuarioTokenDTO
    {
        public string AccessToken { get; set; }
        public UsuarioClaimDTO UsuarioToken { get; set; }
    }
}
