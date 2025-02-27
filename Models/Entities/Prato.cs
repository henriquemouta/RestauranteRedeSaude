using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
 
    public class Prato
    {

        public int id { get; set; }
        private string _nome = string.Empty;
        public string nome
        {
            get => _nome;
            set => _nome = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Nome é obrigatório.") : value;
        }
        public decimal preco { get; set; }
        public string categoria { get; set; }
        public DateTime? dataCriacao { get; set; }

    }
}
