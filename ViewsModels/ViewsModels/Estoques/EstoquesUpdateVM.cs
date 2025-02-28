using System;
using System.Collections.Generic;
using System.Text;

namespace ViewsModels.Estoques
{
    public class EstoquesUpdateVM
    {
        public string nome { get; set; }

        public int quantidade { get; set; }

        public decimal precoUnitario { get; set; }

        public string categoria { get; set; }

    }
}
