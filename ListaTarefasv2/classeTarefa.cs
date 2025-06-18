using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ListaTarefasv2
{
    public class classeTarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Situacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public int Id_usuario { get; set; } // Chave estrangeira para o usuário proprietário da tarefa

        public bool InserirTarefa()
        {
            try
            {
                using (MySqlConnection conexaoBanco = new ConexaoBD().Conectar())
                {
                    string inserir = "INSERT INTO Tarefa (Nome, Descricao, Situacao, DataCriacao, Id_usuario) VALUES (@Nome, @Descricao, @Situacao, NOW(), @Id_usuario)";
                    MySqlCommand comando = new MySqlCommand(inserir, conexaoBanco);
                    comando.Parameters.AddWithValue("@Nome", Nome);
                    comando.Parameters.AddWithValue("@Descricao", Descricao);
                    comando.Parameters.AddWithValue("@Situacao", Situacao);
                    comando.Parameters.AddWithValue("@Id_usuario", Id_usuario);
                    return comando.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir tarefa: " + ex.Message);
                return false;
            }
        }

        public bool AtualizarTarefa()
        {
            try
            {
                using (MySqlConnection conexaoBanco = new ConexaoBD().Conectar())
                {
                    string atualizar = "UPDATE Tarefa SET Nome = @Nome, Descricao = @Descricao, Situacao = @Situacao WHERE Id = @Id AND Id_usuario = @Id_usuario";
                    MySqlCommand comando = new MySqlCommand(atualizar, conexaoBanco);
                    comando.Parameters.AddWithValue("@Id", Id);
                    comando.Parameters.AddWithValue("@Nome", Nome);
                    comando.Parameters.AddWithValue("@Descricao", Descricao);
                    comando.Parameters.AddWithValue("@Situacao", Situacao);
                    comando.Parameters.AddWithValue("@Id_usuario", Id_usuario);
                    return comando.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar tarefa: " + ex.Message);
                return false;
            }
        }

        public static bool ExcluirTarefa(int idTarefa, int idUsuario) // Requer o ID do usuário para exclusão segura
        {
            try
            {
                using (MySqlConnection conexaoBanco = new ConexaoBD().Conectar())
                {
                    string excluir = "DELETE FROM Tarefa WHERE Id = @Id AND Id_usuario = @Id_usuario";
                    MySqlCommand comando = new MySqlCommand(excluir, conexaoBanco);
                    comando.Parameters.AddWithValue("@Id", idTarefa);
                    comando.Parameters.AddWithValue("@Id_usuario", idUsuario);
                    return comando.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir tarefa: " + ex.Message);
                return false;
            }
        }

        public static List<classeTarefa> ListarTarefas(int idUsuario) // Requer o ID do usuário para listar suas tarefas
        {
            List<classeTarefa> lista = new List<classeTarefa>();
            try
            {
                using (MySqlConnection conexaoBanco = new ConexaoBD().Conectar())
                {
                    string selecionar = "SELECT Id, Nome, Descricao, Situacao, DataCriacao, Id_usuario FROM Tarefa WHERE Id_usuario = @Id_usuario ORDER BY DataCriacao DESC";
                    MySqlCommand comando = new MySqlCommand(selecionar, conexaoBanco);
                    comando.Parameters.AddWithValue("@Id_usuario", idUsuario); // Filtra por usuário logado

                    using (MySqlDataReader leitor = comando.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            classeTarefa tarefa = new classeTarefa
                            {
                                Id = Convert.ToInt32(leitor["Id"]),
                                Nome = leitor["Nome"].ToString(),
                                Descricao = leitor["Descricao"].ToString(),
                                Situacao = leitor["Situacao"].ToString(),
                                DataCriacao = Convert.ToDateTime(leitor["DataCriacao"]),
                                Id_usuario = Convert.ToInt32(leitor["Id_usuario"])
                            };
                            lista.Add(tarefa);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar tarefas: " + ex.Message);
            }
            return lista;
        }
    }
}