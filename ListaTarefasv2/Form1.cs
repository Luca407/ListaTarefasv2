namespace ListaTarefasv2
{
    public partial class Login : Form
    {
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
                if (!txtSenha.Text.Equals("") && !txtUsuario.Text.Equals(""))
                {
                    usuario novoUsuario = new usuario();
                    novoUsuario.Usuario = txtUsuario.Text;
                    novoUsuario.Senha = txtSenha.Text;
                    if (novoUsuario.VerificarLogin())
                    {
                        string nomeLogado = novoUsuario.BuscarNome();
                        Tarefas telaTarefas = new Tarefas();
                        telaTarefas.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Usu�rio ou senha inv�lidos");
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
                MessageBox.Show("N�o foi possivel acessar o sistema! " + ex.Message, "Erro - M�todo btnEntrar_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        
    }
}
