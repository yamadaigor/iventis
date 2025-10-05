using Microsoft.AspNetCore.Mvc;

namespace Iventis.App.Controllers
{
    [ApiController]
    public class EntregadorController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
