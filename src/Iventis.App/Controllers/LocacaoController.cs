using Microsoft.AspNetCore.Mvc;

namespace Iventis.App.Controllers
{
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
