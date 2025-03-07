using System;
using System.Collections.Generic;
using System.Text;

namespace ViewsModels.Prato
{
    public class PratoFiltro
    {
        public string? Nome { get; set; }
        public decimal? PrecoMinimo { get; set; }
        public decimal? PrecoMaximo { get; set; }
        public string? Categoria { get; set; }
    }

}
