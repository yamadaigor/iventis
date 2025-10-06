using Microsoft.AspNetCore.Mvc;

namespace Iventis.App.Controllers
{
    [ApiController]
    public class MotoController : ControllerBase
    {
        // Colocar Filtros para claims.
        [HttpGet]
        [Route("get-moto")]
        public IActionResult GetMoto()
        {
            return Ok();
        }
    }
}
