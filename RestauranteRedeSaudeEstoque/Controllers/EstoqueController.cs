using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using ViewsModels;
using ViewsModels.Estoques;

namespace RestauranteRedeSaudeEstoque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController(IServicoEstoque servicoEstoques) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ModelodeResposta<List<EstoquesVM>>>> get([FromQuery] EstoquesFiltro filtro)
        {
            try
            {
                var estoque = await servicoEstoques.get(filtro);
                return Ok(new ModelodeResposta<List<EstoquesVM>> { sucesso = true, info = estoque });
            }
            catch (Exception ex)
            {
                return BadRequest(new ModelodeResposta<List<EstoquesVM>> { sucesso = false, erro = ex.Message });
            }
        }


        [HttpPost]
        public async Task<ActionResult<ModelodeResposta<EstoquesIncluirVM>>> add([FromBody] EstoquesIncluirVM item)
        {
            try
            {
                if (item == null)
                {
                    return BadRequest(new ModelodeResposta<EstoquesIncluirVM> { sucesso = false, erro = "Item inválido" });
                }
                await servicoEstoques.add(item);
                return Ok(new ModelodeResposta<EstoquesIncluirVM> { sucesso = true, info = item });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ModelodeResposta<EstoquesUpdateVM>>> update(int id, [FromBody] EstoquesUpdateVM estoque)
        {
            try
            {
                if (id > 0 && estoque != null)
                {
                    await servicoEstoques.update(id, estoque);
                }
                return Ok(new ModelodeResposta<EstoquesUpdateVM> { sucesso = true, info = estoque });
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
                await servicoEstoques.delete(id);
                return Ok(new ModelodeResposta<EstoquesVM> { sucesso = true });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ModelodeResposta<EstoquesVM>>> getId(int id)
        {
            try
            {
                var estoque = await servicoEstoques.getId(id);
                return Ok(new ModelodeResposta<EstoquesVM> { sucesso = true, info = estoque });
            }
            catch (Exception ex) 
            { 
                throw new Exception( ex.Message);
            }
            
        }

    }
}
