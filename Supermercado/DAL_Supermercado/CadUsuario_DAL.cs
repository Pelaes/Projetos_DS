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
    public class CadUsuario_DAL
    {
        public static BuscaEndereco BuscarEndereco (BuscaEndereco obj)
        {
            try
            {
                string script = "SELECT cep, rua, bairro, CID.nome as _CID, EST.sigla as _EST   " + 
                                "FROM Enderecos ED " +
                                "INNER JOIN Cidades CID ON CID.cod = ED.fk_cidade " +
                                "INNER JOIN Estados EST ON EST.cod = ED.fk_estado " +
                                "WHERE cep = @CEP;";

                MySqlCommand cm = new MySqlCommand(script, Conexao_DAL.Conexao());

                cm.Parameters.AddWithValue("@CEP", obj.CEP);
                
                MySqlDataReader dados = cm.ExecuteReader();

                while (dados.Read())
                {
                    if (dados.HasRows)
                    {
                        obj.Rua = dados["rua"].ToString();
                        obj.Bairro = dados["bairro"].ToString();
                        obj.Cidade = dados["_CID"].ToString();
                        obj.UF = dados["_EST"].ToString();
                        return obj;

                    }
                }
                throw new Exception("CEP não encontrado!");
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

        public static string CadFuncionario(Cad_Usuario_DTO obj)
        {
            try
            {
                string script = "INSERT INTO tb_funcionario (nome, rg, cpf, ctps, endereco, tel_fixo, tel_celular, tipo, foto, usuario, senha) " +
                                "VALUES (@nome, @rg, @cpf, @ctps, @end, @fixo, @cel, @tipo, @foto, @user, @ pass)";
                MySqlCommand cm = new MySqlCommand(script, Conexao_DAL.Conexao());

                cm.Parameters.AddWithValue("@nome", obj.Nome);
                cm.Parameters.AddWithValue("@nome", obj.RG);

                cm.ExecuteNonQuery();

                return("Funcionário cadastrado com sucesso!");
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
