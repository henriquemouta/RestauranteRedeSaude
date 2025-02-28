using System;
using System.Collections.Generic;
using System.Text;

namespace ViewsModels.ViewsModels.Funcionario
{
    public class FuncionarioUpdateVM
    {
        public int id { get; set; }

        public string nome { get; set; }

        public string cargo { get; set; }

        public string telefone { get; set; }
        public FuncionarioUpdateVM() { }
    }
}
