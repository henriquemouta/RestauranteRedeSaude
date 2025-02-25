using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

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

    }
}
