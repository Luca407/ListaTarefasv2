using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ListaTarefasv2
{
    public partial class Tarefas : Form
    {
        private int tarefaEmEdicaoId = 0;
        private int usuarioLogadoId; // Variável para armazenar o ID do usuário logado

        public Tarefas()
        {
            InitializeComponent();
            // Pega o ID do usuário logado da classe Login
            usuarioLogadoId = Login.UsuarioLogadoId;
            CarregarTarefas();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // Validação simples para garantir que o nome da tarefa não esteja vazio
            if (string.IsNullOrWhiteSpace(txtNomeTarefa.Text))
            {
                MessageBox.Show("O nome da tarefa não pode ser vazio.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            classeTarefa tarefa = new classeTarefa
            {
                Nome = txtNomeTarefa.Text,
                Descricao = txtDescricao.Text,
                Situacao = cbStatus.SelectedItem?.ToString() ?? "Pendente",
                Id_usuario = usuarioLogadoId // Associa a tarefa ao usuário logado
            };

            if (tarefa.InserirTarefa())
            {
                MessageBox.Show("Tarefa inserida com sucesso!");
                LimparCampos(); // Limpa os campos após o cadastro
                CarregarTarefas(); // Recarrega o DataGrid
            }
            else
            {
                MessageBox.Show("Erro ao inserir tarefa.");
            }
        }

        private void CarregarTarefas()
        {
            // Carrega tarefas APENAS para o usuário logado
            List<classeTarefa> lista = classeTarefa.ListarTarefas(usuarioLogadoId);
            dgvTarefas.Columns.Clear();
            dgvTarefas.DataSource = null;
            dgvTarefas.AutoGenerateColumns = false;
            dgvTarefas.ReadOnly = true;
            dgvTarefas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTarefas.AllowUserToAddRows = false;

            dgvTarefas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                Name = "Id",
                Visible = false // Mantém o ID oculto
            });

            dgvTarefas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nome",
                HeaderText = "Nome",
                Name = "Nome"
            });

            dgvTarefas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Descricao",
                HeaderText = "Descrição",
                Name = "Descricao"
            });

            dgvTarefas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Situacao",
                HeaderText = "Situação",
                Name = "Situacao"
            });

            dgvTarefas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataCriacao",
                HeaderText = "Data de Criação",
                Name = "DataCriacao"
            });

            // Botões de ação
            dgvTarefas.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Editar",
                HeaderText = "Editar",
                Text = "✏️",
                UseColumnTextForButtonValue = true
            });

            dgvTarefas.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Excluir",
                HeaderText = "Excluir",
                Text = "🗑️",
                UseColumnTextForButtonValue = true
            });

            dgvTarefas.DataSource = lista;
            LimparCampos(); // Limpa os campos após carregar as tarefas
        }

        private void Tarefas_FormClosed(object sender, FormClosedEventArgs e)   
        {
            Application.Exit(); // Garante que o aplicativo seja encerrado ao fechar esta tela
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (tarefaEmEdicaoId == 0) // Verifica se alguma tarefa foi selecionada para edição
            {
                MessageBox.Show("Selecione uma tarefa para editar primeiro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Validação simples para garantir que o nome da tarefa não esteja vazio
            if (string.IsNullOrWhiteSpace(txtNomeTarefa.Text))
            {
                MessageBox.Show("O nome da tarefa não pode ser vazio.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            classeTarefa tarefa = new classeTarefa
            {
                Id = tarefaEmEdicaoId, // ID da tarefa que está sendo atualizada
                Nome = txtNomeTarefa.Text,
                Descricao = txtDescricao.Text,
                Situacao = cbStatus.SelectedItem?.ToString() ?? "Pendente",
                Id_usuario = usuarioLogadoId // Garante que a atualização é para a tarefa do usuário logado
            };

            if (tarefa.AtualizarTarefa())
            {
                MessageBox.Show("Tarefa atualizada com sucesso!");
                tarefaEmEdicaoId = 0; // Reseta o ID da tarefa em edição
                CarregarTarefas(); // Recarrega o DataGrid
                LimparCampos(); // Limpa os campos após a atualização
            }
            else
            {
                MessageBox.Show("Erro ao atualizar tarefa.");
            }
        }

        private void LimparCampos()
        {
            txtNomeTarefa.Clear();
            txtDescricao.Clear();
            cbStatus.SelectedIndex = -1; // Limpa a seleção do ComboBox
        }

        private void dgvTarefas_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var linha = dgvTarefas.Rows[e.RowIndex];

                int idTarefaSelecionada = Convert.ToInt32(linha.Cells["Id"].Value);


                if (dgvTarefas.Columns[e.ColumnIndex].Name == "Excluir")
                {
                    DialogResult confirm = MessageBox.Show("Deseja realmente excluir esta tarefa?", "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {

                        if (classeTarefa.ExcluirTarefa(idTarefaSelecionada, usuarioLogadoId))
                        {
                            MessageBox.Show("Tarefa excluída com sucesso.");
                            CarregarTarefas();
                             
                        }
                        else
                        {
                            MessageBox.Show("Erro ao excluir tarefa.");
                        }
                    }
                }

                // Lógica para o botão "Editar"
                if (dgvTarefas.Columns[e.ColumnIndex].Name == "Editar")
                {
                    tarefaEmEdicaoId = idTarefaSelecionada; // Armazena o ID da tarefa que será editada
                    txtNomeTarefa.Text = linha.Cells["Nome"].Value?.ToString();
                    txtDescricao.Text = linha.Cells["Descricao"].Value?.ToString();
                    cbStatus.SelectedItem = linha.Cells["Situacao"].Value?.ToString();
                     
                }
            }
        }
    }
}