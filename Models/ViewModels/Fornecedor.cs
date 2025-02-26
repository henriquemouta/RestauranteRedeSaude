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

        public string nome { get; set; }  

        public string cnpj { get; set; }  

        public string telefone { get; set; }
        public DateTime dataCriacao { get; set; }
    }
}
