using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Supermercado
{
    public class Cad_Usuario_DTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string CTPS { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Tipo { get; set; }
        public string Tel_Fixo { get; set; }
        public string Tel_Celular { get; set; }

    }
}
