using System;
using System.Collections.Generic;
using System.Text;

namespace ViewsModels.ViewsModels.Prato
{
    public class PratoUpdateVM
    {
        public int id { get; set; }


        public string nome { get; set; }


        public decimal preco { get; set; }


        public string categoria { get; set; }
        public PratoUpdateVM() { }
    }
}
