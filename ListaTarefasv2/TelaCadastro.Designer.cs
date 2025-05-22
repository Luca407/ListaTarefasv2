namespace ListaTarefasv2
{
    partial class TelaCadastro
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
            btnCadastro = new Button();
            label4 = new Label();
            txtNome = new TextBox();
            label3 = new Label();
            llblTelaCadastro = new LinkLabel();
            label2 = new Label();
            label1 = new Label();
            txtSenha = new TextBox();
            txtUsuario = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCadastro);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtNome);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(llblTelaCadastro);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtSenha);
            groupBox1.Controls.Add(txtUsuario);
            groupBox1.Location = new Point(134, 58);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 279);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // btnCadastro
            // 
            btnCadastro.Location = new Point(57, 181);
            btnCadastro.Name = "btnCadastro";
            btnCadastro.Size = new Size(75, 23);
            btnCadastro.TabIndex = 2;
            btnCadastro.Text = "Cadastrar";
            btnCadastro.UseVisualStyleBackColor = true;
            btnCadastro.Click += btnCadastro_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(48, 46);
            label4.Name = "label4";
            label4.Size = new Size(84, 15);
            label4.TabIndex = 8;
            label4.Text = "Digite o Nome";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(48, 64);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(100, 23);
            txtNome.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 227);
            label3.Name = "label3";
            label3.Size = new Size(106, 15);
            label3.TabIndex = 6;
            label3.Text = "Já tem uma conta?";
            // 
            // llblTelaCadastro
            // 
            llblTelaCadastro.AutoSize = true;
            llblTelaCadastro.Location = new Point(61, 242);
            llblTelaCadastro.Name = "llblTelaCadastro";
            llblTelaCadastro.Size = new Size(69, 15);
            llblTelaCadastro.TabIndex = 5;
            llblTelaCadastro.TabStop = true;
            llblTelaCadastro.Text = "Cadastre-se";
            llblTelaCadastro.LinkClicked += llblTelaCadastro_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 134);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 4;
            label2.Text = "Digite a Senha";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 90);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 3;
            label1.Text = "Digite o Usuário";
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(48, 152);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(100, 23);
            txtSenha.TabIndex = 2;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(48, 108);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(100, 23);
            txtUsuario.TabIndex = 1;
            // 
            // TelaCadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 433);
            Controls.Add(groupBox1);
            Name = "TelaCadastro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TelaCadastro";
            FormClosed += TelaCadastro_FormClosed;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label4;
        private TextBox txtNome;
        private Label label3;
        private LinkLabel llblTelaCadastro;
        private Label label2;
        private Label label1;
        private TextBox txtSenha;
        private TextBox txtUsuario;
        private Button btnCadastro;
    }
}