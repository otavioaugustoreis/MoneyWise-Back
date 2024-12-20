using MoneyWise.Data.Entities;
using MoneyWise.Repository.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyWise.Repository.Interfaces;
using MoneyWise.Data.Context;

namespace MoneyWise.Domain.Services
{
    public class PedidoService : Repository<PedidoEntity>, IPedidoRepository
    {
        public PedidoService(AppDbContext context) : base(context)
        {
        }
    }
}
