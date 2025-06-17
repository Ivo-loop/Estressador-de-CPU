namespace WinForms
{
    partial class Principal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtDiskPath;
        private System.Windows.Forms.Button btnReadInfo;
        private System.Windows.Forms.Label lblLogicalSectorSize;
        private System.Windows.Forms.Label lblPhysicalSectorSize;
        private System.Windows.Forms.RadioButton radioButtonRandomico;
        private System.Windows.Forms.RadioButton radioButtonSequencial;
        private System.Windows.Forms.TextBox txtSaida;
        private System.Windows.Forms.CheckBox chkOcultarLeitura;

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
            txtDiskPath = new TextBox();
            btnReadInfo = new Button();
            lblLogicalSectorSize = new Label();
            lblPhysicalSectorSize = new Label();
            radioButtonRandomico = new RadioButton();
            radioButtonSequencial = new RadioButton();
            txtSaida = new TextBox();
            chkOcultarLeitura = new CheckBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // txtDiskPath
            // 
            txtDiskPath.Location = new Point(30, 30);
            txtDiskPath.Name = "txtDiskPath";
            txtDiskPath.Size = new Size(200, 23);
            txtDiskPath.TabIndex = 0;
            txtDiskPath.Text = "\\\\.\\E:";
            // 
            // btnReadInfo
            // 
            btnReadInfo.Location = new Point(250, 30);
            btnReadInfo.Name = "btnReadInfo";
            btnReadInfo.Size = new Size(100, 23);
            btnReadInfo.TabIndex = 1;
            btnReadInfo.Text = "Ler Info";
            btnReadInfo.UseVisualStyleBackColor = true;
            btnReadInfo.Click += btnReadInfo_Click;
            // 
            // lblLogicalSectorSize
            // 
            lblLogicalSectorSize.AutoSize = true;
            lblLogicalSectorSize.Location = new Point(30, 59);
            lblLogicalSectorSize.Name = "lblLogicalSectorSize";
            lblLogicalSectorSize.Size = new Size(109, 15);
            lblLogicalSectorSize.TabIndex = 2;
            lblLogicalSectorSize.Text = "LogicalSectorSize: -";
            // 
            // lblPhysicalSectorSize
            // 
            lblPhysicalSectorSize.AutoSize = true;
            lblPhysicalSectorSize.Location = new Point(31, 85);
            lblPhysicalSectorSize.Name = "lblPhysicalSectorSize";
            lblPhysicalSectorSize.Size = new Size(114, 15);
            lblPhysicalSectorSize.TabIndex = 3;
            lblPhysicalSectorSize.Text = "PhysicalSectorSize: -";
            // 
            // radioButtonRandomico
            // 
            radioButtonRandomico.Location = new Point(373, 30);
            radioButtonRandomico.Name = "radioButtonRandomico";
            radioButtonRandomico.Size = new Size(104, 24);
            radioButtonRandomico.TabIndex = 4;
            radioButtonRandomico.Text = "Randômico";
            // 
            // radioButtonSequencial
            // 
            radioButtonSequencial.Location = new Point(373, 58);
            radioButtonSequencial.Name = "radioButtonSequencial";
            radioButtonSequencial.Size = new Size(104, 24);
            radioButtonSequencial.TabIndex = 5;
            radioButtonSequencial.Text = "Sequencial";
            // 
            // txtSaida
            // 
            txtSaida.Location = new Point(30, 118);
            txtSaida.Multiline = true;
            txtSaida.Name = "txtSaida";
            txtSaida.ScrollBars = ScrollBars.Vertical;
            txtSaida.Size = new Size(500, 200);
            txtSaida.TabIndex = 6;
            // 
            // chkOcultarLeitura
            // 
            chkOcultarLeitura.AutoSize = true;
            chkOcultarLeitura.Location = new Point(30, 358);
            chkOcultarLeitura.Name = "chkOcultarLeitura";
            chkOcultarLeitura.Size = new Size(199, 19);
            chkOcultarLeitura.TabIndex = 0;
            chkOcultarLeitura.Text = "Não mostrar a leitura dos setores";
            chkOcultarLeitura.CheckedChanged += chkOcultarLeitura_CheckedChanged;
            // 
            // button1
            // 
            button1.Location = new Point(250, 59);
            button1.Name = "button1";
            button1.Size = new Size(100, 23);
            button1.TabIndex = 8;
            button1.Text = "Start Process";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(250, 88);
            button2.Name = "button2";
            button2.Size = new Size(100, 23);
            button2.TabIndex = 9;
            button2.Text = "Cancelar Processo";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 400);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(chkOcultarLeitura);
            Controls.Add(txtDiskPath);
            Controls.Add(btnReadInfo);
            Controls.Add(lblLogicalSectorSize);
            Controls.Add(lblPhysicalSectorSize);
            Controls.Add(radioButtonRandomico);
            Controls.Add(radioButtonSequencial);
            Controls.Add(txtSaida);
            Name = "Form1";
            Text = "Informações do Disco";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
    }
}
