using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Supermercado
{
    public class Login_DTO
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string ConfSenha { get; set; }
        public string Foto { get; set; }
    }
}
