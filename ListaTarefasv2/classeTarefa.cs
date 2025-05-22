using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTarefasv2
{
    internal class classeTarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Situacao { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }

        public static bool ExcluirTarefa(int id)
        {
            try
            {
                using MySqlConnection conexao = new ConexaoBD().Conectar();
                string query = "DELETE FROM Tarefas WHERE Id_tarefa = @Id_tarefa";
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@Id_tarefa", id);
                return comando.ExecuteNonQuery() > 0;
            }
            catch
            {
                return false;
            }
        }


        public bool InserirTarefa()
        {
            try
            {
                using MySqlConnection conexaoBanco = new ConexaoBD().Conectar();
                {
                    string inserir = "INSERT INTO Tarefas (Nome, Descricao, DataCriacao, Situacao) VALUES (@Nome, @Descricao, @DataCriacao, @Situacao)";
                    MySqlCommand comando = new MySqlCommand(inserir, conexaoBanco);
                    comando.Parameters.AddWithValue("@Nome", Nome);
                    comando.Parameters.AddWithValue("@Descricao", Descricao);
                    comando.Parameters.AddWithValue("@DataCriacao", DateTime.Now);
                    comando.Parameters.AddWithValue("@Situacao", Situacao);
                    int resultado = comando.ExecuteNonQuery();
                    return resultado > 0;
                }
            }
            catch 
            {

                return false;
            }
        }
        public static List<classeTarefa> ListarTarefas()
        {
            List<classeTarefa> tarefas = new List<classeTarefa>();

            try
            {
                using MySqlConnection conexaoBanco = new ConexaoBD().Conectar();
                {
                    string query = "SELECT * FROM Tarefas";
                    MySqlCommand comando = new MySqlCommand(query, conexaoBanco);
                    using MySqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        tarefas.Add(new classeTarefa
                        {
                            Id = reader.GetInt32("Id_tarefa"),
                            Nome = reader.GetString("Nome"),
                            Descricao = reader.GetString("Descricao"),
                            DataCriacao = reader.GetDateTime("DataCriacao"),
                            Situacao = reader.GetString("Situacao")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar tarefas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            return tarefas;
        }

        public bool AtualizarTarefa()
        {
            try
            {
                using MySqlConnection conexaoBanco = new ConexaoBD().Conectar();
                string query = "UPDATE Tarefas SET Nome = @Nome, Descricao = @Descricao, Situacao = @Situacao WHERE Id_tarefa = @Id_tarefa";
                MySqlCommand comando = new MySqlCommand(query, conexaoBanco);
                comando.Parameters.AddWithValue("@Nome", Nome);
                comando.Parameters.AddWithValue("@Descricao", Descricao);
                comando.Parameters.AddWithValue("@Situacao", Situacao);
                comando.Parameters.AddWithValue("@Id_tarefa", Id);
                int resultado = comando.ExecuteNonQuery();
                return resultado > 0;
            }
            catch (Exception ex)    
            {
                MessageBox.Show("Erro ao atualizar: " + ex.Message);
                return false;
            }
        }


    }
}
