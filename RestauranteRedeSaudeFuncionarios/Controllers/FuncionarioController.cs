using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using ViewsModels;
using ViewsModels.Estoques;
using ViewsModels.ViewsModels.Funcionario;

namespace RestauranteRedeSaudeFuncionarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController(IServicoFuncionario servicoFuncionario) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<ModelodeResposta<List<FuncionarioVM>>>> get()
        {
            try
            {
                var estoque = await servicoFuncionario.get();
                return Ok(new ModelodeResposta<List<FuncionarioVM>> { sucesso = true, info = estoque });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<ModelodeResposta<FuncionarioIncluirVM>>> add([FromBody] FuncionarioIncluirVM item)
        {
            try
            {
                if (item == null)
                {
                    return BadRequest(new ModelodeResposta<FuncionarioIncluirVM> { sucesso = false, erro = "Item inválido" });
                }
                await servicoFuncionario.add(item);
                return Ok(new ModelodeResposta<FuncionarioIncluirVM> { sucesso = true, info = item });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ModelodeResposta<FuncionarioUpdateVM>>> update(int id, [FromBody] FuncionarioUpdateVM funcionario)
        {
            try
            {
                if (id > 0 && funcionario != null)
                {
                    await servicoFuncionario.update(id, funcionario);
                }
                return Ok(new ModelodeResposta<FuncionarioUpdateVM> { sucesso = true, info = funcionario });
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
                await servicoFuncionario.delete(id);
                return Ok(new ModelodeResposta<FuncionarioVM> { sucesso = true });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ModelodeResposta<FuncionarioVM>>> getId(int id)
        {
            try
            {
                var estoque = await servicoFuncionario.getId(id);
                return Ok(new ModelodeResposta<FuncionarioVM> { sucesso = true, info = estoque });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



    }
}
