using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using ViewsModels;
using ViewsModels.Estoques;

namespace RestauranteRedeSaudeEstoque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController(IServicoEstoque servicoEstoque) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ModelodeResposta<List<EstoquesVM>>>> getEstoque()
        {
            var estoque = await servicoEstoque.get();
            return Ok(new ModelodeResposta<List<EstoquesVM>> { sucesso = true, info = estoque });
        }

        [HttpPost]
        public async Task<ActionResult<ModelodeResposta<EstoquesIncluirVM>>> addEstoque(EstoquesIncluirVM item)
        {
            await servicoEstoque.add(item);
            return Ok(new ModelodeResposta<EstoquesIncluirVM> { sucesso = true, info = item });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ModelodeResposta<EstoquesUpdateVM>>> updateEstoque(int id, EstoquesUpdateVM estoque)
        {
            await servicoEstoque.update(id, estoque);
            return Ok(new ModelodeResposta<EstoquesUpdateVM> { sucesso = true, info = estoque });

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteEstoque(int id)
        {
            await servicoEstoque.delete(id);
            return Ok(new ModelodeResposta<EstoquesVM> { sucesso = true });
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ModelodeResposta<EstoquesVM>>> getEstoqueId(int id)
        {

            var estoque = await servicoEstoque.getId(id);
            return Ok(new ModelodeResposta<EstoquesVM> { sucesso = true, info = estoque });

        }


    }
}
