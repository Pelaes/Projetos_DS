using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Supermercado;
using DAL_Supermercado;

namespace BLL_Supermercado
{
    public class Login_BLL
    {
        public static Login_DTO ValidarLogin(Login_DTO obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Login) || obj.Login == "Digite seu usuário")
            {
                throw new Exception("Campo Usuário é obrigatório!");
            }
            if (string.IsNullOrWhiteSpace(obj.Senha) || obj.Senha == "Digite sua senha")
            {
                throw new Exception("Campo Senha é obrigatório!");
            }
            if (string.IsNullOrWhiteSpace(obj.ConfSenha) || obj.ConfSenha == "Confirme sua senha")
            {
                throw new Exception("Campo Confirmar Senha é obrigatório!");
            }

            if(obj.Senha == obj.ConfSenha)
            {
                return Login_DAL.Login(obj); 
            }
            else
            {
                throw new Exception("As senhas não conferem!");
            }

        }
    }
}
