using Microsoft.AspNetCore.Mvc;

namespace Iventis.App.Controllers
{
    [ApiController]
    public class MotoController : ControllerBase
    {
        // Colocar Filtros para claims.

        public IActionResult Index()
        {
            return Ok();
        }
    }
}
