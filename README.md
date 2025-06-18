# Leitor de Setores de Disco

## Intuito do Projeto

Este projeto é uma aplicação Windows Forms desenvolvida em C# (.NET 8) que permite a leitura de informações e setores de discos físicos conectados ao computador.
O objetivo principal é fornecer uma interface gráfica para visualizar dados brutos dos setores do disco, tanto de forma paginada quanto aleatória.

## Funcionalidades

- Leitura das informações de geometria do disco (tamanho dos setores lógicos e físicos).
- Leitura de setores do disco de forma paginada ou aleatória.
- Exibição dos dados dos setores em formato hexadecimal e ASCII.

## Dependências Necessárias

Para executar este projeto, é necessário ter instalado:

- **.NET 8 SDK**  
  Baixe em: https://dotnet.microsoft.com/download/dotnet/8.0

- **Windows**  
  O projeto utiliza Windows Forms, disponível apenas para sistemas operacionais Windows.

- **Permissões de Administrador**  
  Para acessar informações de baixo nível dos discos, é necessário executar o aplicativo com permissões elevadas (Administrador).

## Observações

- O acesso direto ao disco pode ser restrito por políticas de segurança do sistema operacional.
- Utilize com cautela, pois a leitura de setores pode impactar o desempenho do disco.
- Total de maquinas Destruidas 2
