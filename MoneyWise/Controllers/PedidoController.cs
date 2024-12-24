using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoneyWise.Data.Entities;
using MoneyWise.Domain.Services;
using MoneyWise.Models;
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
        //IMapper é a interface responsável pela instância do AutoMapper
        private readonly IMapper _mapper;

        // Injeção de dependência 
        public PedidoController(IPedidoRepository pedidoRepository, IMapper _mapper)
        {
            this._mapper = _mapper;
            pedidoService = pedidoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidoModel>>> GetAll() {


            /*ModelState é uma propriedade base da classe ControllerBase feita para identificar validações feita pelo sistema
             ou seja, ele identifica a classe validator e usa a função isValid para ver se está tudo certo como feito as validações*/

            if (!ModelState.IsValid) 
            {
                // Retorna  os erros de validação feito pelo validators
                return BadRequest(ModelState);
            }

            var pedidos = await pedidoService.CarregarUsuarios();

            if (pedidos == null || !pedidos.Any())
            {
                return NotFound("Nenhum pedido encontrado.");
            }

            var pedidoDto = _mapper.Map<List<PedidoModel>>(pedidos);

            return Ok(pedidoDto); 
        }

        [HttpGet("{id:int}")]
        public ActionResult<PedidoModel> GetId(int? id)
        {
            if (id is null || id < 0) return BadRequest("Id não retornou");

            var pedido = pedidoService.CarregarUsuarioId(id);

            if (pedido is null) return BadRequest("Pedido não encontrado");

            var pedidoDto = _mapper.Map<PedidoModel>(pedido);

            return Ok(pedidoDto);
        }


        /*Façam o resto das requisições */
    }
}
