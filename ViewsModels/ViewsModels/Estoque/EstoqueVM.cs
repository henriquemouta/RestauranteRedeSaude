using System;
using System.Collections.Generic;
using System.Text;

namespace ViewsModels.ViewsModels.Estoque
{
    public class EstoqueVM
    {
        public int id { get; set; }

        public string nome { get; set; }

        public int quantidade { get; set; }

        public decimal precoUnitario { get; set; }

        public string categoria { get; set; }

        public EstoqueVM() { }  
    }
}
