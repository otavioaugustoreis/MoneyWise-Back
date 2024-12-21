using MoneyWise.Data.Entities;
using MoneyWise.Repository.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyWise.Repository.Interfaces;
using MoneyWise.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MoneyWise.Domain.Services
{
    public class PedidoService : Repository<PedidoEntity>, IPedidoRepository
    {
        public PedidoService(AppDbContext context) : base(context)
        {
        }
        
        //Função assíncrona 
        public async Task<IEnumerable<PedidoEntity>> CarregarUsuarios()
        {
            return await _context._PedidoEntity.Include(u => u.usuarioEntity)
                                                 .ToListAsync();
        }


        public  PedidoEntity CarregarUsuarioId(int? id)
        {
            return  _context._PedidoEntity.Include(u => u.usuarioEntity)
                                                .FirstOrDefault(i => i.Id.Value == id);
        }
    }
}
