using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class EstoqueVM
    {
        public int ID { get; set; }  

        public string Nome { get; set; }  

        public int Quantidade { get; set; }  

        public decimal PrecoUnitario { get; set; }  

        public string Categoria { get; set; }  

    }
}
