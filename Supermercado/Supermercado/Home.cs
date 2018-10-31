using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using DTO_Supermercado;
using BLL_Supermercado;

namespace Supermercado
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        public Home(Login_DTO obj)
        {
            InitializeComponent();
            label26.Text = obj.Nome;
            var hora = DateTime.Now;
            obj.Foto = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + obj.Foto;
            label11.Text = hora.ToString();
            label12.Text = hora.Add(new TimeSpan(9, 0, 0)).ToString();
            pictureBox2.Image = Image.FromFile(obj.Foto);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            TimeSpan tarde = new TimeSpan(12, 0, 0);
            TimeSpan noite = new TimeSpan(18, 0, 0);
            TimeSpan HoraAtual = DateTime.Now.TimeOfDay;
            if(HoraAtual < tarde)
            {
                label25.Text = "Bom Dia";
            }
            else if (HoraAtual < noite)
            {
                label25.Text = "Boa Tarde";
            }
            else
            {
                label25.Text = "Boa noite";
            }
            if(obj.Tipo != "administrador")
            {
                //TabPage tab, tab2, tab3;
                this.tabControl1.TabPages.Remove(tabPage2);
                this.tabControl1.TabPages.Remove(tabPage3);
                this.tabControl1.TabPages.Remove(tabPage4);
                button6.Visible = false;
                button7.Enabled = false;
            }

        }
        string ImgOrigem;
        string ImgDestino = @"C:\Users\Marcelo\Source\repos\Supermercado\Supermercado\Resources";
        string ImgNovoNome;
        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            Produto_DTO obj = new Produto_DTO();
            obj.Codigo = textBox9.Text;
            obj.Nome = textBox10.Text;
            obj.Preco = textBox11.Text;
            obj.Unidade = textBox13.Text + " " + comboBox1.Text;
            MessageBox.Show(obj.Unidade);
            File.Copy(ImgOrigem, ImgDestino);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            string pasta = @"c:\teste12345\teste123456\teste1234567";
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            OpenFileDialog produto = new OpenFileDialog();
            //produto.Multiselect = true;
            if(produto.ShowDialog() == DialogResult.OK)
            {
                pictureBox6.ImageLocation = produto.FileName;
                pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                ImgOrigem = produto.FileName;
                MessageBox.Show(ImgOrigem);
                ImgNovoNome = textBox9.Text + Path.GetExtension(produto.FileName);
                MessageBox.Show(ImgNovoNome);
                ImgDestino = Path.Combine(ImgDestino, ImgNovoNome);
                MessageBox.Show(ImgDestino);
                MessageBox.Show(ImgOrigem + "\n" + ImgDestino);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Cad_Usuario_DTO obj = new Cad_Usuario_DTO();
            obj.Nome = textBox30.Text;
            obj.RG = textBox28.Text;
            obj.CPF = textBox27.Text;
            obj.CTPS = textBox26.Text;
            obj.CEP = maskedTextBox1.Text;
            obj.Endereco = textBox29.Text;
            obj.Numero = textBox22.Text;
            obj.Bairro = textBox21.Text;
            obj.Cidade = textBox23.Text;
            obj.UF = textBox24.Text;
            obj.Tipo = comboBox2.Text;
            obj.Tel_Fixo = textBox25.Text;
            obj.Tel_Celular = textBox31.Text;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            BuscaEndereco obj = new BuscaEndereco();
            
            try
            {
                obj.CEP = maskedTextBox1.Text;
                obj = CadUsuario.ValidarCep(obj);
                textBox29.Text = obj.Rua;
                textBox21.Text = obj.Bairro;
                textBox23.Text = obj.Cidade;
                textBox24.Text = obj.UF;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
