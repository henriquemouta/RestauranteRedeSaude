using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class Fornecedor
    {
        public int id { get; set; }  

        private string _nome = string.Empty;   
        public string nome 
        { 
            get => _nome; 
            set => _nome = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Nome é obrigatório.") : value; 
        }
        private string _cnpj = string.Empty;
        public string cnpj
        {
            get => _cnpj;
            set => _cnpj = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("CNPJ é obrigatório.") : value;
        }
 
        public string? telefone { get; set; }
        public DateTime? dataCriacao { get; set; }
    }
}
