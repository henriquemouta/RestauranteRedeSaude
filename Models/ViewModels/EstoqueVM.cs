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

        public string nome { get; set; }  

        public int quantidade { get; set; }  

        public decimal precoUnitario { get; set; }  

        public string categoria { get; set; }  

    }
}
