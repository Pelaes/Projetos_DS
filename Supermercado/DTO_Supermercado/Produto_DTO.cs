using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Supermercado
{
    public class Produto_DTO
    {
        public int ID { get; set; }
        public string Codigo { get; set; }
        public string Imagem { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }
        public string Estoque { get; set; }
        public string Unidade { get; set; }
        public string MyProperty { get; set; }
    }
}
