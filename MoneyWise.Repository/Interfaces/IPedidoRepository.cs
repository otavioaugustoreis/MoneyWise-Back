using MoneyWise.Data.Entities;
using MoneyWise.Repository.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWise.Repository.Interfaces
{
    public interface IPedidoRepository : IRepository<PedidoEntity>
    {
        //Aqui adicionamos funções que iriam aparecer no nosso projeto
        Task<IEnumerable<PedidoEntity>> CarregarUsuarios();
         PedidoEntity CarregarUsuarioId(int? id);
    }
}
