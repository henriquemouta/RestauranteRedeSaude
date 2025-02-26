using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Models.ViewModels;

namespace RestauranteRedeSaudeFornecedores.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController(IServicoFornecedor servicoFornecedor) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ModelodeResposta>> getFornecedores()
        {
            var fornecedores = await servicoFornecedor.getFornecedores();
            return Ok(new ModelodeResposta { sucesso = true, info = fornecedores });
        }

        [HttpGet("id")]
        public async Task<ActionResult<FornecedorVM>> getFornecedorId(int id)
        {
            var fornecedor = servicoFornecedor.getFornecedorId(id);
            if (fornecedor == null)
            {
                return Ok(new ModelodeResposta { sucesso = false, erro = "um erro aconteceu" });
            }
            return Ok(new ModelodeResposta { sucesso = true, info = fornecedor });
        }

        [HttpPost]
        public async Task<ActionResult<FornecedorVM>> addFornecedor(FornecedorVM fornecedor)
        {
            await servicoFornecedor.addFornecedor(fornecedor);
            return Ok(new ModelodeResposta { sucesso = true });
        }

        [HttpPut("id")]
        public async Task<IActionResult> updateFornecedor(int id, FornecedorVM fornecedor)
        {
            if (id != fornecedor.ID)
            {
                return Ok(new ModelodeResposta { sucesso = false, erro = "um erro aconteceu" });
            }
            await servicoFornecedor.updateFornecedor(fornecedor);
            return Ok(new ModelodeResposta { sucesso = true });

        }


        [HttpDelete("id")]
        public async Task<IActionResult> deleteFornecedor(int id)
        {
            await servicoFornecedor.deleteFornecedor(id);
            return Ok(new ModelodeResposta { sucesso = true});
        }
    }
}
