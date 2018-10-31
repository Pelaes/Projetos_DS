using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Restaurante;
using DAL_Restaurante;

namespace BLL_Restaurante
{
    public class Cadastro_BLL
    {
        public static string ValidarCadastro(Cadastro_DTO obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Nome))
            {
                return "Campo nome vazio!";
            }

            bool teste_cpf = Cadastro_DAL.TestarCPF(obj.CPF);
            if(teste_cpf == true)
            {
                return "CPF já existe na base de dados!";
            }
            try
            {
                int.Parse(obj.Numero);
            }
            catch
            {
                return "Campo numero deve ser um numero inteiro!";
            }
            return Cadastro_DAL.Cadastrar(obj);
        }

        public Cadastro_DTO ValidarBusca(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
            {
                throw new Exception("Campo CPF vazio!");
            }
            return Cadastro_DAL.Buscar(cpf);
        }
    }
}
