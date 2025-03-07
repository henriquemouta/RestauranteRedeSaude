using System;
using System.Collections.Generic;
using System.Text;

namespace ViewsModels.Estoques
{
    public class EstoquesFiltro
    {
        public string? Nome { get; set; }
        public decimal? PrecoMinimo { get; set; }
        public decimal? PrecoMaximo { get; set; }
        public int? QuantidadeMinima { get; set; }
        public string? Categoria { get; set; }

    }
}
