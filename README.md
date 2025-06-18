# Leitor de Setores de Disco

## Intuito do Projeto

Este projeto � uma aplica��o Windows Forms desenvolvida em C# (.NET 8) que permite a leitura de informa��es e setores de discos f�sicos conectados ao computador.
O objetivo principal � fornecer uma interface gr�fica para visualizar dados brutos dos setores do disco, tanto de forma paginada quanto aleat�ria.

## Funcionalidades

- Leitura das informa��es de geometria do disco (tamanho dos setores l�gicos e f�sicos).
- Leitura de setores do disco de forma paginada ou aleat�ria.
- Exibi��o dos dados dos setores em formato hexadecimal e ASCII.

## Depend�ncias Necess�rias

Para executar este projeto, � necess�rio ter instalado:

- **.NET 8 SDK**  
  Baixe em: https://dotnet.microsoft.com/download/dotnet/8.0

- **Windows**  
  O projeto utiliza Windows Forms, dispon�vel apenas para sistemas operacionais Windows.

- **Permiss�es de Administrador**  
  Para acessar informa��es de baixo n�vel dos discos, � necess�rio executar o aplicativo com permiss�es elevadas (Administrador).

## Observa��es

- O acesso direto ao disco pode ser restrito por pol�ticas de seguran�a do sistema operacional.
- Utilize com cautela, pois a leitura de setores pode impactar o desempenho do disco.
