using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTarefasv2
{
    internal class usuario
    {
        public int Id_usuario { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        


        private bool ExisteCampoDuplicado(string campo, string valor, MySqlConnection conexao)
        {
            string query = $"SELECT COUNT(*) FROM Usuario WHERE {campo} = @valor";
            using (MySqlCommand cmd = new MySqlCommand(query, conexao))
            {
                cmd.Parameters.AddWithValue("@valor", valor);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public bool CadastroUser()
        {
            try
            {
                using (MySqlConnection conexaoBanco = new ConexaoBD().Conectar())
                {
                    string inserir = "insert into Usuario (Nome, Usuario, Senha) values (@Nome, @Usuario, @Senha)";

                    MySqlCommand comando = new MySqlCommand(inserir, conexaoBanco);

                    comando.Parameters.AddWithValue("@Nome", Nome);
                    comando.Parameters.AddWithValue("@Usuario", Usuario);
                    comando.Parameters.AddWithValue("@Senha", Senha);

                    int resultado = comando.ExecuteNonQuery();
                    if (resultado > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível cadastrar usuário -> " + ex.Message, "Erro - Verificar Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        public bool VerificarLogin()
        {
            try
            {
                using (MySqlConnection conexaoBanco = new ConexaoBD().Conectar())
                {

                    //Consultando se o usuário e senha informados existem no banco de dados
                    string consultaUsuarios = "SELECT COUNT(*) FROM Usuario WHERE Usuario = @Usuario AND Senha = @Senha";
                    MySqlCommand comando = new MySqlCommand(consultaUsuarios, conexaoBanco);

                    comando.Parameters.AddWithValue("@Nome", Nome);
                    comando.Parameters.AddWithValue("@Usuario", Usuario);
                    comando.Parameters.AddWithValue("@Senha", Senha);

                    int resultado = Convert.ToInt32(comando.ExecuteScalar());

                    if (resultado > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível verificar login -> " + ex.Message, "Erro - Verificar Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        public string ValidarCadastro()
        {
            try
            {
                using (MySqlConnection conexaoBanco = new ConexaoBD().Conectar())
                {
                    string consulta = "SELECT COUNT(*) FROM Usuario WHERE Usuario = @Usuario";
                    MySqlCommand comando = new MySqlCommand(consulta, conexaoBanco);
                    comando.Parameters.AddWithValue("@Usuario", Usuario);

                    using (MySqlDataReader leitor = comando.ExecuteReader())
                    {
                        if (leitor.Read())
                        {
                            int count = Convert.ToInt32(leitor[0]);
                            if (count > 0)
                            {
                                leitor.Close();

                                if (ExisteCampoDuplicado("Usuario", Usuario, conexaoBanco))
                                    return "Usuário já está cadastrado.";
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível validar cadastro -> " + ex.Message, "Erro - Validar Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public string BuscarNome()
        {
            try
            {
                using (MySqlConnection conexaoBanco = new ConexaoBD().Conectar())
                {
                    string buscarNomeUsuario = "SELECT Usuario FROM Usuario WHERE Usuario = @Usuario";

                    MySqlCommand comando = new MySqlCommand(buscarNomeUsuario, conexaoBanco);
                    comando.Parameters.AddWithValue("@Usuario", Usuario);


                    object resultado = comando.ExecuteScalar();

                    if (resultado != null)
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
                MessageBox.Show("Não foi possível buscar nome -> " + ex.Message, "Erro - Buscar Nome", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
