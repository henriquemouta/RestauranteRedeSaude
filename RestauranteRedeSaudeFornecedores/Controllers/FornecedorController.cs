using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewsModels;
using ViewsModels.Fornecedor;

namespace RestauranteRedeSaudeFornecedores.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController(IServicoFornecedor servicoFornecedor) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ModelodeResposta<List<FornecedorVM>>>> get([FromQuery] FornecedorFiltro filtro)
        {
            try
            {
                var fornecedores = await servicoFornecedor.get(filtro);
                return Ok(new ModelodeResposta<List<FornecedorVM>> { sucesso = true, info = fornecedores });
            }
            catch (Exception ex)
            {
                return BadRequest(new ModelodeResposta<List<FornecedorVM>> { sucesso = false, erro = ex.Message });
            }
        }


        [HttpPost]
        public async Task<ActionResult<ModelodeResposta<FornecedorIncluirVM>>> add([FromBody] FornecedorIncluirVM item)
        {
            try
            {
                if (item == null)
                {
                    return BadRequest(new ModelodeResposta<FornecedorIncluirVM> { sucesso = false, erro = "Item inválido" });
                }
                await servicoFornecedor.add(item);
                return Ok(new ModelodeResposta<FornecedorIncluirVM> { sucesso = true, info = item });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ModelodeResposta<FornecedorUpdateVM>>> update(int id, [FromBody] FornecedorUpdateVM fornecedor)
        {
            try
            {
                if (id > 0 && fornecedor != null)
                {
                    await servicoFornecedor.update(id, fornecedor);
                }
                return Ok(new ModelodeResposta<FornecedorUpdateVM> { sucesso = true, info = fornecedor });
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
                await servicoFornecedor.delete(id);
                return Ok(new ModelodeResposta<FornecedorVM> { sucesso = true });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ModelodeResposta<FornecedorVM>>> getId(int id)
        {
            try
            {
                var estoque = await servicoFornecedor.getId(id);
                return Ok(new ModelodeResposta<FornecedorVM> { sucesso = true, info = estoque });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
