using Microsoft.AspNetCore.Mvc;
using MoneyWise.Data.Entities;
using MoneyWise.Domain.Services;




namespace MoneyWise.Controllers
{
    //Indicando que é Api controller
    [ApiController]
    //Rota padrão - Pedido
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService pedidoService;

        [HttpGet]
        public ActionResult<List<PedidoEntity>> GetAll() {
            return pedidoService.Get().ToList();
        }

        [HttpGet("{id:int}")]
        public ActionResult<PedidoEntity> GetId(int? id)
        {
            if (id is null || id < 0) return BadRequest("Id não retornou");

            var pedido = pedidoService.GetId(p => p.Id == id);

            if (pedido is null) return BadRequest("Categoria não encontrada");

            return Ok(pedido);
        }

    }
}
