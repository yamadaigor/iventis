using Iventis.Domain.DTO;
using Iventis.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Iventis.App.Controllers
{
    [ApiController]
    public class EntregadorController : ControllerBase
    {
        public readonly IEntregadorService _entregadorService;

        public EntregadorController(IEntregadorService entregadorService)
        {
                _entregadorService = entregadorService;
        }

        [HttpPost]
        [Route("entregadores")]
        public async Task<IActionResult> AddEntregador(EntregadorDTO entregadorDto)
        {
            try
            {
                var result = await _entregadorService.AddEntregador(entregadorDto);

                if (result.Success)
                    return Ok("Entregador Cadastrado com sucesso.");

                return BadRequest(result.ErrorMessages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("entregadores/{id}/cnh")]
        public async Task<IActionResult> UpdatePlacaMoto(string id, [FromBody] CnhDTO cnh)
        {
            try
            {
                var result = await _entregadorService.EnvarFotoCnh(id, cnh);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
