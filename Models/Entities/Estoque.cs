using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class Estoque
    {
        public int id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres.")]
        public string nome { get; set; } = string.Empty;

        public int quantidade { get; set; }  

        public decimal precoUnitario { get; set; }  

        public string categoria { get; set; }
        public DateTime? dataCriacao { get; set; }
    

        public Estoque() { }
    }
}
