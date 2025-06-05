using Core;

namespace WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
                    // await LerSetoresRandomicosAsync(diskPath);
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

            for (int i = 0; i < 1000; i++)
            {
                var setores = await diskService.GetSetoresPaginadosAsync(diskPath, i, 100000);
                txtSaida.AppendText($"Página {i}: {setores.Count} setores lidos.{Environment.NewLine}");
                if (setores.Count == 0)
                    break;
                txtSaida.AppendText($"Primeiro setor: {BitConverter.ToString(setores[0])}{Environment.NewLine}");
                txtSaida.AppendText($"Último setor: {BitConverter.ToString(setores[^1])}{Environment.NewLine}");
            }
        }

        private async Task LerSetoresPaginadoAsync(string diskPath)
        {
            var diskService = new DiskService();
            txtSaida.Clear();
            var count = 0;

            for (int i = 0; i < 1000; i++)
            {
                var setores = await diskService.GetSetoresPaginadosAsync(diskPath, i, 100000);
                if (setores.Count == 0)
                    break;
                for (int j = 0; j < setores.Count; j++)
                {
                    txtSaida.AppendText($"Setor {count}: {BitConverter.ToString(setores[j])}{Environment.NewLine}");
                    count++;
                }
            }
        }
    }
}
