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
    }
}
