using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using DTO_Supermercado;


namespace DAL_Supermercado
{
    public class Login_DAL
    {
        public static Login_DTO Login(Login_DTO obj)
        {
            try
            {
                string script = "select cod, usuario, senha, nome, tipo, foto FROM TB_Funcionario WHERE usuario = @usuario and senha = @senha";
                MySqlCommand cm = new MySqlCommand(script, Conexao_DAL.Conexao());
                cm.Parameters.AddWithValue("@usuario", obj.Login);
                cm.Parameters.AddWithValue("@senha", obj.Senha);

                MySqlDataReader dados = cm.ExecuteReader();

                while (dados.Read())
                {
                    if (dados.HasRows)
                    {
                        obj.ID = int.Parse(dados["cod"].ToString());
                        obj.Nome = dados["nome"].ToString();
                        obj.Tipo = dados["tipo"].ToString();
                        obj.Foto = dados["foto"].ToString();
                        return obj;
                        
                    }
                }
                throw new Exception("Usuário ou senha inválidos");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (Conexao_DAL.Conexao().State != ConnectionState.Closed)
                {
                    Conexao_DAL.Conexao().Close();
                }
            }
        }
        
    }
}
