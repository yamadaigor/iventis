using Iventis.Domain.DTO;
using Iventis.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Iventis.App.Controllers
{
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private ILocacaoService _locacaoService;

        public LocacaoController(ILocacaoService locacaoService)
        {
                _locacaoService = locacaoService;
        }

        [HttpGet]
        [Route("locacao")]
        public async Task<IActionResult> Locacao(LocacaoDTO locacao)
        {
            try
            {
                var result = await _locacaoService.LocarMoto(locacao);

                if (result.Success)
                    return Ok("Locação Efetuada com sucesso.");

                return BadRequest(result.ErrorMessages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("locacao/{id}")]
        public async Task<IActionResult> GetLocacaoById(string id)
        {
            try
            {
                var result = await _locacaoService.GetLocacaoById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
