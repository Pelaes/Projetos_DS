using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using DTO_Restaurante;

namespace DAL_Restaurante
{
    public class Conexao
    {
        public static MySqlConnection Conectar()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection
                    ("server=localhost; user=root; password='';database=DB_RESTAURANTE");
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw new Exception("Problemas na conexão!\n" + ex.Message);
            }

        }
    }
}
