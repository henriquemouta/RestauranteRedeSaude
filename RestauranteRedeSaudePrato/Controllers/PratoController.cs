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
            public async Task<ActionResult<ModelodeResposta>> GetPratos()
            {
                var pratos = await servicoPrato.GetPratos();
                return Ok(new ModelodeResposta { sucesso = true, info = pratos });
            }

        [HttpGet("id")]
        public async Task<ActionResult<ModelodeResposta>> GetPratoId(int id)
        {
            var prato = await servicoPrato.GetPratoId(id);
            if (prato == null)
            {
                return Ok(new ModelodeResposta { sucesso = false, erro = "um erro aconteceu" });
            }
            return Ok(new ModelodeResposta { sucesso = true, info = prato });

        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeletePrato(int id)
        {
            await servicoPrato.DeletePrato(id);
            return Ok(new ModelodeResposta { sucesso = true });
        }


        [HttpPost]
        public async Task<ActionResult<PratoVM>> AddPrato(PratoVM prato)
        {
            await servicoPrato.AddPrato(prato);
            return Ok(new ModelodeResposta { sucesso = true });
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdatePrato(int id, PratoVM prato)
        {
            if (id != prato.id)
            {
                return Ok(new ModelodeResposta { sucesso = false, erro = "um erro aconteceu" });
            }
            await servicoPrato.UpdatePrato(prato);
            return Ok(new ModelodeResposta { sucesso = true });
        }
    }
}
