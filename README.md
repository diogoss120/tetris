# 🎮 Tetris Console Game em C# - O Clássico Tetris em C# .NET 9

[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
[![.NET Version](https://img.shields.io/badge/.NET-9.0-purple.svg)](https://dotnet.microsoft.com/download/dotnet/9.0)

## 🚀 Sobre o Projeto

Este projeto é uma implementação do clássico e viciante jogo Tetris, desenvolvido como um aplicativo de console em C# utilizando o framework .NET 9. O objetivo é proporcionar uma experiência fiel ao jogo original, com uma interface gráfica simples, mecânicas de jogo intuitivas e um sistema de pontuação e níveis progressivo.

O principal objetivo deste projeto foi servir como um exercício prático para aprimorar a **lógica de programação** e o trabalho com **matrizes (arrays) de tamanho fixo**.

A intenção não foi criar grandes arquiteturas de software ou utilizar padrões complexos, mas sim exercitar o raciocínio lógico fundamental para implementar a mecânica do jogo, como a movimentação, rotação e colisão das peças, além da detecção e limpeza de linhas completas no tabuleiro.

## ✨ Funcionalidades Principais (Baseado nos Requisitos de Desenvolvimento)

Desenvolvido com base em um conjunto claro de requisitos para garantir uma experiência de jogo completa e envolvente:

*   **Tabuleiro Dinâmico:** Um grid central onde todas as peças caem e se encaixam, reproduzindo a área de jogo clássica do Tetris.
*   **Geração Aleatória de Peças:** As peças (tetrominós) são geradas de forma randômica no topo do tabuleiro, garantindo imprevisibilidade e rejogabilidade a cada partida.
*   **Controles Intuitivos:** O jogador tem controle total sobre as peças em queda, permitindo:
    *   Mover para a esquerda e direita.
    *   Girar a peça (rotação).
    *   Acelerar a queda (soft drop).
*   **Mecânica de Encaixe Perfeito:** As peças se encaixam de forma precisa no tabuleiro, sem deixar espaços vazios, replicando a física do jogo original.
*   **Eliminação de Linhas e Pontuação:**
    *   Quando uma linha completa é formada por peças, ela é eliminada automaticamente.
    *   A eliminação de linhas concede pontos ao jogador, incentivando a estratégia e combos.
*   **Condição de Fim de Jogo (Game Over):** A partida termina quando as peças empilhadas atingem o topo do tabuleiro, desafiando o jogador a gerenciar o espaço.
*   **Sistema de Pontuação Progressivo:**
    *   A pontuação aumenta dinamicamente conforme o jogador elimina mais linhas e realiza ações estratégicas.
    *   Este sistema de pontuação é o coração da competição e do desafio.
*   **Sistema de Níveis e Dificuldade:**
    *   O jogo possui um sistema de níveis que aumenta à medida que o jogador atinge determinados marcos (e.g., eliminando mais linhas).
    *   Cada novo nível acelera a queda das peças, aumentando a dificuldade e mantendo o desafio.
*   **Interface Gráfica Simples e Informativa (Console UI):**
    *   Uma interface baseada em caracteres que mostra claramente o tabuleiro de jogo.
    *   Exibe a peça atual em queda, a pontuação do jogador e o nível atual, mantendo o jogador sempre informado.
    *   **Peças Coloridas:** As peças são exibidas com cores distintas para facilitar a visualização e melhorar a experiência de jogo.
*   **Sistema de High Scores Persistente:**
    *   Ao finalizar o jogo, o placar final do jogador é salvo de forma persistente.
    *   É possível visualizar um histórico das pontuações anteriores, permitindo que o usuário acompanhe seu progresso e se desafie a bater seus próprios recordes ao longo do tempo.

## 🕹️ Como Jogar

(Aqui você manteria as instruções básicas de como rodar e quais teclas usar. Exemplo:)

1.  **Mover Esquerda:** `←` (Seta para a esquerda)
2.  **Mover Direita:** `→` (Seta para a direita)
3.  **Girar Peça:** `↑` (Seta para cima)
4.  **Queda Acelerada:** `↓` (Seta para baixo)
5.  **Sair do Jogo:** `Esc`

## 🛠️ Tecnologias Utilizadas

*   **C#:** Linguagem de programação principal.
*   **.NET 9:** Framework para o desenvolvimento do aplicativo de console (migrado de .NET 7).
*   **Console Application:** Tipo de projeto para execução via terminal.

## ⚙️ Configuração e Execução

### Pré-requisitos

*   SDK do .NET 9.0 (ou superior) instalado. Você pode baixá-lo em [dotnet.microsoft.com/download](https://dotnet.microsoft.com/download/dotnet/9.0).
*   Um editor de código como Visual Studio 2022 (última versão preview recomendada), Visual Studio Code ou JetBrains Rider.

### Instalação

1.  Clone este repositório:
    ```bash
    git clone https://github.com/SEU_USUARIO/SEU_REPOSITORIO.git
    cd SEU_REPOSITORIO
    ```
2.  Restaure as dependências (se necessário):
    ```bash
    dotnet restore
    ```
3.  Compile o projeto:
    ```bash
    dotnet build
    ```

### Execução

Para iniciar o jogo, execute o seguinte comando na pasta raiz do projeto:

```bash
dotnet run
