namespace WinForms.cores
{
    internal class DiskService
    {
        /// <summary>
        /// Retorna os setores do disco físico de forma paginada.
        /// </summary>
        /// <param name="diskPath">Caminho do disco físico (ex: "\\\\.\\PhysicalDrive0").</param>
        /// <param name="pagina">Número da página (iniciando em 0).</param>
        /// <param name="tamanhoPagina">Quantidade de setores por página.</param>
        /// <returns>Lista de arrays de bytes, cada um representando um setor.</returns>
        /// <exception cref="IOException">Lançada se houver erro na leitura do disco.</exception>
        public async Task<Dictionary<long, byte[]>> GetSetoresPaginadosAsync(string diskPath, int pagina, int tamanhoPagina)
        {
            var (path, logicalSectorSize, _) = DiskReader.GetDiskGeometryInfo(diskPath);
            var setores = new Dictionary<long, byte[]>();

            using var stream = DiskReader.OpenPhysicalDisk(diskPath);

            long offset = (long)pagina * tamanhoPagina * logicalSectorSize;
            stream.Seek(offset, SeekOrigin.Begin);

            var buffer = new byte[logicalSectorSize];
            for (int i = 0; i < tamanhoPagina; i++)
            {
                int lidos = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (lidos == 0) break;

                var setor = new byte[lidos];
                Array.Copy(buffer, setor, lidos);
                setores.Add(offset+i, setor);
            }

            return setores;
        }

        /// <summary>
        /// Lê setores do disco físico em posições aleatórias.
        /// </summary>
        /// <param name="diskPath">Caminho do disco físico (ex: "\\\\.\\PhysicalDrive0").</param>
        /// <param name="indices">Lista de índices de setores a serem lidos.</param>
        /// <returns>Lista de arrays de bytes, cada um representando um setor lido aleatoriamente.</returns>
        /// <exception cref="IOException">Lançada se houver erro na leitura do disco.</exception>
        public async Task<Dictionary<long, byte[]>> GetSetoresRandomizadosAsync(string diskPath, long qtdMaxSetores, CancellationToken cancellationToken, int rodaMaxima = 1000)
        {
            var (path, logicalSectorSize, _) = DiskReader.GetDiskGeometryInfo(diskPath);
            var setores = new Dictionary<long, byte[]>();

            using var stream = DiskReader.OpenPhysicalDisk(diskPath);
            var buffer = new byte[logicalSectorSize];

            var random = new Random();

            for (int i = 0; i < rodaMaxima; i ++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                long offset = LongRandom(0, qtdMaxSetores, random) * logicalSectorSize;
                stream.Seek(offset, SeekOrigin.Begin);

                int lidos = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (lidos == 0) break; // Fim do disco

                var setor = new byte[lidos];
                Array.Copy(buffer, setor, lidos);
                setores.Add(offset + i, setor);
            }

            return setores;
        }

        private long LongRandom(long min, long max, Random rand)
        {
            long result = rand.Next((int)(min >> 32), (int)(max >> 32));
            result = result << 32;
            result = result | (long)rand.Next((int)min, (int)max);
            return result;
        }

        /// <summary>
        /// Retorna os setores físicos do disco de forma paginada.
        /// </summary>
        /// <param name="diskPath">Caminho do disco físico (ex: "\\\\.\\PhysicalDrive0").</param>
        /// <param name="pagina">Número da página (iniciando em 0).</param>
        /// <param name="tamanhoPagina">Quantidade de setores por página.</param>
        /// <returns>Lista de arrays de bytes, cada um representando um setor físico.</returns>
        /// <exception cref="IOException">Lançada se houver erro na leitura do disco.</exception>
        public async Task<List<byte[]>> GetSetoresFisicosPaginadosAsync(string diskPath, int pagina, int tamanhoPagina)
        {
            var (path, _, physicalSectorSize) = DiskReader.GetDiskGeometryInfo(diskPath);
            var setores = new List<byte[]>(tamanhoPagina);

            using var stream = DiskReader.OpenPhysicalDisk(diskPath);

            long offset = (long)pagina * tamanhoPagina * physicalSectorSize;
            stream.Seek(offset, SeekOrigin.Begin);

            var buffer = new byte[physicalSectorSize];
            for (int i = 0; i < tamanhoPagina; i++)
            {
                int lidos = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (lidos == 0) break; 

                var setor = new byte[lidos];
                Array.Copy(buffer, setor, lidos);
                setores.Add(setor);
            }

            return setores;
        }

        /// <summary>
        /// Lê setores físicos do disco em posições aleatórias.
        /// </summary>
        /// <param name="diskPath">Caminho do disco físico (ex: "\\\\.\\PhysicalDrive0").</param>
        /// <param name="indices">Lista de índices de setores físicos a serem lidos.</param>
        /// <returns>Lista de arrays de bytes, cada um representando um setor físico lido aleatoriamente.</returns>
        /// <exception cref="IOException">Lançada se houver erro na leitura do disco.</exception>
        public async Task<List<byte[]>> GetSetoresFisicosRandomizadosAsync(string diskPath, IEnumerable<long> indices)
        {
            var (path, _, physicalSectorSize) = DiskReader.GetDiskGeometryInfo(diskPath);
            var setores = new List<byte[]>();

            using var stream = DiskReader.OpenPhysicalDisk(diskPath);
            var buffer = new byte[physicalSectorSize];

            foreach (var indice in indices)
            {
                if (indice < 0) continue;
                long offset = indice * physicalSectorSize;
                stream.Seek(offset, SeekOrigin.Begin);

                int lidos = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (lidos == 0) break; 

                var setor = new byte[lidos];
                Array.Copy(buffer, setor, lidos);
                setores.Add(setor);
            }

            return setores;
        }

        /// <summary>
        /// Retorna o número máximo de setores do disco físico.
        /// </summary>
        /// <param name="diskPath">Caminho do disco físico (ex: "\\\\.\\PhysicalDrive0").</param>
        /// <param name="usarSetorFisico">Se true, usa o tamanho do setor físico; caso contrário, usa o lógico.</param>
        /// <returns>Número total de setores do disco.</returns>
        public long GetMaxSetores(string diskPath, bool usarSetorFisico = false)
        {
            var (path, logicalSectorSize, physicalSectorSize) = DiskReader.GetDiskGeometryInfo(diskPath);

            using var stream = DiskReader.OpenPhysicalDisk(diskPath);
            long tamanhoDisco = stream.Length;
            uint setorSize = usarSetorFisico ? physicalSectorSize : logicalSectorSize;

            if (setorSize == 0)
                throw new InvalidOperationException("Tamanho do setor inválido.");

            return tamanhoDisco / setorSize;
        }
    }
}
