using Core;
using System.Text.RegularExpressions;
using WinForms.cores;

namespace WinForms
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();

            // CheckBox para ocultar a leitura dos setores
            this.chkOcultarLeitura = new System.Windows.Forms.CheckBox();
            this.chkOcultarLeitura.AutoSize = true;
            this.chkOcultarLeitura.Location = new System.Drawing.Point(20, 370); // ajuste conforme necessário
            this.chkOcultarLeitura.Name = "chkOcultarLeitura";
            this.chkOcultarLeitura.Size = new System.Drawing.Size(220, 19);
            this.chkOcultarLeitura.Text = "Não mostrar a leitura dos setores";
            this.Controls.Add(this.chkOcultarLeitura);
        }

        private async void btnReadInfo_Click(object sender, EventArgs e)
        {
            string diskPath = txtDiskPath.Text;
            try
            {
                var info = DiskReader.GetDiskGeometryInfo(@diskPath);
                lblLogicalSectorSize.Text = $"LogicalSectorSize: {info.LogicalSectorSize}";
                lblPhysicalSectorSize.Text = $"PhysicalSectorSize: {info.PhysicalSectorSize}";

                // Verifica se a opção "Randômico" está selecionada
                if (radioButtonRandomico.Checked == true)
                {
                    await LerSetoresRandomicosAsync(diskPath);
                }
                else
                {
                    // Lê setores de forma sequencial (pode ser implementado se necessário)
                    await LerSetoresPaginadoAsync(diskPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao ler informações do disco: " + ex.Message);
            }
        }

        private async Task LerSetoresRandomicosAsync(string diskPath)
        {
            var diskService = new DiskService();
            txtSaida.Clear();
            int totalSetores = 0;
            lblSetoresProcessados.Text = "Setores processados: 0";

            var qtdSetores = GetTotalSetores(diskPath);

            for (int i = 0; i < qtdSetores; i++)
            {
                var setores = await diskService.GetSetoresRandomizadosAsync(diskPath, qtdSetores);
                if (!chkOcultarLeitura.Checked)
                {
                    txtSaida.AppendText($"Setor aleatório, rodada {i}: {BitConverter.ToString(setores.First())}{Environment.NewLine}");
                }
                totalSetores++;
                lblSetoresProcessados.Text = $"Setores processados: {totalSetores}";
                Application.DoEvents();
            }
        }


        private long GetTotalSetores(String diskPath)
        {
            var drive = new DriveInfo(Regex.Replace(diskPath, "[^a-zA-Z]", ""));

            return drive.TotalSize / 512;
        }

        private async Task LerSetoresPaginadoAsync(string diskPath)
        {
            var diskService = new DiskService();
            txtSaida.Clear();
            int count = 0;
            lblSetoresProcessados.Text = "Setores processados: 0";

            for (int i = 0; i < 1000; i++)
            {
                var setores = await diskService.GetSetoresPaginadosAsync(diskPath, i, 100000);
                if (setores.Count == 0)
                    break;
                if (!chkOcultarLeitura.Checked)
                {
                    count += setores.Count;
                    txtSaida.AppendText($"Página {i}: {setores.Count} setores lidos.{Environment.NewLine}");
                    lblSetoresProcessados.Text = $"Setores processados: {count}";
                }
                else
                {
                    for (int j = 0; j < setores.Count; j++)
                    {
                        if (!chkOcultarLeitura.Checked)
                        {
                            txtSaida.AppendText($"Setor {count}: {BitConverter.ToString(setores[j])}{Environment.NewLine}");
                        }
                        count++;
                        lblSetoresProcessados.Text = $"Setores processados: {count}";
                        Application.DoEvents(); // Atualiza a interface
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void chkOcultarLeitura_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
