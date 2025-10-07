using Iventis.Domain.DTO;
using Iventis.Domain.Entities;
using Iventis.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Iventis.App.Controllers
{
    [ApiController]
    public class MotoController : ControllerBase
    {
        private readonly IMotoService _motoService;
        public MotoController(IMotoService motoService)
        {
            _motoService = motoService;
        }

        // Colocar Filtros para claims.
        [HttpPost]
        [Route("motos")]
        public async Task<IActionResult> AddMoto(MotoDTO moto)
        {
            try
            {
                var result = await _motoService.AddMoto(moto);

                if (result.Success)
                    return Ok("Moto Cadastrada com sucesso.");

                return BadRequest(result.ErrorMessages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("motos")]
        public async Task<IActionResult> GetMotoByPlaca(string placa)
        {
            try
            {
                var result = await _motoService.GetMotos(placa);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("motos/{id}/placa")]
        public async Task<IActionResult> UpdatePlacaMoto(string id,[FromBody] PlacaDTO placa)
        {
            try
            {
                var result = await _motoService.UpdatePlaca(id,placa);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("motos/{id}")]
        public async Task<IActionResult> GetMotoById(string id)
        {
            try
            {
                var result = await _motoService.GetMotoById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("motos/{id}")]
        public async Task<IActionResult> DeleteMoto(string id)
        {
            try
            {
                var result = await _motoService.DeleteMoto(id);

                if (result.Success)
                    return Ok("Moto Deletada com sucesso.");

                return BadRequest(result.ErrorMessages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
