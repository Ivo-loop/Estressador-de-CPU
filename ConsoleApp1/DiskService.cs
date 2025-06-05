namespace Core
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
        public async Task<List<byte[]>> GetSetoresPaginadosAsync(string diskPath, int pagina, int tamanhoPagina)
        {
            var (path, logicalSectorSize, _) = DiskReader.GetDiskGeometryInfo(diskPath);
            var setores = new List<byte[]>(tamanhoPagina);

            using var stream = DiskReader.OpenPhysicalDisk(diskPath);

            long offset = (long)pagina * tamanhoPagina * logicalSectorSize;
            stream.Seek(offset, SeekOrigin.Begin);

            var buffer = new byte[logicalSectorSize];
            for (int i = 0; i < tamanhoPagina; i++)
            {
                int lidos = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (lidos == 0) break; // Fim do disco
                // Cria uma cópia do buffer para evitar sobrescrita
                var setor = new byte[lidos];
                Array.Copy(buffer, setor, lidos);
                setores.Add(setor);
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
        public async Task<List<byte[]>> GetSetoresRandomizadosAsync(string diskPath, IEnumerable<long> indices)
        {
            var (path, logicalSectorSize, _) = DiskReader.GetDiskGeometryInfo(diskPath);
            var setores = new List<byte[]>();

            using var stream = DiskReader.OpenPhysicalDisk(diskPath);
            var buffer = new byte[logicalSectorSize];

            foreach (var indice in indices)
            {
                if (indice < 0) continue;
                long offset = indice * logicalSectorSize;
                stream.Seek(offset, SeekOrigin.Begin);

                int lidos = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (lidos == 0) break; // Fim do disco

                var setor = new byte[lidos];
                Array.Copy(buffer, setor, lidos);
                setores.Add(setor);
            }

            return setores;
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
                if (lidos == 0) break; // Fim do disco
                // Cria uma cópia do buffer para evitar sobrescrita
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
                if (lidos == 0) break; // Fim do disco

                var setor = new byte[lidos];
                Array.Copy(buffer, setor, lidos);
                setores.Add(setor);
            }

            return setores;
        }
    }
}
