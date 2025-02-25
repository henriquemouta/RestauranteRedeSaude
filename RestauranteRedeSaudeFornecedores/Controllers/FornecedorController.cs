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
        public async Task<ActionResult<ModelodeResposta>> GetFornecedores()
        {
            var fornecedores = await servicoFornecedor.GetFornecedores();
            return Ok(new ModelodeResposta { Sucesso = true, Info = fornecedores });
        }

        [HttpGet("id")]
        public async Task<ActionResult<FornecedorVM>> GetFornecedorId(int id)
        {
            var fornecedor = servicoFornecedor.GetFornecedorId(id);
            if (fornecedor == null)
            {
                return Ok(new ModelodeResposta { Sucesso = false, Erro = "um erro aconteceu" });
            }
            return Ok(new ModelodeResposta { Sucesso = true, Info = fornecedor });
        }

        [HttpPost]
        public async Task<ActionResult<FornecedorVM>> AddFornecedor(FornecedorVM fornecedor)
        {
            await servicoFornecedor.AddFornecedor(fornecedor);
            return Ok(new ModelodeResposta { Sucesso = true });
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateFornecedor(int id, FornecedorVM fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return Ok(new ModelodeResposta { Sucesso = false, Erro = "um erro aconteceu" });
            }
            await servicoFornecedor.UpdateFornecedor(fornecedor);
            return Ok(new ModelodeResposta { Sucesso = true });

        }


        [HttpDelete("id")]
        public async Task<IActionResult> DeleteFornecedor(int id)
        {
            await servicoFornecedor.DeleteFornecedor(id);
            return Ok(new ModelodeResposta { Sucesso = true});
        }
    }
}
