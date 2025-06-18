using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms; // Adicionado para MessageBox

namespace ListaTarefasv2
{
    internal class usuario
    {
        public int Id_usuario { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; } // Esta propriedade conterá a senha em texto puro ANTES de ser criptografada.

        public string ValidarCadastro()
        {
            try
            {
                using (MySqlConnection conexaoBanco = new ConexaoBD().Conectar())
                {
                    string consulta = "SELECT COUNT(*) FROM Usuario WHERE Usuario = @Usuario";
                    MySqlCommand comando = new MySqlCommand(consulta, conexaoBanco);
                    comando.Parameters.AddWithValue("@Usuario", Usuario);

                    int count = Convert.ToInt32(comando.ExecuteScalar()); // Usa ExecuteScalar para COUNT(*)

                    if (count > 0)
                    {
                        return "Usuário já está cadastrado.";
                    }
                }
                return null; // Retorna null se não houver duplicidade
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível validar cadastro: " + ex.Message, "Erro - Validar Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public bool CadastroUser()
        {
            try
            {
                using (MySqlConnection conexaoBanco = new ConexaoBD().Conectar())
                {
                    // Criptografa a senha em texto puro antes de armazená-la no banco de dados
                    string senhaCriptografada = Criptografia.GerarHashSha256(this.Senha);

                    // ATENÇÃO: Nome do parâmetro alterado para @CriptoSenha para evitar confusão com a propriedade Senha
                    string inserir = "INSERT INTO Usuario (Nome, Usuario, Senha) VALUES (@Nome, @Usuario, @CriptoSenha)";

                    MySqlCommand comando = new MySqlCommand(inserir, conexaoBanco);

                    comando.Parameters.AddWithValue("@Nome", Nome);
                    comando.Parameters.AddWithValue("@Usuario", Usuario);
                    comando.Parameters.AddWithValue("@CriptoSenha", senhaCriptografada); // Usa a senha criptografada

                    int resultado = comando.ExecuteNonQuery();
                    return resultado > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível cadastrar usuário: " + ex.Message, "Erro - Cadastro de Usuário", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool VerificarLogin()
        {
            try
            {
                using (MySqlConnection conexaoBanco = new ConexaoBD().Conectar())
                {
                    // Criptografa a senha digitada pelo usuário para comparar com a que já está criptografada no banco
                    string senhaCriptografada = Criptografia.GerarHashSha256(this.Senha);

                    // ATENÇÃO: Nome do parâmetro alterado para @CriptoSenha
                    string consultaUsuarios = "SELECT COUNT(*) FROM Usuario WHERE Usuario = @Usuario AND Senha = @CriptoSenha";
                    MySqlCommand comando = new MySqlCommand(consultaUsuarios, conexaoBanco);

                    // Não precisamos do @Nome para verificar login
                    comando.Parameters.AddWithValue("@Usuario", Usuario);
                    comando.Parameters.AddWithValue("@CriptoSenha", senhaCriptografada); // Compara com a senha criptografada

                    int resultado = Convert.ToInt32(comando.ExecuteScalar());

                    return resultado > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível verificar login: " + ex.Message, "Erro - Verificar Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public int BuscarIdUsuarioPorUsuario(string nomeUsuario)
        {
            try
            {
                using (MySqlConnection conexaoBanco = new ConexaoBD().Conectar())
                {
                    string consultaId = "SELECT Id_usuario FROM Usuario WHERE Usuario = @Usuario";
                    MySqlCommand comando = new MySqlCommand(consultaId, conexaoBanco);
                    comando.Parameters.AddWithValue("@Usuario", nomeUsuario);

                    object resultado = comando.ExecuteScalar();

                    if (resultado != null && resultado != DBNull.Value)
                    {
                        return Convert.ToInt32(resultado);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar ID do usuário: " + ex.Message, "Erro - Buscar ID Usuário", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public string BuscarNome() // Este método agora busca o 'Nome' de exibição do usuário
        {
            try
            {
                using (MySqlConnection conexaoBanco = new ConexaoBD().Conectar())
                {
                    string buscarNomeUsuario = "SELECT Nome FROM Usuario WHERE Usuario = @Usuario";
                    MySqlCommand comando = new MySqlCommand(buscarNomeUsuario, conexaoBanco);
                    comando.Parameters.AddWithValue("@Usuario", Usuario);

                    object resultado = comando.ExecuteScalar();

                    if (resultado != null && resultado != DBNull.Value)
                    {
                        return resultado.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível buscar nome: " + ex.Message, "Erro - Buscar Nome", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}