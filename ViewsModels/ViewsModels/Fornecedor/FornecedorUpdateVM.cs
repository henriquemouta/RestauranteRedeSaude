﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ViewsModels.ViewsModels.Fornecedor
{
    public class FornecedorUpdateVM
    {
        public int id { get; set; }

        public string nome { get; set; }

        public string cnpj { get; set; }

        public string telefone { get; set; }
        public FornecedorUpdateVM() { }
    }
}
