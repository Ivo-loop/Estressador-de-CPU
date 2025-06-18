using System.Text;
using System.Text.RegularExpressions;
using WinForms.cores;
using System.Threading;

namespace WinForms
{
    public partial class Principal : Form
    {
        private CancellationTokenSource _cts;

        public Principal()
        {
            InitializeComponent();
        }

        private void BtnReadInfo(object sender, EventArgs e)
        {
            string diskPath = txtDiskPath.Text;
            try
            {
                var info = DiskReader.GetDiskGeometryInfo(@diskPath);
                lblLogicalSectorSize.Text = $"LogicalSectorSize: {info.LogicalSectorSize}";
                lblPhysicalSectorSize.Text = $"PhysicalSectorSize: {info.PhysicalSectorSize}";

                Application.DoEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao ler informações do disco: " + ex.Message);
            }
        }

        private async Task LerSetoresRandomicosAsync(string diskPath, CancellationToken cancellationToken)
        {
            var diskService = new DiskService();

            var qtdSetores = GetTotalSetores(diskPath);

            if (qtdSetores == -1)
                return;

            for (int i = 0; i < qtdSetores; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var setores = await diskService.GetSetoresRandomizadosAsync(diskPath, qtdSetores, cancellationToken);

                int counter = 0;

                foreach (var setor in setores)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    AdicionarLinhaHex(
                        setor.Key.ToString("X10"),
                        BitConverter.ToString(setor.Value).Replace("-", " "),
                        Encoding.ASCII.GetString(setor.Value).Replace("\0", ".")
                    ); 
                    
                    if (counter % 10 == 0)
                        Application.DoEvents();

                    counter++;
                }
            }
        }

        private long GetTotalSetores(String diskPath)
        {
            try
            {
                var drive = new DriveInfo(Regex.Replace(diskPath, "[^a-zA-Z]", ""));

                return drive.TotalSize / 512;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao ler informações do disco: " + ex.Message);
                return -1;
            }
        }

        private async Task LerSetoresPaginadoAsync(string diskPath, CancellationToken cancellationToken)
        {
            var diskService = new DiskService();
            var qtdSetores = GetTotalSetores(diskPath);

            if (qtdSetores == -1)
                return;

            for (int i = 0; i < qtdSetores; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                int counter = 0;
                var setores = await diskService.GetSetoresPaginadosAsync(diskPath, i, 10000);
                foreach (var setor in setores)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    AdicionarLinhaHex(
                        setor.Key.ToString("X10"),
                        BitConverter.ToString(setor.Value).Replace("-", " "),
                        Encoding.ASCII.GetString(setor.Value).Replace("\0", ".")
                    );

                    if (counter % 10 == 0)
                        Application.DoEvents();

                    counter++;
                }
                if (setores.Count == 0)
                    break;

                Application.DoEvents();
            }
        }

        private void AdicionarLinhaHex(string offset, string hex, string ascii)
        {
            if (dataGridViewHex.Rows.Count >= 500)
            {
                dataGridViewHex.Rows.Clear();
            }
            dataGridViewHex.Rows.Add(offset, hex, ascii);
        }

        private async void ButtonStartProcess(object sender, EventArgs e)
        {
            string diskPath = txtDiskPath.Text;
            _cts = new CancellationTokenSource();

            try
            {
                if (radioButtonRandomico.Checked == true)
                    await LerSetoresRandomicosAsync(diskPath, _cts.Token);
                else
                    await LerSetoresPaginadoAsync(diskPath, _cts.Token);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Leitura cancelada pelo usuário.");
            }
        }

        private void ButtonCancelar(object sender, EventArgs e)
        {
            _cts?.Cancel();
        }
    }
}
