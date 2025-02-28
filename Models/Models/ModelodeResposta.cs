using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class ModelodeResposta<T>
    {
        public bool sucesso { get; set; }
        public string erro { get; set; }
        public T? info { get; set; }
    }

} 
