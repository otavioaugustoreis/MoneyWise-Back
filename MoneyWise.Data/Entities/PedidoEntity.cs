using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWise.Data.Entities
{
    [Table("TB_PEDIDO")]
    public class PedidoEntity : EntityBase
    {


        //Temos que informar a chave estrangeira e especificar na classe AppDbContext
        [Column("fk_usuario")]
        [Required]
        public int UsuarioId { get; set; }
        public UsuarioEntity usuarioEntity { get; set; }

        public PedidoEntity()
        {

        }

        public PedidoEntity(int id, int idUsuario, UsuarioEntity usuarioEntity)
            : base(id)
        {
            UsuarioId = idUsuario;
            this.usuarioEntity = usuarioEntity;
        }
    }
}
