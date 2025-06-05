using System;
using System.IO;
using System.Windows.Forms;

namespace SeuNamespace
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            listBoxResultados.Items.Clear();
            string caminho = txtCaminho.Text;

            if (Directory.Exists(caminho))
            {
                try
                {
                    var diretorios = Directory.GetDirectories(caminho);
                    var arquivos = Directory.GetFiles(caminho);

                    listBoxResultados.Items.Add("Diretórios:");
                    foreach (var dir in diretorios)
                        listBoxResultados.Items.Add(dir);

                    listBoxResultados.Items.Add("Arquivos:");
                    foreach (var arq in arquivos)
                        listBoxResultados.Items.Add(arq);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao acessar o caminho: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Caminho não encontrado.");
            }
        }
    }
}