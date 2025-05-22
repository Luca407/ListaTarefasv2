using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaTarefasv2
{
    public partial class TelaCadastro : Form
    {
        public TelaCadastro()
        {
            InitializeComponent();
        }

        private void llblTelaCadastro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login telaLogin = new Login();
            telaLogin.Show();
            this.Hide();
        }

        private void TelaCadastro_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtNome.Text.Equals("") && !txtSenha.Text.Equals("") && !txtUsuario.Text.Equals(""))
                {
                    usuario novoUsuario = new usuario();
                    novoUsuario.Nome = txtNome.Text;
                    novoUsuario.Usuario = txtUsuario.Text;
                    novoUsuario.Senha = txtSenha.Text;

                    string validacao = novoUsuario.ValidarCadastro();

                    if (validacao != null)
                    {
                        MessageBox.Show(validacao);
                        return;
                    }

                    if (novoUsuario.CadastroUser())
                    {
                        MessageBox.Show("Cadastro realizado com sucesso");
                        Login telaLogin = new Login();
                        telaLogin.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível cadastrar usuário");
                    }
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar o usuário: " + ex.Message);
                throw;
            }
        }
    }
}
