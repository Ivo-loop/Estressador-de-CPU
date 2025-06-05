namespace WinForms
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.txtDiskPath = new System.Windows.Forms.TextBox();
            this.btnReadInfo = new System.Windows.Forms.Button();
            this.lblLogicalSectorSize = new System.Windows.Forms.Label();
            this.lblPhysicalSectorSize = new System.Windows.Forms.Label();
            this.radioButtonRandomico = new System.Windows.Forms.RadioButton();
            this.radioButtonSequencial = new System.Windows.Forms.RadioButton();
            this.txtSaida = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtDiskPath
            // 
            this.txtDiskPath.Location = new System.Drawing.Point(30, 30);
            this.txtDiskPath.Name = "txtDiskPath";
            this.txtDiskPath.Size = new System.Drawing.Size(200, 23);
            this.txtDiskPath.TabIndex = 0;
            this.txtDiskPath.Text = @"\\.\E:";
            // 
            // btnReadInfo
            // 
            this.btnReadInfo.Location = new System.Drawing.Point(250, 30);
            this.btnReadInfo.Name = "btnReadInfo";
            this.btnReadInfo.Size = new System.Drawing.Size(100, 23);
            this.btnReadInfo.TabIndex = 1;
            this.btnReadInfo.Text = "Ler Info";
            this.btnReadInfo.UseVisualStyleBackColor = true;
            this.btnReadInfo.Click += new System.EventHandler(this.btnReadInfo_Click);
            // 
            // lblLogicalSectorSize
            // 
            this.lblLogicalSectorSize.AutoSize = true;
            this.lblLogicalSectorSize.Location = new System.Drawing.Point(30, 70);
            this.lblLogicalSectorSize.Name = "lblLogicalSectorSize";
            this.lblLogicalSectorSize.Size = new System.Drawing.Size(140, 15);
            this.lblLogicalSectorSize.TabIndex = 2;
            this.lblLogicalSectorSize.Text = "LogicalSectorSize: -";
            // 
            // lblPhysicalSectorSize
            // 
            this.lblPhysicalSectorSize.AutoSize = true;
            this.lblPhysicalSectorSize.Location = new System.Drawing.Point(30, 100);
            this.lblPhysicalSectorSize.Name = "lblPhysicalSectorSize";
            this.lblPhysicalSectorSize.Size = new System.Drawing.Size(144, 15);
            this.lblPhysicalSectorSize.TabIndex = 3;
            this.lblPhysicalSectorSize.Text = "PhysicalSectorSize: -";
            // 
            // radioButtonRandomico
            // 
            this.radioButtonRandomico.Text = "Randômico";
            this.radioButtonRandomico.Location = new System.Drawing.Point(400, 20);
            // 
            // radioButtonSequencial
            // 
            this.radioButtonSequencial.Text = "Sequencial";
            this.radioButtonSequencial.Location = new System.Drawing.Point(400, 50);
            // 
            // txtSaida
            // 
            this.txtSaida.Multiline = true;
            this.txtSaida.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSaida.Location = new System.Drawing.Point(20, 120); // ajuste conforme necessário
            this.txtSaida.Size = new System.Drawing.Size(500, 200); // ajuste conforme necessário
            this.txtSaida.Name = "txtSaida";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.txtDiskPath);
            this.Controls.Add(this.btnReadInfo);
            this.Controls.Add(this.lblLogicalSectorSize);
            this.Controls.Add(this.lblPhysicalSectorSize);
            this.Controls.Add(this.radioButtonRandomico);
            this.Controls.Add(this.radioButtonSequencial);
            this.Controls.Add(this.txtSaida);
            this.Name = "Form1";
            this.Text = "Informações do Disco";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
