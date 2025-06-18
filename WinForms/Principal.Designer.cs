using System.Windows.Forms;

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
        private System.Windows.Forms.DataGridView dataGridViewHex;
        private System.Windows.Forms.Label lblBufferSize;
        private System.Windows.Forms.ComboBox comboBufferSize;

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
            button1 = new Button();
            button2 = new Button();
            dataGridViewHex = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            lblBufferSize = new Label();
            comboBufferSize = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHex).BeginInit();
            SuspendLayout();
            // 
            // txtDiskPath
            // 
            txtDiskPath.Location = new Point(34, 40);
            txtDiskPath.Margin = new Padding(3, 4, 3, 4);
            txtDiskPath.Name = "txtDiskPath";
            txtDiskPath.Size = new Size(228, 27);
            txtDiskPath.TabIndex = 0;
            txtDiskPath.Text = "\\\\.\\E:";
            // 
            // btnReadInfo
            // 
            btnReadInfo.Location = new Point(286, 40);
            btnReadInfo.Margin = new Padding(3, 4, 3, 4);
            btnReadInfo.Name = "btnReadInfo";
            btnReadInfo.Size = new Size(114, 31);
            btnReadInfo.TabIndex = 1;
            btnReadInfo.Text = "Ler Info";
            btnReadInfo.UseVisualStyleBackColor = true;
            btnReadInfo.Click += BtnReadInfo;
            // 
            // lblLogicalSectorSize
            // 
            lblLogicalSectorSize.AutoSize = true;
            lblLogicalSectorSize.Location = new Point(34, 79);
            lblLogicalSectorSize.Name = "lblLogicalSectorSize";
            lblLogicalSectorSize.Size = new Size(139, 20);
            lblLogicalSectorSize.TabIndex = 2;
            lblLogicalSectorSize.Text = "LogicalSectorSize: -";
            // 
            // lblPhysicalSectorSize
            // 
            lblPhysicalSectorSize.AutoSize = true;
            lblPhysicalSectorSize.Location = new Point(35, 113);
            lblPhysicalSectorSize.Name = "lblPhysicalSectorSize";
            lblPhysicalSectorSize.Size = new Size(143, 20);
            lblPhysicalSectorSize.TabIndex = 3;
            lblPhysicalSectorSize.Text = "PhysicalSectorSize: -";
            // 
            // radioButtonRandomico
            // 
            radioButtonRandomico.Location = new Point(426, 40);
            radioButtonRandomico.Margin = new Padding(3, 4, 3, 4);
            radioButtonRandomico.Name = "radioButtonRandomico";
            radioButtonRandomico.Size = new Size(119, 32);
            radioButtonRandomico.TabIndex = 4;
            radioButtonRandomico.Text = "Randômico";
            // 
            // radioButtonSequencial
            // 
            radioButtonSequencial.Location = new Point(426, 77);
            radioButtonSequencial.Margin = new Padding(3, 4, 3, 4);
            radioButtonSequencial.Name = "radioButtonSequencial";
            radioButtonSequencial.Size = new Size(119, 32);
            radioButtonSequencial.TabIndex = 5;
            radioButtonSequencial.Text = "Sequencial";
            // 
            // button1
            // 
            button1.Location = new Point(286, 79);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(114, 31);
            button1.TabIndex = 8;
            button1.Text = "Start Process";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ButtonStartProcess;
            // 
            // button2
            // 
            button2.Location = new Point(286, 117);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(114, 31);
            button2.TabIndex = 9;
            button2.Text = "Cancelar Processo";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ButtonCancelar;
            // 
            // dataGridViewHex
            // 
            dataGridViewHex.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHex.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            dataGridViewHex.Location = new Point(34, 180);
            dataGridViewHex.Margin = new Padding(3, 4, 3, 4);
            dataGridViewHex.Name = "dataGridViewHex";
            dataGridViewHex.RowHeadersWidth = 51;
            dataGridViewHex.Size = new Size(712, 333);
            dataGridViewHex.TabIndex = 10;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "offset";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Hex";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 300;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Ascii";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 150;
            // 
            // lblBufferSize
            // 
            lblBufferSize.Location = new Point(34, 148);
            lblBufferSize.Name = "lblBufferSize";
            lblBufferSize.Size = new Size(200, 20);
            lblBufferSize.TabIndex = 11;
            lblBufferSize.Text = "Tamanho do Buffer -";
            lblBufferSize.Click += lblBufferSize_Click;
            // 
            // comboBufferSize
            // 
            comboBufferSize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBufferSize.Items.AddRange(new object[] { 128, 256, 512,1024 });
            comboBufferSize.SelectedItem = 128;
            comboBufferSize.Location = new Point(186, 145);
            comboBufferSize.Name = "comboBufferSize";
            comboBufferSize.Size = new Size(60, 28);
            comboBufferSize.TabIndex = 0;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 533);
            Controls.Add(comboBufferSize);
            Controls.Add(dataGridViewHex);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtDiskPath);
            Controls.Add(btnReadInfo);
            Controls.Add(lblLogicalSectorSize);
            Controls.Add(lblPhysicalSectorSize);
            Controls.Add(radioButtonRandomico);
            Controls.Add(radioButtonSequencial);
            Controls.Add(lblBufferSize);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Principal";
            Text = "Informações do Disco";
            ((System.ComponentModel.ISupportInitialize)dataGridViewHex).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Button button1;
        private Button button2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}
