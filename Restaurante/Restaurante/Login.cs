﻿using System;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                Login_DTO obj = new Login_DTO();
                obj.Usuario = txtUsuario.Text;
                obj.Senha = txtSenha.Text;
                string retorno;
                retorno = Login_BLL.ValidarLogin(obj);
                if (retorno == "sucesso")
                {
                    this.Hide();
                    Principal tela = new Principal();
                    tela.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(retorno, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
