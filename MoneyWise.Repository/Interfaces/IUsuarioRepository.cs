using MoneyWise.Data.Entities;
using MoneyWise.Domain.Filters;
using MoneyWise.Repository.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWise.Repository.Interfaces
{
    public interface IUsuarioRepository : IRepository<UsuarioEntity>
    {
        PagedList<UsuarioEntity> GetUsuarioFiltro(UsuarioFilter usuarioFilterParams);

        //Método para verificar se há pedidos
        bool HasPedidos(int usuarioId);
    }
}
