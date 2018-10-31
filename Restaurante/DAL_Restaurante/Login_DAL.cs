using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Restaurante;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DAL_Restaurante
{
    public class Login_DAL
    {
        public static string ValidarLogin (Login_DTO obj)
        {
            try
            {
                string script = "SELECT * FROM tb_login WHERE login = @login AND senha = @senha";
                MySqlCommand cm = new MySqlCommand(script, Conexao.Conectar());
                cm.Parameters.AddWithValue("@login", obj.Usuario);
                cm.Parameters.AddWithValue("@senha", obj.Senha);

                MySqlDataReader dados = cm.ExecuteReader();

                while (dados.Read())
                {
                    if (dados.HasRows)
                    {
                        return "sucesso";
                    }
                }
                return "Usuário ou senha inválidos!";
            }
            catch
            {
                throw new Exception("Problemas na conexão!");
            }
        }
    }
}
