using System;
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
                // Usando String.IsNullOrEmpty para validação mais robusta
                if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtSenha.Text) && !string.IsNullOrEmpty(txtUsuario.Text))
                {
                    usuario novoUsuario = new usuario();
                    novoUsuario.Nome = txtNome.Text;
                    novoUsuario.Usuario = txtUsuario.Text;
                    novoUsuario.Senha = txtSenha.Text; // Senha em texto puro, será criptografada na classe usuario

                    string validacao = novoUsuario.ValidarCadastro();

                    if (validacao != null)
                    {
                        MessageBox.Show(validacao);
                        return;
                    }

                    if (novoUsuario.CadastroUser())
                    {
                        MessageBox.Show("Cadastro realizado com sucesso!");
                        Login telaLogin = new Login();
                        telaLogin.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível cadastrar usuário.");
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
                // Não é necessário 'throw' aqui.
            }
        }
    }
}