namespace Tetris
{
    public class Exibicao
    {
        private void ExibirMatriz()
        {
            for (int i = Matriz.QtdLinhas - 1; i >= 0; i--)
            {
                Console.Write("|"); // inicio da linha
                for (int j = 0; j < Matriz.QtdColunas; j++)
                {
                    ExibirCelula(i, j);
                }
                Console.Write("|\n"); // final da linha
            }
        }

        public void ExibirPlacarMatriz(int velocidade = 0, int pontos = 0, int nivel = 0)
        {
            Console.Clear();
            if (velocidade > 0)
                Console.WriteLine($"Nível atual: {nivel}, velocidade do jogo em ms: {velocidade},pontos: {pontos}");
            else
                Console.WriteLine("");

            ExibirMatriz();
        }

        public void ExibirEliminacaoLinha(int velocidade = 0, int pontos = 0, int nivel = 0)
        {
            Console.Clear();
            Console.WriteLine("");
            ExibirMatriz();
            Task.Delay(400).Wait();
        }

        private void ExibirCelula(int i, int j)
        {
            int item = Matriz.Posicoes[i, j];
            if (item == 0)
            {
                Console.Write(" ");
                return;
            }

            if (item == 1)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else if (item == 2)
                Console.ForegroundColor = ConsoleColor.Blue;
            else if (item == 3)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (item == 4)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (item == 5)
                Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Write("*");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
