using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Models.Models;
using Models.ViewModels;

namespace RestauranteRedeSaudePrato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PratoController(IServicoPrato servicoPrato) : ControllerBase
    {
            [HttpGet]
            public async Task<ActionResult<ModelodeResposta>> getPratos()
            {
                var pratos = await servicoPrato.getPratos();
                return Ok(new ModelodeResposta { sucesso = true, info = pratos });
            }

        [HttpGet("id")]
        public async Task<ActionResult<ModelodeResposta>> getPratoId(int id)
        {
            var prato = await servicoPrato.getPratoId(id);
            if (prato == null)
            {
                return Ok(new ModelodeResposta { sucesso = false, erro = "um erro aconteceu" });
            }
            return Ok(new ModelodeResposta { sucesso = true, info = prato });

        }

        [HttpDelete("id")]
        public async Task<IActionResult> deletePrato(int id)
        {
            await servicoPrato.deletePrato(id);
            return Ok(new ModelodeResposta { sucesso = true });
        }


        [HttpPost]
        public async Task<ActionResult<Prato>> addPrato(Prato prato)
        {
            await servicoPrato.addPrato(prato);
            return Ok(new ModelodeResposta { sucesso = true });
        }

        [HttpPut("id")]
        public async Task<IActionResult> updatePrato(int id, Prato prato)
        {
            if (id != prato.id)
            {
                return Ok(new ModelodeResposta { sucesso = false, erro = "um erro aconteceu" });
            }
            await servicoPrato.updatePrato(prato);
            return Ok(new ModelodeResposta { sucesso = true });
        }
    }
}
