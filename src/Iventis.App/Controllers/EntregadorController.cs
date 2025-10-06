using Microsoft.AspNetCore.Mvc;

namespace Iventis.App.Controllers
{
    [ApiController]
    public class EntregadorController : ControllerBase
    {
        [HttpGet]
        [Route("get-entregador")]
        public IActionResult GetEntregador()
        {
            return Ok();
        }
    }
}
