using MoneyWise.Data.Context;
using MoneyWise.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWise.Data
{
    public class SeedingServiceData
    {

        private AppDbContext _context;
        public SeedingServiceData(AppDbContext context)
        {
            _context = context;
        }

        public void Seeding()
        {
            if (_context._PedidoEntity.Any() ||
               _context._UsuarioEntity.Any())
            {
                return;
            }

            var usuario1 = new UsuarioEntity( "Artur", "451.963.148-30", "artur@gmail.com", 19); 
            var usuario2 = new UsuarioEntity( "Joao", "493.166.558-63", "joao@gmail.com", 19);
            var usuario3 = new UsuarioEntity( "Otavio", "461.067.708-32", "otavio@gmail.com", 19);

            var pedido1 = new PedidoEntity( usuario1, "Pedido de hamburguer", "Sem cebola");
            var pedido2 = new PedidoEntity( usuario2, "Pedido de coxinha", "Sem detalhes");
            var pedido3 = new PedidoEntity( usuario3, "Pedido de marmita", "Sal a parte");

            usuario1.AdicionarPedidos(pedido1);
            usuario2.AdicionarPedidos(pedido2);
            usuario3.AdicionarPedidos(pedido3);

            _context._UsuarioEntity.AddRange(usuario1, usuario2, usuario3);
            _context._PedidoEntity.AddRange(pedido1, pedido2, pedido3);

            _context.SaveChanges();
        }
    }
}
