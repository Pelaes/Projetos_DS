using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_Restaurante;
using BLL_Restaurante;

namespace UI_Restaurante
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            button8.Enabled = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string retorno;
            Cadastro_DTO obj = new Cadastro_DTO();
            obj.Nome = textBox1.Text;
            obj.RG = textBox2.Text;
            obj.CPF = maskedTextBox1.Text;
            obj.Endereco = textBox4.Text;
            obj.Numero = textBox6.Text;
            obj.Bairro = textBox5.Text;
            obj.Cidade = textBox7.Text;
            obj.Banco = textBox10.Text;
            obj.Agencia = textBox9.Text;
            obj.Conta = textBox8.Text;
            obj.Telefone = maskedTextBox2.Text;
            retorno = Cadastro_BLL.ValidarCadastro(obj);
            MessageBox.Show(retorno, "Mensagem", MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try // botão
            {
                string cpf;
                cpf = maskedTextBox1.Text;
                Cadastro_BLL bll = new Cadastro_BLL();
                Cadastro_DTO obj = new Cadastro_DTO();
                obj = bll.ValidarBusca(cpf);
                textBox1.Text = obj.Nome;
                button10.Enabled = false;
                button8.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}
