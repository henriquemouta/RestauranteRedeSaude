using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Models.ViewModels;
using ViewsModels.ViewsModels.Funcionario;

namespace RestauranteRedeSaudeFuncionarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController(IServicoFuncionario servicoFuncionario) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ModelodeResposta<IQueryable<FuncionarioVM>>>> getFuncionarios()
        {
            var funcionarios = await servicoFuncionario.getFuncionarios();
            return Ok(new ModelodeResposta<IQueryable<FuncionarioVM>> { sucesso = true , info = funcionarios });
        }

        [HttpPost]
        public async Task<ActionResult<FuncionarioIncluirVM>> addFuncionario(FuncionarioIncluirVM funcionario)
        {
            await servicoFuncionario.addFuncionario(funcionario);
            return Ok(new ModelodeResposta<FuncionarioIncluirVM> { sucesso = true});
        }

        [HttpDelete("id")]
        public async Task<IActionResult> deleteFuncionario(int id)
        {
            await servicoFuncionario.deleteFuncionario(id);
            return Ok(new ModelodeResposta<Funcionario> { sucesso = true });
        }

        [HttpGet("id")]
        public async Task<ActionResult<ModelodeResposta<FuncionarioVM>>> getFuncionarioId(int id)
        {
            var funcionario = await servicoFuncionario.getFuncionarioId(id);
            if (funcionario == null)
            {
                return Ok(new ModelodeResposta<FuncionarioVM> { sucesso = false, erro = "um erro aconteceu" });
            }
            return Ok(new ModelodeResposta<FuncionarioVM> { sucesso = true, info = funcionario });
        }

        [HttpPut("id")]
        public async Task<ActionResult<ModelodeResposta<FuncionarioUpdateVM>>> updateFuncionario(int id, FuncionarioUpdateVM funcionario)
        {
            if (id != funcionario.id)
            {
                return Ok(new ModelodeResposta<FuncionarioUpdateVM> { sucesso = false, erro = "um erro aconteceu" });
            }
            await servicoFuncionario.updateFuncionar(funcionario);
            return Ok(new ModelodeResposta<FuncionarioUpdateVM> { sucesso = true });
        }


    }
}
