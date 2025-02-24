using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
 
    public class PratoVM
    {

         public int ID { get; init; }

     
        public string Nome { get; init; }


        public decimal Preco { get; init; }

 
        public string Categoria { get; init; }

    }
}
