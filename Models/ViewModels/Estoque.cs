using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class Estoque
    {
        public int id { get; set; }

        private string _nome = string.Empty;
        public string nome
        {
            get => _nome;
            set => _nome = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Nome é obrigatório.") : value;
        }

        public int quantidade { get; set; }  

        public decimal precoUnitario { get; set; }  

        public string categoria { get; set; }
        public DateTime dataCriacao { get; set; }
    }
}
