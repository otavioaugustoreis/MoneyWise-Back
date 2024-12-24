using MoneyWise.Data.Context;
using MoneyWise.Data.Entities;
using MoneyWise.Domain.Filters;
using MoneyWise.Repository.Interfaces;
using MoneyWise.Repository.Patterns;
using MoneyWise.Repository.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWise.Domain.Services
{
    public class UsuarioService : Repository<UsuarioEntity>, IUsuarioRepository
    {
        public UsuarioService(AppDbContext context) : base(context)
        {
        }

        public PagedList<UsuarioEntity> GetUsuarioFiltro(UsuarioFilter usuarioFilterParams)
        {
            //IQueryble tem um desempenho melhor para as consultas no banco de dados
            var usuarios = Get().AsQueryable();

            var NrIdadeFiltro = usuarioFilterParams.NrIdade;
            var NrIdadeCriterio = usuarioFilterParams.NrIdadeCriterio;

            if (NrIdadeFiltro.HasValue && !string.IsNullOrEmpty(NrIdadeCriterio))
            {
                if (NrIdadeCriterio.Equals("maior", StringComparison.OrdinalIgnoreCase))
                {
                    usuarios = usuarios.Where(p => p.NrIdade > NrIdadeFiltro.Value).OrderBy(p => p.NrIdade);
                }
                else if (NrIdadeCriterio.Equals("menor", StringComparison.OrdinalIgnoreCase))
                {
                    usuarios = usuarios.Where(p => p.NrIdade < NrIdadeFiltro.Value).OrderBy(p => p.NrIdade);
                }
                else if (NrIdadeCriterio.Equals("igual", StringComparison.OrdinalIgnoreCase))
                {
                    usuarios = usuarios.Where(p => p.NrIdade == NrIdadeFiltro.Value).OrderBy(p => p.NrIdade);
                }
            }
            var usuariosFiltrados = PagedList<UsuarioEntity>.ToPagedList(usuarios, usuarioFilterParams.PageNumber, usuarioFilterParams.PageSize);

            return usuariosFiltrados;
        }
        public bool HasPedidos(int usuarioId)
        {
               return _context._PedidoEntity.Any(p => p.usuarioEntity.Id == usuarioId);
        }
    }
}

