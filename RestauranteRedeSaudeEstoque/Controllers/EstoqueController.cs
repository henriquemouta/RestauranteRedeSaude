using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Models.ViewModels;
using ViewsModels.ViewsModels.Estoque;

namespace RestauranteRedeSaudeEstoque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController(IServicoEstoque servicoEstoque) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ModelodeResposta<IQueryable<EstoqueVM>>>> getEstoque()
        {
            var estoque = await servicoEstoque.getEstoque();
            return Ok(new ModelodeResposta<IQueryable<EstoqueVM>> { sucesso = true, info = estoque });
        }

        [HttpPost]
        public async Task<ActionResult<ModelodeResposta<EstoqueIncluirVM>>> addEstoque(EstoqueIncluirVM item)
        {
            await servicoEstoque.addEstoque(item);
            return Ok(new ModelodeResposta<EstoqueIncluirVM> { sucesso = true , info = item});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ModelodeResposta<EstoqueUpdateVM>>> updateEstoque(int id, EstoqueUpdateVM estoque)
        {
            if (id != estoque.id || !await servicoEstoque.estoqueExiste(id))
            {
                return Ok(new ModelodeResposta<EstoqueUpdateVM> { sucesso = false, erro = "ID INVÁLIDO" });

            }

            await servicoEstoque.updateEstoque(estoque);
            return Ok(new ModelodeResposta<EstoqueUpdateVM> { sucesso = true, info = estoque});

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteEstoque(int id)
        {
            if (!await servicoEstoque.estoqueExiste(id))
            {
                return Ok(new ModelodeResposta<EstoqueVM> { sucesso = false, erro = $"Estoque item {id} NÃO ENCONTRADO" });
            }

            await servicoEstoque.deleteEstoque(id);
            return Ok(new ModelodeResposta<EstoqueVM> { sucesso = true });
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ModelodeResposta<EstoqueVM>>> getEstoqueId(int id)
        {
            
            var estoque = await servicoEstoque.getEstoqueId(id);
            if (estoque == null)
            {
                return Ok(new ModelodeResposta<EstoqueVM> { sucesso = false, erro = "Estoque item não encontrado" });
            }
            return Ok(new ModelodeResposta<EstoqueVM> { sucesso = true, info = estoque });

        }

        
    }
}
