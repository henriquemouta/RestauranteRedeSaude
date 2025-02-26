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

     
        public string nome { get; set; }


        public decimal preco { get; set; }

 
        public string categoria { get; set; }

        public DateTime dataCriacao { get; set; }

    }
}
