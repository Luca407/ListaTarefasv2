using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace ListaTarefasv2
{
    public partial class Login : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static int UsuarioLogadoId { get; private set; } 

        public Login()
        {
            InitializeComponent();
        }

        private void llblTelaCadastro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TelaCadastro telaCadastro = new TelaCadastro();
            telaCadastro.Show();
            this.Hide();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Usando String.IsNullOrEmpty para valida��o mais robusta
                if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtSenha.Text))
                {
                    usuario novoUsuario = new usuario();
                    novoUsuario.Usuario = txtUsuario.Text;
                    novoUsuario.Senha = txtSenha.Text; // Senha em texto puro, ser� criptografada na classe usuario

                    if (novoUsuario.VerificarLogin())
                    {
                        // Se o login for bem-sucedido, busca e armazena o ID do usu�rio
                        UsuarioLogadoId = novoUsuario.BuscarIdUsuarioPorUsuario(txtUsuario.Text);

                        // Agora que temos o ID, podemos abrir a tela de tarefas
                        Tarefas telaTarefas = new Tarefas();
                        telaTarefas.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usu�rio ou senha inv�lidos.");
                        txtSenha.Clear();
                        txtUsuario.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("N�o foi poss�vel acessar o sistema! Erro: " + ex.Message, "Erro - Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // N�o � necess�rio 'throw' aqui, o MessageBox j� informa o usu�rio.
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}