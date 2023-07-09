using System.Runtime.InteropServices;
using Tetris.Enuns;

namespace Tetris
{
    public class Game
    {
        private Exibicao Exibicao { get; set; }
        private Movimentacao Movimentacao { get; set; }
        private int TempoDescerPeca { get; set; }
        private int QuebrasNoTempo { get; set; }
        private int Pontos { get; set; }
        private int Nivel { get; set; }
        private string ArquivoHistorico { get; set; }

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int vKey);

        public Game()
        {
            TempoDescerPeca = 600;
            Movimentacao = new Movimentacao();
            Exibicao = new Exibicao();
            QuebrasNoTempo = 8;
            Pontos = 0;
            Nivel = 1;
            ArquivoHistorico = Directory.GetCurrentDirectory() + "\\historico.txt";
        }

        public void MenuInicial()
        {
            Console.WriteLine("O jogo consiste em empilhar tetraminós que descem a tela de forma que completem linhas horizontais.");
            Console.WriteLine("Quando uma linha se forma, ela se desintegra, as camadas superiores descem, e o jogador ganha 1 ponto por linha.");
            Console.WriteLine("Quando a pilha de peças chega ao topo da tela, a partida se encerra.");
            Console.WriteLine("Ao completar 5 pontos o jogador passa para a próxima faze e a velocidade do jogo aumenta em 10%.");
            Console.WriteLine("\nUtilize as setas do teclado para mover para os lados, acelerar e girar o tetramino!");

            int op = 0;
            while (op != 1)
            {
                Console.WriteLine("\n1 - Iniciar jogo \n2 - Ver recordes atingidos");
                Console.Write("Informe a opção desejada: ");
                op = int.Parse(Console.ReadLine() ?? "1");
                if (op == 1)
                {
                    Exibicao.ExibirPlacarMatriz();
                    Run();
                }
                else
                {
                    var historico = new List<Dictionary<string, string>>();
                    File.ReadAllLines(ArquivoHistorico).ToList().ForEach(
                        x =>
                        {
                            var conteudo = x.Split('|');
                            var dict = new Dictionary<string, string>
                            {
                                { "data", conteudo[0] },
                                { "nivel", conteudo[1] },
                                { "pontos", conteudo[2] },
                                { "resultado", conteudo[3] }
                            };
                            historico.Add(dict);
                        }
                    );
                    historico = historico.OrderByDescending(i => i["nivel"]).ToList();
                    foreach (var item in historico)
                    {
                        Console.WriteLine($"{item["data"]} - Nível: {item["nivel"]} - Pontos: {item["pontos"]} - Resultado: {item["resultado"]}");
                    }
                }
            }
        }

        private void Run()
        {
            var statusJogo = StatusJogo.EmAndamento;
            Task.Delay(1000).Wait();

            while (statusJogo == StatusJogo.EmAndamento)
            {
                for (int volta = 0; volta < QuebrasNoTempo; volta++)
                {
                    var comando = ObterComando();

                    if (comando == ConsoleKey.Escape)
                    {
                        statusJogo = StatusJogo.Derrota;
                        break;
                    };

                    Movimentacao.RotacionarTetramino(comando);

                    Movimentacao.MoverTetraminoParaBaixo(comando, volta);
                    if (Movimentacao.StatusJogo != StatusJogo.EmAndamento)
                    {
                        statusJogo = Movimentacao.StatusJogo;
                        break;
                    }

                    Movimentacao.MoverTetraminoParaLados(comando);

                    Exibicao.ExibirPlacarMatriz(TempoDescerPeca, Pontos, Nivel);

                    VerificarPontuacao(Movimentacao.ObterQtdLinhasEliminadas());

                    Task.Delay(TempoDescerPeca / QuebrasNoTempo).Wait();
                }
            }

            if (statusJogo == StatusJogo.Vitoria) Console.WriteLine("\nPARABÊNS, VOCÊ GANHOU O JOGO");
            else Console.WriteLine("\nVOCÊ PERDEU");

            File.AppendAllText(ArquivoHistorico, $"\n{DateTime.Now}|{Nivel}|{Pontos}|" + (statusJogo == StatusJogo.Vitoria ? "Vitória" : "Derrota"));
        }

        private ConsoleKey ObterComando()
        {
            if (GetAsyncKeyState(37) != 0)
                return ConsoleKey.LeftArrow;
            else if (GetAsyncKeyState(39) != 0)
                return ConsoleKey.RightArrow;
            else if (GetAsyncKeyState(40) != 0)
                return ConsoleKey.DownArrow;
            else if (GetAsyncKeyState(38) != 0)
                return ConsoleKey.UpArrow;
            else if (GetAsyncKeyState(27) != 0)
                return ConsoleKey.Escape;

            return ConsoleKey.Spacebar;
        }

        private void VerificarPontuacao(int qtdLinhasRemovidas)
        {
            if (qtdLinhasRemovidas == 0) return;

            if (qtdLinhasRemovidas > 0)
            {
                Pontos += qtdLinhasRemovidas;
            }

            if (Pontos >= 5)
            {
                Pontos -= 5;
                Nivel += 1;
                TempoDescerPeca = Convert.ToInt32(TempoDescerPeca * 0.90);
            }
        }
    }
}
