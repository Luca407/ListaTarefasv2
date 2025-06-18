namespace ListaTarefasv2
{
    partial class Tarefas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            btnAtualizar = new Button();
            txtNomeTarefa = new TextBox();
            cbStatus = new ComboBox();
            txtDescricao = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnCadastrar = new Button();
            dgvTarefas = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTarefas).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAtualizar);
            groupBox1.Controls.Add(txtNomeTarefa);
            groupBox1.Controls.Add(cbStatus);
            groupBox1.Controls.Add(txtDescricao);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnCadastrar);
            groupBox1.Location = new Point(52, 44);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(233, 358);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // btnAtualizar
            // 
            btnAtualizar.Location = new Point(143, 278);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(75, 23);
            btnAtualizar.TabIndex = 11;
            btnAtualizar.Text = "Editar";
            btnAtualizar.UseVisualStyleBackColor = true;
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // txtNomeTarefa
            // 
            txtNomeTarefa.Location = new Point(49, 54);
            txtNomeTarefa.Name = "txtNomeTarefa";
            txtNomeTarefa.Size = new Size(154, 23);
            txtNomeTarefa.TabIndex = 10;
            // 
            // cbStatus
            // 
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "Pendente", "Concluído" });
            cbStatus.Location = new Point(49, 221);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(121, 23);
            cbStatus.TabIndex = 9;
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(49, 104);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(154, 85);
            txtDescricao.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(49, 203);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 6;
            label3.Text = "Situação";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 86);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 5;
            label2.Text = "Descrição";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 36);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 4;
            label1.Text = "Nome";
            // 
            // btnCadastrar
            // 
            btnCadastrar.Location = new Point(32, 278);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(75, 23);
            btnCadastrar.TabIndex = 2;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // dgvTarefas
            // 
            dgvTarefas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTarefas.Location = new Point(334, 24);
            dgvTarefas.Name = "dgvTarefas";
            dgvTarefas.Size = new Size(433, 378);
            dgvTarefas.TabIndex = 3;
            dgvTarefas.CellContentClick += dgvTarefas_CellContentClick_1;
            // 
            // Tarefas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 433);
            Controls.Add(dgvTarefas);
            Controls.Add(groupBox1);
            Name = "Tarefas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tarefas";
            FormClosed += Tarefas_FormClosed;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTarefas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnCadastrar;
        private Label label4;
        private TextBox txtNome;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cbStatus;
        private LinkLabel llblTelaCadastro;
        private TextBox txtSenha;
        private TextBox txtUsuario;
        private DataGridView dgvTarefas;
        private TextBox txtDescricao;
        private TextBox txtNomeTarefa;
        private Button btnAtualizar;
    }
}