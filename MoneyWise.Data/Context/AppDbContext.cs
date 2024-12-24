using Microsoft.EntityFrameworkCore;
using MoneyWise.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWise.Data.Context
{
    public  class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
        base(options)
        {
        }

        // O DbSet indica para o Entity Framework que a classe UsuarioEntity representa uma tabela no banco de dados.
        // Ele permite que você realize operações como consulta, inserção, atualização e exclusão de dados dessa tabela.
        
        public DbSet<UsuarioEntity> _UsuarioEntity { get; set; }
        public DbSet<PedidoEntity> _PedidoEntity   { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Aqui é onde vem as relações 
                modelBuilder.Entity<UsuarioEntity>()  //=> Selecionando a entidade que eu quero fazer a relação
                .HasMany(p => p.pedidoEntities)       //=> HasMany -> Tem muitos (Um usuário tem muitos pedidos)
                .WithOne(u => u.usuarioEntity)        //=> WithOne -> Tem 1 (E um pedido tem 1 usuário)
                .HasForeignKey(u => u.UsuarioId);     //=> HasForeIgnKey -> Selecionando a chave estrangeira

            base.OnModelCreating(modelBuilder);
        }
    }
}
