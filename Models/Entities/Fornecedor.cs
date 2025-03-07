using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Fornecedor
    {
        public int id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$",
            ErrorMessage = "CNPJ inválido. Formato esperado: 00.000.000/0000-00.")]
        public string cnpj { get; set; }

        [RegularExpression(@"^\d{10,11}$",
            ErrorMessage = "Telefone inválido. Deve conter 10 ou 11 dígitos numéricos.")]
        public string? telefone { get; set; }
        public DateTime? dataCriacao { get; set; }
    }
}
