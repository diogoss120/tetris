
namespace Tetris
{
    public static class Matriz
    {
        public static int QtdLinhas { get; private set; }
        public static int QtdColunas { get; private set; }
        public static int[,] Posicoes { get; set; }

        static Matriz()
        {
            QtdLinhas = 20;
            QtdColunas = 10;
            Posicoes = new int[QtdLinhas, QtdColunas];
        }
    }
}
