using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Models.Models;
using Models.ViewModels;
using ViewsModels.ViewsModels.Prato;

namespace RestauranteRedeSaudePrato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PratoController(IServicoPrato servicoPrato) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ModelodeResposta<IQueryable<PratoVM>>>> getPratos()
        {
            var pratos = await servicoPrato.getPratos();
            return Ok(new ModelodeResposta<IQueryable<PratoVM>> { sucesso = true, info = pratos });
        }

        [HttpGet("id")]
        public async Task<ActionResult<ModelodeResposta<PratoVM>>> getPratoId(int id)
        {
            var prato = await servicoPrato.getPratoId(id);
            if (prato == null)
            {
                return Ok(new ModelodeResposta<PratoVM> { sucesso = false, erro = "um erro aconteceu" });
            }
            return Ok(new ModelodeResposta<PratoVM> { sucesso = true, info = prato });

        }

        [HttpDelete("id")]
        public async Task<IActionResult> deletePrato(int id)
        {
            await servicoPrato.deletePrato(id);
            return Ok(new ModelodeResposta<Prato> { sucesso = true });
        }


        [HttpPost]
        public async Task<ActionResult<PratoIncluirVM>> addPrato(PratoIncluirVM prato)
        {
            await servicoPrato.addPrato(prato);
            return Ok(new ModelodeResposta<PratoIncluirVM> { sucesso = true , info = prato });
        }

        [HttpPut("id")]
        public async Task<ActionResult<PratoUpdateVM>> updatePrato(int id, PratoUpdateVM prato)
        {
            if (id != prato.id)
            {
                return Ok(new ModelodeResposta<PratoUpdateVM> { sucesso = false, erro = "um erro aconteceu" });
            }
            await servicoPrato.updatePrato(prato);
            return Ok(new ModelodeResposta<PratoUpdateVM> { sucesso = true , info = prato});
        }
    }
}
