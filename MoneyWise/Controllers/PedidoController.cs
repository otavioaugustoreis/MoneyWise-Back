using Microsoft.AspNetCore.Mvc;
using MoneyWise.Data.Entities;
using MoneyWise.Domain.Services;
using MoneyWise.Repository.Interfaces;




namespace MoneyWise.Controllers
{
    //Indicando que é Api controller
    [ApiController]
    //Rota padrão - Pedido
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository pedidoService;

        // Injeção da interface
        public PedidoController(IPedidoRepository pedidoRepository)
        {
            pedidoService = pedidoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidoEntity>>> GetAll() {

            var pedidos = await pedidoService.CarregarUsuarios();

            return Ok(pedidos); 
        }

        [HttpGet("{id:int}")]
        public ActionResult<PedidoEntity> GetId(int? id)
        {
            if (id is null || id < 0) return BadRequest("Id não retornou");

            var pedido = pedidoService.CarregarUsuarioId(id);

            if (pedido is null) return BadRequest("Categoria não encontrada");

            return Ok(pedido);
        }

    }
}
