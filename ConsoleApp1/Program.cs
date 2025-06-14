﻿using Core;

// WARNING: Este codigo é para uso educacioanl. Acesso fisico ao disk pode gerar perda de dados ou corrupção.
// Contagem de maquinas Lascadas: 2. disco fisico do boot: \\.\PhysicalDrive0
// Estamos a {1} sem acidentes com maquinas.

//var drive = @"\\.\F:";

var drive = new DriveInfo("F");

Console.WriteLine($"Disco: {drive.RootDirectory}");
var algo = "\\\\.\\" + drive.Name + ":";

var info = DiskReader.GetDiskGeometryInfo(algo);
Console.WriteLine($"Disco: {info.Path}");
Console.WriteLine($"Setor Lógico (mínimo): {info.LogicalSectorSize} bytes");
Console.WriteLine($"Setor Físico (máximo): {info.PhysicalSectorSize} bytes");

//DiskReader.GetDiskFreeSpaceExW(@"\\.\F:", out ulong freeBytesAvailable, out ulong totalBytes, out ulong totalFreeBytes);

Console.WriteLine($"Drive: {@"\\.\F:"}");


Console.WriteLine($"Total bytes: {drive.TotalSize}");
//Console.WriteLine($"Total size: {totalBytes / (1024 * 1024 * 1024)} GB");
//Console.WriteLine($"Free space: {totalFreeBytes / (1024 * 1024 * 1024)} GB");
//Console.WriteLine($"Free space available to current user: {freeBytesAvailable / (1024 * 1024 * 1024)} GB");

//var diskService = new DiskService();

// limite USB 1: 12 MB

//for (int i = 0; i < 1000; i++)
//{
//    var setores = await diskService.GetSetoresPaginadosAsync(@"\\.\E:", i, 100000);
//    Console.WriteLine($"Página {i}: {setores.Count} setores lidos.");
//    if (setores.Count == 0)
//        break;
//    Console.WriteLine($"Primeiro setor: {BitConverter.ToString(setores[0])}");
//    Console.WriteLine($"Último setor: {BitConverter.ToString(setores[^1])}");
//}

//Console.WriteLine("FIM DO PROCESSO");


//var info2 = DiskReader.GetDiskGeometryInfo(@"\\.\D:");
//Console.WriteLine($"Disco 1: {info2.Path}");
