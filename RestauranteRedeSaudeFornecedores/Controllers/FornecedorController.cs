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
        public async Task<ActionResult<ModelodeResposta<List<Fornecedor>>>> getFornecedores()
        {
            var fornecedores = await servicoFornecedor.getFornecedores();
            return Ok(new ModelodeResposta<List<Fornecedor>> { sucesso = true, info = fornecedores });
        }

        [HttpGet("id")]
        public async Task<ActionResult<Fornecedor>> getFornecedorId(int id)
        {
            var fornecedor = await servicoFornecedor.getFornecedorId(id);
            if (fornecedor == null)
            {
                return Ok(new ModelodeResposta<Fornecedor> { sucesso = false, erro = "um erro aconteceu" });
            }
            return Ok(new ModelodeResposta<Fornecedor> { sucesso = true, info = fornecedor });
        }

        [HttpPost]
        public async Task<ActionResult<Fornecedor>> addFornecedor(Fornecedor fornecedor)
        {
            await servicoFornecedor.addFornecedor(fornecedor);
            return Ok(new ModelodeResposta<Fornecedor> { sucesso = true });
        }

        [HttpPut("id")]
        public async Task<IActionResult> updateFornecedor(int id, Fornecedor fornecedor)
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
