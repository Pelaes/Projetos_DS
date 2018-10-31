using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using DTO_Restaurante;

namespace DAL_Restaurante
{
    public class Cadastro_DAL
    {
        public static string Cadastrar (Cadastro_DTO obj)
        {
            try
            {
                string sql = "INSERT INTO Funcionario (nome, rg, cpf, endereco, numero," +
                "bairro, cidade, banco, agencia, conta, telefone) VALUES " +
                "(@Nome, @RG, @CPF, @Endereco, @Num, @Bairro, @Cidade," +
                "@Banco, @Agencia, @Conta, @Tel)";
                MySqlCommand cm = new MySqlCommand(sql, Conexao.Conectar());

                cm.Parameters.AddWithValue("@Nome", obj.Nome);
                cm.Parameters.AddWithValue("@RG", obj.RG);
                cm.Parameters.AddWithValue("@CPF", obj.CPF);
                cm.Parameters.AddWithValue("@Endereco", obj.Endereco);
                cm.Parameters.AddWithValue("@Num", obj.Numero);
                cm.Parameters.AddWithValue("@Bairro", obj.Bairro);
                cm.Parameters.AddWithValue("@Cidade", obj.Cidade);
                cm.Parameters.AddWithValue("@Banco", obj.Banco);
                cm.Parameters.AddWithValue("@Agencia", obj.Agencia);
                cm.Parameters.AddWithValue("@Conta", obj.Conta);
                cm.Parameters.AddWithValue("@Tel", obj.Telefone);

                cm.ExecuteNonQuery();

                return "cadastro com sucesso";
            }
            catch (Exception abacate)
            {
                throw new Exception("Problemas na conexão!" + abacate.Message);
            }
            finally
            {
                if (Conexao.Conectar().State != ConnectionState.Closed)
                {
                    Conexao.Conectar().Close();
                }
            }
        }

        public static Cadastro_DTO Buscar(string cpf)
        {
            try
            {
                Cadastro_DTO obj = new Cadastro_DTO();
                string script = "SELECT * FROM Funcionario WHERE cpf = @cpf";
                MySqlCommand cm = new MySqlCommand(script, Conexao.Conectar());
                cm.Parameters.AddWithValue("@cpf", cpf);

                MySqlDataReader dados = cm.ExecuteReader();

                while (dados.Read())
                {
                    if (dados.HasRows)
                    {
                        obj.ID = int.Parse(dados["id"].ToString());
                        obj.Nome = dados["nome"].ToString();
                        return obj;
                    }
                }
                throw new Exception ("CPF não encontrado!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Problemas na conexão!");
            }
            finally
            {
                if (Conexao.Conectar().State != ConnectionState.Closed)
                {
                    Conexao.Conectar().Close();
                }
            }
        }

        public static bool TestarCPF(string cpf)
        {
            try
            {
                string script = "SELECT * FROM Funcionario WHERE cpf = @cpf";
                MySqlCommand cm = new MySqlCommand(script, Conexao.Conectar());
                cm.Parameters.AddWithValue("@cpf", cpf);

                MySqlDataReader dados = cm.ExecuteReader();

                while (dados.Read())
                {
                    if (dados.HasRows)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                throw new Exception("Problemas na conexão!");
            }
            finally
            {
                if (Conexao.Conectar().State != ConnectionState.Closed)
                {
                    Conexao.Conectar().Close();
                }
            }
        }

    }
}
