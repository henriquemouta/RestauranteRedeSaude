using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    [Table("Prato")]
    public record PratoVM
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int ID { get; init; }

        [Column("Nome")]
        public string Nome { get; init; }

        [Column("Preco")]
        public decimal Preco { get; init; }

        [Column("Categoria")]
        public string Categoria { get; init; }

    }
}
