using Microsoft.AspNetCore.Mvc;
using MoneyWise.Data.Entities;
using MoneyWise.Domain.Services;

namespace MoneyWise.Controllers
{

    //Indicando que é Api controller
    [ApiController]
    //Rota padrão - Pedido
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService usuarioService;

        public UsuarioController(UsuarioService _usuarioService)
        {
            this.usuarioService= _usuarioService;
        }

        [HttpGet]
        public ActionResult<List<UsuarioEntity>> GetAll()
        {
            return usuarioService.Get().ToList();
        }

        [HttpGet("{id:int}")]
        public ActionResult<UsuarioEntity> GetId(int? id)
        {
            if (id is null || id < 0) return BadRequest("Id não retornou");
            
                        var pedido = usuarioService.GetId(p => p.Id == id);

            if (pedido is null) return BadRequest("Categoria não encontrada");

            return Ok(pedido);
        }

    }
}
