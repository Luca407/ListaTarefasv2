namespace ListaTarefasv2
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            btnEntrar = new Button();
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
            groupBox1.Controls.Add(btnEntrar);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(llblTelaCadastro);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtSenha);
            groupBox1.Controls.Add(txtUsuario);
            groupBox1.Location = new Point(125, 78);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 248);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // btnEntrar
            // 
            btnEntrar.Location = new Point(59, 159);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(75, 23);
            btnEntrar.TabIndex = 7;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 188);
            label3.Name = "label3";
            label3.Size = new Size(91, 15);
            label3.TabIndex = 6;
            label3.Text = "Não tem conta?";
            // 
            // llblTelaCadastro
            // 
            llblTelaCadastro.AutoSize = true;
            llblTelaCadastro.Location = new Point(61, 203);
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
            label2.Location = new Point(48, 109);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 4;
            label2.Text = "Digite a Senha";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 49);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 3;
            label1.Text = "Digite o Usuário";
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(48, 127);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(100, 23);
            txtSenha.TabIndex = 2;
            txtSenha.UseSystemPasswordChar = true;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(48, 67);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(100, 23);
            txtUsuario.TabIndex = 1;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 433);
            Controls.Add(groupBox1);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            FormClosed += Login_FormClosed;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label3;
        private LinkLabel llblTelaCadastro;
        private Label label2;
        private Label label1;
        private TextBox txtSenha;
        private TextBox txtUsuario;
        private Button btnEntrar;
    }
}
