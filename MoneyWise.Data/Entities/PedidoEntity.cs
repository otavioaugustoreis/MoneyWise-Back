using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace MoneyWise.Data.Entities
{
    [Table("TB_PEDIDO")]
    public class PedidoEntity : EntityBase


    {
        //Temos que informar a chave estrangeira e especificar na classe AppDbContext
        [Column("fk_usuario")]
        [Required]

        //Definindo chave estrangeira, obs: não precisamos definir a chave estrangeira por que a configuração do método OnModelCreating na classe AppDbContext, o EF já faz isso automaticamente
        public int UsuarioId { get; set; }


        [JsonIgnore]
        public UsuarioEntity usuarioEntity { get; set; }

        public PedidoEntity()
        {

        }

        [Column("ds_nome")]
        public  string DsNome { get; set; }

        [Column("ds_detalhe")]
        public string DsDetalhe { get; set; }

        public PedidoEntity(UsuarioEntity usuarioEntity, string dsNome, string dsDetalhes)
            : base()
        {
            this.usuarioEntity = usuarioEntity;
            this.DsNome = dsNome;
            this.DsDetalhe = dsDetalhes;
        }
    }
}
