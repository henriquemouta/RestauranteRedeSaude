using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Funcionario
    {
        public int id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O cargo é obrigatório.")]
        [StringLength(50, ErrorMessage = "O cargo deve ter no máximo 50 caracteres.")]
        public string cargo { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Telefone inválido. Use 10 ou 11 dígitos numéricos.")]
        public string telefone { get; set; }
        public DateTime? dataCriacao { get; set; }
    }
}
