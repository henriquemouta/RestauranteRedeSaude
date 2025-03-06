using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
 
    public class Prato
    {

        public int id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(typeof(decimal), "0.01", "999999.99", ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal preco { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória.")]
        [StringLength(50, ErrorMessage = "A categoria deve ter no máximo 50 caracteres.")]
        public string categoria { get; set; }
        public DateTime? dataCriacao { get; set; }

    }
}
