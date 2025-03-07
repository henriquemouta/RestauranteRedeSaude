using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using ViewsModels;
using ViewsModels.Prato;

namespace RestauranteRedeSaudePrato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PratoController(IServicoPrato servicoPrato) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ModelodeResposta<List<PratoVM>>>> get([FromQuery] PratoFiltro filtro)
        {
            try
            {
                var pratos = await servicoPrato.get(filtro);
                return Ok(new ModelodeResposta<List<PratoVM>> { sucesso = true, info = pratos });
            }
            catch (Exception ex)
            {
                return BadRequest(new ModelodeResposta<List<PratoVM>> { sucesso = false, erro = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<ModelodeResposta<PratoIncluirVM>>> add([FromBody] PratoIncluirVM item)
        {
            try
            {
                if (item == null)
                {
                    return BadRequest(new ModelodeResposta<PratoIncluirVM> { sucesso = false, erro = "Item inválido" });
                }
                await servicoPrato.add(item);
                return Ok(new ModelodeResposta<PratoIncluirVM> { sucesso = true, info = item });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ModelodeResposta<PratoUpdateVM>>> update(int id, [FromBody] PratoUpdateVM prato)
        {
            try
            {
                if (id > 0 && prato != null)
                {
                    await servicoPrato.update(id, prato);
                }
                return Ok(new ModelodeResposta<PratoUpdateVM> { sucesso = true, info = prato });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            try
            {
                await servicoPrato.delete(id);
                return Ok(new ModelodeResposta<PratoVM> { sucesso = true });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> delete(PratoFiltro filtro)
        {
            try
            {
                await servicoPrato.delete(filtro);
                return Ok(new ModelodeResposta<PratoVM> { sucesso = true });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ModelodeResposta<PratoVM>>> getId(int id)
        {
            try
            {
                var estoque = await servicoPrato.getId(id);
                return Ok(new ModelodeResposta<PratoVM> { sucesso = true, info = estoque });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
