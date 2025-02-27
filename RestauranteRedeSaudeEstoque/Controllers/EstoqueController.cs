using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Models.ViewModels;

namespace RestauranteRedeSaudeEstoque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController(IServicoEstoque servicoEstoque) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ModelodeResposta>> getEstoque()
        {
            var estoque = await servicoEstoque.getEstoque();
            return Ok(new ModelodeResposta { sucesso = true, info = estoque });
        }

        [HttpPost]
        public async Task<ActionResult<Estoque>> addEstoque(Estoque item)
        {
            await servicoEstoque.addEstoque(item);
            return Ok(new ModelodeResposta { sucesso = true });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateEstoque(int id, Estoque estoque)
        {
            if (id != estoque.id || !await servicoEstoque.estoqueExiste(id))
            {
                return Ok(new ModelodeResposta { sucesso = false, erro = "ID INVÁLIDO" });

            }

            await servicoEstoque.updateEstoque(estoque);
            return Ok(new ModelodeResposta { sucesso = true});

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> deleteEstoque(int id)
        {
            if (!await servicoEstoque.estoqueExiste(id))
            {
                return Ok(new ModelodeResposta { sucesso = false, erro = $"Estoque item {id} NÃO ENCONTRADO" });
            }

            await servicoEstoque.deleteEstoque(id);
            return Ok(new ModelodeResposta { sucesso = true });
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ModelodeResposta>> getEstoqueId(int id)
        {
            
            var estoque = await servicoEstoque.getEstoqueId(id);
            if (estoque == null)
            {
                return Ok(new ModelodeResposta { sucesso = false, erro = "Estoque item não encontrado" });
            }
            return Ok(new ModelodeResposta { sucesso = true, info = estoque });

        }

        
    }
}
