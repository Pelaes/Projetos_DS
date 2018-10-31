using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Supermercado;
using DAL_Supermercado;

namespace BLL_Supermercado
{
    public class CadUsuario
    {
        public static BuscaEndereco ValidarCep (BuscaEndereco log)
        {
            if (string.IsNullOrWhiteSpace(log.CEP))
            {
                throw new Exception("Digite um CEP para consulta");
            }

            try
            {
                Convert.ToInt32(log.CEP);
            }
            catch
            {
                throw new Exception("O CEP deve ser numérico");
            }

            return CadUsuario_DAL.BuscarEndereco(log);
        }

        public static Cad_Usuario_DTO ValidaUsuario(Cad_Usuario_DTO obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Nome))
            {
                throw new Exception("Campo nome vazio");
            }
            return obj;
        } 
    }
}
