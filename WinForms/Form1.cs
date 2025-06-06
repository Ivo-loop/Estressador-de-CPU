using Core;

namespace WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
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
            var random = new Random();
            var tamanhoMaximo = diskService.GetMaxSetores(diskPath);

            var indices = new List<long>();
            for (int i = 0; i < tamanhoMaximo; i++)
            {
                indices.Add(LongRandom(0, tamanhoMaximo, random));
            }

            var setores = await diskService.GetSetoresRandomizadosAsync(diskPath, indices);

            for (int i = 0; i < setores.Count; i++)
            {
                if (!chkOcultarLeitura.Checked)
                {
                    txtSaida.AppendText($"Setor aleatório {indices[i]}: {BitConverter.ToString(setores[i])}{Environment.NewLine}");
                }
                totalSetores++;
                lblSetoresProcessados.Text = $"Setores processados: {totalSetores}";
                Application.DoEvents(); // Atualiza a interface
            }
        }

        private long LongRandom(long min, long max, Random rand)
        {
            long result = rand.Next((Int32)(min >> 32), (Int32)(max >> 32));
            result = (result << 32);
            result = result | (long)rand.Next((Int32)min, (Int32)max);
            return result;
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
    }
}
