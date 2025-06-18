using System.Windows.Forms;

namespace WinForms
{
    partial class Principal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboDiskPath;
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
            comboDiskPath = new ComboBox();
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
            // comboDiskPath
            // 
            comboDiskPath.DropDownStyle = ComboBoxStyle.DropDownList;
            comboDiskPath.Location = new Point(31, 30);
            comboDiskPath.Margin = new Padding(3, 2, 3, 2);
            comboDiskPath.Name = "comboDiskPath";
            comboDiskPath.Size = new Size(154, 23);
            comboDiskPath.TabIndex = 0;
            // 
            // btnReadInfo
            // 
            btnReadInfo.Location = new Point(250, 30);
            btnReadInfo.Name = "btnReadInfo";
            btnReadInfo.Size = new Size(100, 23);
            btnReadInfo.TabIndex = 1;
            btnReadInfo.Text = "Ler Info";
            btnReadInfo.UseVisualStyleBackColor = true;
            btnReadInfo.Click += BtnReadInfo;
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
            radioButtonSequencial.Checked = true;
            radioButtonSequencial.TabIndex = 5;
            radioButtonSequencial.Text = "Sequencial";
            // 
            // button1
            // 
            button1.Location = new Point(250, 59);
            button1.Name = "button1";
            button1.Size = new Size(100, 23);
            button1.TabIndex = 8;
            button1.Text = "Start Process";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ButtonStartProcess;
            // 
            // button2
            // 
            button2.Location = new Point(250, 88);
            button2.Name = "button2";
            button2.Size = new Size(100, 23);
            button2.TabIndex = 9;
            button2.Text = "Cancelar Processo";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ButtonCancelar;
            // 
            // dataGridViewHex
            // 
            dataGridViewHex.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHex.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            dataGridViewHex.Location = new Point(30, 135);
            dataGridViewHex.Name = "dataGridViewHex";
            dataGridViewHex.RowHeadersWidth = 51;
            dataGridViewHex.Size = new Size(623, 250);
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
            lblBufferSize.Location = new Point(30, 111);
            lblBufferSize.Name = "lblBufferSize";
            lblBufferSize.Size = new Size(175, 15);
            lblBufferSize.TabIndex = 11;
            lblBufferSize.Text = "Tamanho do Buffer -";
            lblBufferSize.Click += lblBufferSize_Click;
            // 
            // comboBufferSize
            // 
            comboBufferSize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBufferSize.Items.AddRange(new object[] { 128, 256, 512, 1024, 2048});
            comboBufferSize.SelectedIndex = 0;
            comboBufferSize.Location = new Point(163, 109);
            comboBufferSize.Margin = new Padding(3, 2, 3, 2);
            comboBufferSize.Name = "comboBufferSize";
            comboBufferSize.Size = new Size(53, 23);
            comboBufferSize.TabIndex = 0;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(695, 400);
            Controls.Add(comboBufferSize);
            Controls.Add(dataGridViewHex);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboDiskPath);
            Controls.Add(btnReadInfo);
            Controls.Add(lblLogicalSectorSize);
            Controls.Add(lblPhysicalSectorSize);
            Controls.Add(radioButtonRandomico);
            Controls.Add(radioButtonSequencial);
            Controls.Add(lblBufferSize);
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
    }
}
