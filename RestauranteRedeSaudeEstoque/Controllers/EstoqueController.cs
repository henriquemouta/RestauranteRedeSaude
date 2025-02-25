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
        
        public async Task<ActionResult<ModelodeResposta>> GetEstoque()
        {
            var estoque = await servicoEstoque.GetEstoque();
            return Ok(new ModelodeResposta { sucesso = true, info = estoque });
        }

        [HttpPost]
        public async Task<ActionResult<EstoqueVM>> CreateProduct(EstoqueVM item)
        {
            await servicoEstoque.CreateEstoqueItem(item);
            return Ok(new ModelodeResposta { sucesso = true });


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstoque(int id, EstoqueVM estoque)
        {
            if (id != estoque.ID || !await servicoEstoque.EstoqueExiste(id))
            {
                return Ok(new ModelodeResposta { sucesso = false, erro = "ID INVÁLIDO" });

            }

            await servicoEstoque.UpdateEstoqueItem(estoque);
            return Ok(new ModelodeResposta { sucesso = true});

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (!await servicoEstoque.EstoqueExiste(id))
            {
                return Ok(new ModelodeResposta { sucesso = false, erro = $"Estoque item {id} NÃO ENCONTRADO" });
            }

            await servicoEstoque.DeleteEstoqueItem(id);
            return Ok(new ModelodeResposta { sucesso = true });
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ModelodeResposta>> GetEstoque(int id)
        {
            var estoqueitem = await servicoEstoque.GetEstoqueU(id);
            return Ok(new ModelodeResposta { sucesso = true, info = estoqueitem });

        }




    }
}
