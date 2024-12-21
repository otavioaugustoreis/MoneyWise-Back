using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWise.Data.Entities
{
    public abstract class EntityBase
    {
        [Key]
        [Column("pk_id")]
        public int? Id { get; set; }

        [Required]
        [Column("dh_inclusao")]
        public DateTime DateOfInclusion { get; set; } = DateTime.Now;

        public EntityBase()
        {

        }
    }
}
