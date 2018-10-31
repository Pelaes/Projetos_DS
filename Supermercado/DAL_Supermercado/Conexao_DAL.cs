using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace DAL_Supermercado
{
    public class Conexao_DAL
    {
        public static MySqlConnection Conexao()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("server=localhost; user=root; password='';database=DB_Supermercado");
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
