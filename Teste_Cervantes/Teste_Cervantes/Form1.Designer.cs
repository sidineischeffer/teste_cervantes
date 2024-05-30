namespace Teste_Cervantes
{
    partial class FrmPrincipal
    {
        
        private System.ComponentModel.IContainer components = null;

        
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
            btnAtualizar = new Button();
            btnExcluir = new Button();
            txtCampo = new TextBox();
            txtNum = new TextBox();
            btnAdicionar = new Button();
            label1 = new Label();
            label2 = new Label();
            lastatus = new Label();
            SuspendLayout();
            // 
            // btnAtualizar
            // 
            btnAtualizar.Location = new Point(93, 116);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(75, 23);
            btnAtualizar.TabIndex = 1;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = true;
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(177, 116);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 23);
            btnExcluir.TabIndex = 2;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // txtCampo
            // 
            txtCampo.Location = new Point(15, 35);
            txtCampo.Name = "txtCampo";
            txtCampo.Size = new Size(237, 23);
            txtCampo.TabIndex = 3;
            // 
            // txtNum
            // 
            txtNum.Location = new Point(16, 87);
            txtNum.Name = "txtNum";
            txtNum.Size = new Size(236, 23);
            txtNum.TabIndex = 4;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(12, 116);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(75, 23);
            btnAdicionar.TabIndex = 6;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 17);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 7;
            label1.Text = "Campo Texto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 69);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 8;
            label2.Text = "Campo Númerico";
            // 
            // lastatus
            // 
            lastatus.AutoSize = true;
            lastatus.Location = new Point(12, 146);
            lastatus.Name = "lastatus";
            lastatus.Size = new Size(38, 15);
            lastatus.TabIndex = 9;
            lastatus.Text = "label3";
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(267, 178);
            Controls.Add(lastatus);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAdicionar);
            Controls.Add(txtNum);
            Controls.Add(txtCampo);
            Controls.Add(btnExcluir);
            Controls.Add(btnAtualizar);
            Name = "FrmPrincipal";
            Text = "Teste Cervantes";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private Button btnAtualizar;
        private Button btnExcluir;
        private TextBox txtCampo;
        private TextBox txtNum;
        private Button btnAdicionar;
        private Label label1;
        private Label label2;
        private Label lastatus;
    }
}
