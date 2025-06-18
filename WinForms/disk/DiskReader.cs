using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace WinForms.cores
{
    internal class DiskReader
    {
        // --- Constantes para CreateFile ---
        // Acesso de leitura ao dispositivo
        private const uint GENERIC_READ = 0x80000000;
        // Sem acesso de escrita (leitura segura)
        private const uint GENERIC_WRITE = 0x40000000;

        // Compartilhamento, permite leitura, escrita e exclusão de outros processos
        private const uint FILE_SHARE_READ = 0x00000001;
        private const uint FILE_SHARE_WRITE = 0x00000002;
        private const uint FILE_SHARE_DELETE = 0x00000004;

        // Indica que o arquivo/dispositivo deve ser aberto apenas se já existir
        public const uint OPEN_EXISTING = 3;

        // Código de controle usado para consultar propriedades do armazenamento (ex: setores do disco)
        public const uint IOCTL_STORAGE_QUERY_PROPERTY = 0x002D1400;

        // link: https://www.disk-editor.org/index.html
        // criar um botão parar de executar o processo.
        // descobrir bug de print para setores sequenciais

        // função da api do windows abrir/cria um arquivo virtual com o endereço do disco físico, e faz leitura da bits do disco físico
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern SafeFileHandle CreateFile(
            string lpFileName,
            uint dwDesiredAccess,
            uint dwShareMode,
            nint lpSecurityAttributes,
            uint dwCreationDisposition,
            uint dwFlagsAndAttributes,
            nint hTemplateFile);

        // O método DeviceIoControl é uma função da API do Windows usada
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool DeviceIoControl(
            SafeFileHandle hDevice,
            uint dwIoControlCode,
            nint lpInBuffer,
            int nInBufferSize,
            nint lpOutBuffer,
            int nOutBufferSize,
            out int lpBytesReturned,
            nint lpOverlapped);
        
        // Faz leitura de um endereço fisico do disco. 
        public static FileStream OpenPhysicalDisk(string path)
        {
            var handle = CreateFile(
                path,
                GENERIC_READ,
                FILE_SHARE_READ | FILE_SHARE_WRITE,
                nint.Zero,
                OPEN_EXISTING,
                0,
                nint.Zero);

            if (handle.IsInvalid)
                throw new IOException("Falha ao abrir o dispositivo físico.", Marshal.GetLastWin32Error());

            return new FileStream(handle, FileAccess.Read);
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetDiskFreeSpaceExW(
          string lpDirectoryName,
          out ulong lpFreeBytesAvailable,
          out ulong lpTotalNumberOfBytes,
          out ulong lpTotalNumberOfFreeBytes);

        /// Obtém informações de geometria do disco físico especificado.
        /// Utiliza chamadas de baixo nível da API do Windows para consultar o tamanho dos setores lógicos e físicos do disco.
        public static (string Path, uint LogicalSectorSize, uint PhysicalSectorSize) GetDiskGeometryInfo(string path)
        {
            SafeFileHandle handle = CreateFile(
                path,
                GENERIC_READ,
                FILE_SHARE_READ | FILE_SHARE_WRITE,
                nint.Zero,
                OPEN_EXISTING,
                0,
                nint.Zero);

            if (handle.IsInvalid)
                throw new IOException("Falha ao abrir o dispositivo físico.", Marshal.GetLastWin32Error());

            STORAGE_PROPERTY_QUERY query = new()
            {
                PropertyId = STORAGE_PROPERTY_ID.StorageAccessAlignmentProperty,
                QueryType = STORAGE_QUERY_TYPE.PropertyStandardQuery
            };

            int querySize = Marshal.SizeOf(query);
            nint queryPtr = Marshal.AllocHGlobal(querySize);
            Marshal.StructureToPtr(query, queryPtr, false);

            int outSize = Marshal.SizeOf<STORAGE_ACCESS_ALIGNMENT_DESCRIPTOR>();
            nint outBuffer = Marshal.AllocHGlobal(outSize);

            bool result = DeviceIoControl(
                handle,
                IOCTL_STORAGE_QUERY_PROPERTY,
                queryPtr,
                querySize,
                outBuffer,
                outSize,
                out int bytesReturned,
                nint.Zero);

            if (!result)
                throw new IOException("Falha ao obter informações de alinhamento do disco.", Marshal.GetLastWin32Error());

            STORAGE_ACCESS_ALIGNMENT_DESCRIPTOR descriptor = Marshal.PtrToStructure<STORAGE_ACCESS_ALIGNMENT_DESCRIPTOR>(outBuffer);

            Marshal.FreeHGlobal(queryPtr);
            Marshal.FreeHGlobal(outBuffer);

            return (path, descriptor.LogicalBytesPerSector, descriptor.PhysicalBytesPerSector);
        }

        // Estruturas auxiliares para DeviceIoControl
        private enum STORAGE_PROPERTY_ID : int
        {
            StorageDeviceProperty = 0,
            StorageAccessAlignmentProperty = 6
        }

        private enum STORAGE_QUERY_TYPE : int
        {
            PropertyStandardQuery = 0
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct STORAGE_PROPERTY_QUERY
        {
            public STORAGE_PROPERTY_ID PropertyId;
            public STORAGE_QUERY_TYPE QueryType;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] AdditionalParameters;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct STORAGE_ACCESS_ALIGNMENT_DESCRIPTOR
        {
            public uint Version;
            public uint Size;
            public uint BytesPerCacheLine;
            public uint BytesOffsetForCacheAlignment;
            public uint LogicalBytesPerSector;
            public uint PhysicalBytesPerSector;
            public uint BytesOffsetForSectorAlignment;
        }
    }
}
