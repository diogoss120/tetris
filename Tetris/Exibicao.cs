namespace Tetris
{
    public class Exibicao
    {
        public void ExibirMatriz(int velocidade = 0, int pontos = 0, int nivel = 0)
        {
            Console.Clear();
            if (velocidade > 0)
                Console.WriteLine($"Nível atual: {nivel}, velocidade do jogo em ms: {velocidade},pontos: {pontos}, linhas da Matriz: {Matriz.Posicoes.GetLength(0)}");
            else
                Console.WriteLine("");

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

        private void ExibirCelula(int i, int j)
        {
            // modificar esse método para exibir as cores dependendo do número que estiver na matriz
            int item = Matriz.Posicoes[i, j];
            if (item == 0)
            {
                Console.Write(" ");
                return;
            }

            if (item == 1)
                Console.ForegroundColor = ConsoleColor.Yellow;
            if (item == 2)
                Console.ForegroundColor = ConsoleColor.Blue;
            if (item == 3)
                Console.ForegroundColor = ConsoleColor.Green;
            if (item == 4)
                Console.ForegroundColor = ConsoleColor.Red;
            if (item == 5)
                Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Write("*");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
