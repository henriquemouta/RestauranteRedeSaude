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
        public async Task<ActionResult<ModelodeResposta>> GetFuncionarios()
        {
            var funcionarios = await servicoFuncionario.GetFuncionarios();
            return Ok(new ModelodeResposta { sucesso = true , info = funcionarios });
        }

        [HttpPost]
        public async Task<ActionResult<FuncionarioVM>> AddFuncionario(FuncionarioVM funcionario)
        {
            await servicoFuncionario.AddFuncionario(funcionario);
            return Ok(new ModelodeResposta { sucesso = true});
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteFuncionario(int id)
        {
            await servicoFuncionario.DeleteFuncionario(id);
            return Ok(new ModelodeResposta { sucesso = true });
        }

        [HttpGet("id")]
        public async Task<ActionResult<FuncionarioVM>> GetFuncionarioId(int id)
        {
            var funcionario = servicoFuncionario.GetFuncionarioId(id);
            if (funcionario == null)
            {
                return Ok(new ModelodeResposta { sucesso = false, erro = "deu ruimpaizao" });
            }
            return Ok(new ModelodeResposta { sucesso = true, info = funcionario });
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateFuncionario(int id, FuncionarioVM funcionario)
        {
            if (id != funcionario.id)
            {
                return Ok(new ModelodeResposta { sucesso = false, erro = "deu errado paizao" });
            }
            await servicoFuncionario.UpdateFuncionar(funcionario);
            return Ok(new ModelodeResposta { sucesso = true });
        }
    }
}
