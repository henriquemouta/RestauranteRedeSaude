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
            return Ok(new ModelodeResposta { Sucesso = true, Info = estoque });
        }

        [HttpPost]
        public async Task<ActionResult<EstoqueVM>> CreateProduct(EstoqueVM item)
        {
            await servicoEstoque.CreateEstoqueItem(item);
            return Ok(new ModelodeResposta { Sucesso = true });


        }

    }
}
