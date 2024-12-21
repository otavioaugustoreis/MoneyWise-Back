using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MoneyWise.Data.Entities
{

    [Table("TB_USUARIO")]
    public class UsuarioEntity : EntityBase
    {

        //Usado para avisaqr que o nome da coluna vai ser ds_nome, obs: caso não tenha ele pega o nome do Atributo: DsNome
        [Column("ds_nome")]
        //Usado para avisar que o atributo não pode vir vazio
        [Required]
        public string DsNome { get; set; }

        [Column("ds_cpf")]
        [Required]
        public string DsCPF { get; set; }

        [Column("nr_idade")]
        [Required]
        public int NrIdade { get; set; }


        [Column("ds_email")]
        [Required]
        public string DsEmail { get; set; }

        public UsuarioEntity()
        {
        }
        public UsuarioEntity(int id , string dsNome, string dsCPF, string dsEmail, int nrIdade)
            : base(id)
        {
            DsNome = dsNome;
            DsCPF = dsCPF;
            DsEmail = dsEmail;
            NrIdade = nrIdade;
        }

        private void AdicionarPedidos(PedidoEntity produto)
        {
            this.pedidoEntities.Add(produto);
        }

        [Column("fk_pedido")]
        public int PedidoId { get; set; }

        //Usado para ignorar referência ciclica
        [JsonIgnore]
        public ICollection<PedidoEntity> pedidoEntities { get; set; } = new List<PedidoEntity>();
    }
}
