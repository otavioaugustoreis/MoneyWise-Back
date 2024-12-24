using MoneyWise.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyWise.Models
{
    public class PedidoModel
    {
        public int Id { get; set; }
        public string DsNome { get; set; }
        public string DsDetalhe { get; set; }
        public UsuarioModel Usuario { get; set; }
    }
}
