using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Models.ViewModels;

namespace RestauranteRedeSaudeFuncionarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController(IServicoFuncionario servicoFuncionario) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ModelodeResposta>> getFuncionarios()
        {
            var funcionarios = await servicoFuncionario.getFuncionarios();
            return Ok(new ModelodeResposta { sucesso = true , info = funcionarios });
        }

        [HttpPost]
        public async Task<ActionResult<FuncionarioVM>> addFuncionario(FuncionarioVM funcionario)
        {
            await servicoFuncionario.addFuncionario(funcionario);
            return Ok(new ModelodeResposta { sucesso = true});
        }

        [HttpDelete("id")]
        public async Task<IActionResult> deleteFuncionario(int id)
        {
            await servicoFuncionario.deleteFuncionario(id);
            return Ok(new ModelodeResposta { sucesso = true });
        }

        [HttpGet("id")]
        public async Task<ActionResult<FuncionarioVM>> getFuncionarioId(int id)
        {
            var funcionario = servicoFuncionario.getFuncionarioId(id);
            if (funcionario == null)
            {
                return Ok(new ModelodeResposta { sucesso = false, erro = "um erro aconteceu" });
            }
            return Ok(new ModelodeResposta { sucesso = true, info = funcionario });
        }

        [HttpPut("id")]
        public async Task<IActionResult> updateFuncionario(int id, FuncionarioVM funcionario)
        {
            if (id != funcionario.id)
            {
                return Ok(new ModelodeResposta { sucesso = false, erro = "um erro aconteceu" });
            }
            await servicoFuncionario.updateFuncionar(funcionario);
            return Ok(new ModelodeResposta { sucesso = true });
        }


    }
}
