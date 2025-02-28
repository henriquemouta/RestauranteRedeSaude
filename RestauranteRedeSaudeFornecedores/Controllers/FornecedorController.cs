using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using ViewsModels;
using ViewsModels.ViewsModels.Fornecedor;

namespace RestauranteRedeSaudeFornecedores.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController(IServicoFornecedor servicoFornecedor) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ModelodeResposta<IQueryable<FornecedorVM>>>> getFornecedores()
        {
            var fornecedores = await servicoFornecedor.getFornecedores();
            return Ok(new ModelodeResposta<IQueryable<FornecedorVM>> { sucesso = true, info = fornecedores });
        }

        [HttpGet("id")]
        public async Task<ActionResult<FornecedorVM>> getFornecedorId(int id)
        {
            var fornecedor = await servicoFornecedor.getFornecedorId(id);
            if (fornecedor == null)
            {
                return Ok(new ModelodeResposta<FornecedorVM> { sucesso = false, erro = "um erro aconteceu" });
            }
            return Ok(new ModelodeResposta<FornecedorVM> { sucesso = true, info = fornecedor });
        }

        [HttpPost]
        public async Task<ActionResult<FornecedorIncluirVM>> addFornecedor(FornecedorIncluirVM fornecedor)
        {
            await servicoFornecedor.addFornecedor(fornecedor);
            return Ok(new ModelodeResposta<FornecedorIncluirVM> { sucesso = true });
        }

        [HttpPut("id")]
        public async Task<ActionResult<ModelodeResposta<FornecedorUpdateVM>>> updateFornecedor(int id, FornecedorUpdateVM fornecedor)
        {
            if (id != fornecedor.id)
            {
                return Ok(new ModelodeResposta<Fornecedor> { sucesso = false, erro = "um erro aconteceu" });
            }

            await servicoFornecedor.updateFornecedor(fornecedor);
            return Ok(new ModelodeResposta<Fornecedor> { sucesso = true });

        }


        [HttpDelete("id")]
        public async Task<IActionResult> deleteFornecedor(int id)
        {
            await servicoFornecedor.deleteFornecedor(id);
            return Ok(new ModelodeResposta<Fornecedor> { sucesso = true});
        }
    }
}
