using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoneyWise.Data.Entities;
using MoneyWise.Domain.Filters;
using MoneyWise.Domain.Services;
using MoneyWise.Models;
using MoneyWise.Repository.Interfaces;
using MoneyWise.Repository.Pagination;
using Newtonsoft.Json;

namespace MoneyWise.Controllers
{

    //Indicando que é Api controller
    [ApiController]
    //Rota padrão - Pedido
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioService;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioRepository _usuarioService, IMapper _mapper)
        {
            this._usuarioService= _usuarioService;
            this._mapper = _mapper;
        }

        [HttpGet]
        public ActionResult<List<UsuarioModel>> GetAll()
        {
            var usuario = _usuarioService.Get().ToList();

            //Convertendo a Entidade para DTO
            var usuarioDto = _mapper.Map<List<UsuarioModel>>(usuario);

            return Ok(usuarioDto);
        }

        [HttpGet("{id:int}")]
        public ActionResult<UsuarioModel> GetId(int? id)
        {
            if (id is null || id < 0) return BadRequest("Id não informado");
            
            var usuario = _usuarioService.GetId(p => p.Id == id);

            if (usuario is null) return BadRequest("Usuario não encontrado não encontrado");

            var usuarioDto = _mapper.Map<UsuarioModel>(usuario);

            return Ok(usuarioDto);
        }

        [HttpGet("filter/preco/pagination")]
        public ActionResult<IEnumerable<UsuarioModel>> GetUsuarioFiltroIdade([FromQuery] UsuarioFilter filter)
        {
            var usuarios = _usuarioService.GetUsuarioFiltro(filter);
            return ObterUsuarios(usuarios);
        }

        private ActionResult<IEnumerable<UsuarioModel>> ObterUsuarios(PagedList<UsuarioEntity> usuarios)
        {
            var metadata = new
            {
                usuarios.TotalCount,
                usuarios.PageSize,
                usuarios.CurrentPage,
                usuarios.TotalPages,
                usuarios.HasNext,
                usuarios.HasPrevius
            };
            //Serializando os objetos do metadata no formato Json, Headers, são as informações do retorno da API

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            var usuarioDto = _mapper.Map<IEnumerable<UsuarioModel>>(usuarios);

            return Ok(usuarioDto);

        }
    }
}

