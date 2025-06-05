namespace SeuNamespace
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtCaminho;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.ListBox listBoxResultados;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtCaminho = new System.Windows.Forms.TextBox();
            this.btnListar = new System.Windows.Forms.Button();
            this.listBoxResultados = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtCaminho
            // 
            this.txtCaminho.Location = new System.Drawing.Point(12, 12);
            this.txtCaminho.Name = "txtCaminho";
            this.txtCaminho.Size = new System.Drawing.Size(400, 23);
            this.txtCaminho.TabIndex = 0;
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(418, 12);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(75, 23);
            this.btnListar.TabIndex = 1;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // listBoxResultados
            // 
            this.listBoxResultados.FormattingEnabled = true;
            this.listBoxResultados.ItemHeight = 15;
            this.listBoxResultados.Location = new System.Drawing.Point(12, 41);
            this.listBoxResultados.Name = "listBoxResultados";
            this.listBoxResultados.Size = new System.Drawing.Size(481, 259);
            this.listBoxResultados.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 315);
            this.Controls.Add(this.listBoxResultados);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.txtCaminho);
            this.Name = "Form1";
            this.Text = "Leitor de Diretórios";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}