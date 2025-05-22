
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
    public partial class Tarefas : Form
    {
        private int tarefaEmEdicaoId = 0;

        public Tarefas()
        {
            InitializeComponent();
            CarregarTarefas();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            classeTarefa tarefa = new classeTarefa
            {
                Nome = txtNomeTarefa.Text,
                Descricao = txtDescricao.Text,
                Situacao = cbStatus.SelectedItem?.ToString() ?? "Pendente",
            };

            if (tarefa.InserirTarefa())
            {
                MessageBox.Show("Tarefa inserida com sucesso!");
                CarregarTarefas();
            }
            else
            {
                MessageBox.Show("Erro ao inserir tarefa.");
            }
        }

        private void CarregarTarefas()
        {
            List<classeTarefa> lista = classeTarefa.ListarTarefas();
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
                Visible = false 
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

            // Botões no final
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
        }


        private void dgvTarefas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var linha = dgvTarefas.Rows[e.RowIndex];
                int id = Convert.ToInt32(linha.Cells["Id"].Value); //tem um erro aqui, verifique

                if (dgvTarefas.Columns[e.ColumnIndex].Name == "Excluir")
                {
                    DialogResult confirm = MessageBox.Show("Deseja excluir esta tarefa?", "Confirmar", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        if (classeTarefa.ExcluirTarefa(id))
                        {
                            MessageBox.Show("Tarefa excluída com sucesso.");
                            CarregarTarefas();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao excluir.");
                        }
                    }
                }

                if (dgvTarefas.Columns[e.ColumnIndex].Name == "Editar")
                {
                    tarefaEmEdicaoId = id;
                    txtNomeTarefa.Text = linha.Cells["Nome"].Value?.ToString();
                    txtDescricao.Text = linha.Cells["Descricao"].Value?.ToString();
                    cbStatus.SelectedItem = linha.Cells["Situacao"].Value?.ToString();
                }
            }
        }

        private void Tarefas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (tarefaEmEdicaoId == 0) return;

            classeTarefa tarefa = new classeTarefa
            {
                Id = tarefaEmEdicaoId,
                Nome = txtNomeTarefa.Text,
                Descricao = txtDescricao.Text,
                Situacao = cbStatus.SelectedItem?.ToString() ?? "Pendente"
            };

            if (tarefa.AtualizarTarefa())
            {
                MessageBox.Show("Tarefa atualizada com sucesso!");
                tarefaEmEdicaoId = 0;
                LimparCampos();
                CarregarTarefas();
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
            cbStatus.SelectedIndex = -1;
        }
    }
}
