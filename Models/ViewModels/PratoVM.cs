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

         public int id { get; init; }

     
        public string nome { get; init; }


        public decimal preco { get; init; }

 
        public string categoria { get; init; }

    }
}
