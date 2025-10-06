using Microsoft.AspNetCore.Mvc;

namespace Iventis.App.Controllers
{
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        [HttpGet]
        [Route("get-locacao")]
        public IActionResult GetLocacao()
        {
            return Ok();
        }
    }
}
