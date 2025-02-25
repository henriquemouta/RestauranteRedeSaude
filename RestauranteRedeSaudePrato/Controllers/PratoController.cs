using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace RestauranteRedeSaudePrato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PratoController(IServicoPrato servicoPrato) : ControllerBase
    {
            [HttpGet]
            public async Task<ActionResult<ModelodeResposta>> GetPratos()
            {
                var pratos = await servicoPrato.GetPratos();
                return Ok(new ModelodeResposta { sucesso = true, info = pratos });
            }


        
    }
}
