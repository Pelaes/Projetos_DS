using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_Supermercado;
using BLL_Supermercado;

namespace Supermercado
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Digite seu usuário")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Digite seu usuário";
                txtUsuario.ForeColor = Color.Silver;
            }
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            if(txtSenha.Text == "Digite sua senha")
            {
                txtSenha.Text = "";
                txtSenha.PasswordChar = '*';
                txtSenha.ForeColor = Color.Black;
            }
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            if (txtSenha.Text == "")
            {
                txtSenha.PasswordChar = char.Parse("\0");
                txtSenha.Text = "Digite sua senha";
                txtSenha.ForeColor = Color.Silver;
            }
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            
            try
            {
                Login_DTO login = new Login_DTO();
                login.Login = txtUsuario.Text;
                login.Senha = txtSenha.Text;
                login.ConfSenha = txtConSenha.Text;
                login = Login_BLL.ValidarLogin(login);
                if (!(login.ID.Equals(""))){
                    this.Hide();
                    Home tela = new Home(login);
                    tela.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuário e/ou senha inválidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtConSenha_Enter(object sender, EventArgs e)
        {
            if (txtConSenha.Text == "Confirme sua senha")
            {
                txtConSenha.Text = "";
                txtConSenha.PasswordChar = '*';
                txtConSenha.ForeColor = Color.Black;
            }
        }
        private void txtConSenha_Leave(object sender, EventArgs e)
        {
            if (txtConSenha.Text == "")
            {
                txtConSenha.PasswordChar = char.Parse("\0");
                txtConSenha.Text = "Confirme sua senha";
                txtConSenha.ForeColor = Color.Silver;
            }
        }
    }
}
