using Tetris.Enuns;

namespace Tetris
{
    static class TetraminoBase
    {
        private static Random rd { get; set; }

        static TetraminoBase()
        {
            rd = new Random();
        }

        private static int SorteiaItem(int totalOpcoes)
        {
            return rd.Next(0, totalOpcoes);
        }

        public static Tetramino ObterTetramino()
        {
            int linhaBase = Matriz.QtdLinhas - 1;
            int colunaBase = Matriz.QtdColunas / 2;

            var opcao = SorteiaItem(5);
            if (opcao == 0)
                return BlocoQuadrado(linhaBase, colunaBase);
            else if (opcao == 1)
                return BlocoT(linhaBase, colunaBase);
            else if (opcao == 2)
                return BlocoL(linhaBase, colunaBase);
            else if (opcao == 3)
                return BlocoS(linhaBase, colunaBase);
            else
                return BlocoLinha(linhaBase, colunaBase);
        }

        public static Tetramino BlocoQuadrado(int linhaBase, int colunaBase, int _ = -1)
        {
            var itens = new List<Tuple<int, int>> {
                   Tuple.Create(linhaBase, colunaBase - 1),
                   Tuple.Create(linhaBase, colunaBase),
                   Tuple.Create(linhaBase - 1, colunaBase - 1),
                   Tuple.Create(linhaBase - 1, colunaBase)
            };

            return new Tetramino(itens, 1, TipoTetramino.Quadrado, 1, 1);
        }

        public static Tetramino BlocoLinha(int linhaBase, int colunaBase, int opcao = -1)
        {
            var itens = new List<Tuple<int, int>>();

            if (opcao < 0)
                opcao = SorteiaItem(2);

            if (opcao == 0)
            {
                itens.Add(Tuple.Create(linhaBase, colunaBase - 1));
                itens.Add(Tuple.Create(linhaBase - 1, colunaBase - 1));
                itens.Add(Tuple.Create(linhaBase - 2, colunaBase - 1));
                itens.Add(Tuple.Create(linhaBase - 3, colunaBase - 1));
            }
            else
            {
                itens.Add(Tuple.Create(linhaBase, colunaBase - 1));
                itens.Add(Tuple.Create(linhaBase, colunaBase));
                itens.Add(Tuple.Create(linhaBase, colunaBase + 1));
                itens.Add(Tuple.Create(linhaBase, colunaBase + 2));
            }

            return new Tetramino(itens, 2, TipoTetramino.Linha, opcao, 2);
        }

        public static Tetramino BlocoT(int linhaBase, int colunaBase, int opcao = 0)
        {
            var itens = new List<Tuple<int, int>>();

            if (opcao < 0)
                opcao = SorteiaItem(4);

            if (opcao == 0)
            {
                itens.Add(Tuple.Create(linhaBase, colunaBase));
                itens.Add(Tuple.Create(linhaBase - 1, colunaBase - 1));
                itens.Add(Tuple.Create(linhaBase - 1, colunaBase));
                itens.Add(Tuple.Create(linhaBase - 1, colunaBase + 1));
            }
            else if (opcao == 1)
            {
                itens.Add(Tuple.Create(linhaBase, colunaBase + 1));
                itens.Add(Tuple.Create(linhaBase - 1, colunaBase + 1));
                itens.Add(Tuple.Create(linhaBase - 2, colunaBase + 1));
                itens.Add(Tuple.Create(linhaBase - 1, colunaBase));
            }
            else if (opcao == 2)
            {
                itens.Add(Tuple.Create(linhaBase, colunaBase - 1));
                itens.Add(Tuple.Create(linhaBase, colunaBase));
                itens.Add(Tuple.Create(linhaBase, colunaBase + 1));
                itens.Add(Tuple.Create(linhaBase - 1, colunaBase));
            }
            else
            {
                itens.Add(Tuple.Create(linhaBase, colunaBase - 1));
                itens.Add(Tuple.Create(linhaBase - 1, colunaBase - 1));
                itens.Add(Tuple.Create(linhaBase - 2, colunaBase - 1));
                itens.Add(Tuple.Create(linhaBase - 1, colunaBase));
            }

            return new Tetramino(itens, 3, TipoTetramino.T, opcao, 4);
        }

        public static Tetramino BlocoL(int linhaBase, int colunaBase, int opcao = -1)
        {
            var itens = new List<Tuple<int, int>>();

            if (opcao < 0)
                opcao = SorteiaItem(4);

            if (opcao == 0)
            {
                itens.Add(Tuple.Create(linhaBase, colunaBase));
                itens.Add(Tuple.Create(linhaBase, colunaBase + 1));
                itens.Add(Tuple.Create(linhaBase, colunaBase + 2));
                itens.Add(Tuple.Create(linhaBase - 1, colunaBase));
            }
            else if (opcao == 1)
            {
                itens.Add(Tuple.Create(linhaBase, colunaBase));
                itens.Add(Tuple.Create(linhaBase - 1, colunaBase));
                itens.Add(Tuple.Create(linhaBase - 2, colunaBase));
                itens.Add(Tuple.Create(linhaBase - 2, colunaBase + 1));
            }
            else if (opcao == 2)
            {
                itens.Add(Tuple.Create(linhaBase, colunaBase + 2));
                itens.Add(Tuple.Create(linhaBase - 1, colunaBase));
                itens.Add(Tuple.Create(linhaBase - 1, colunaBase + 1));
                itens.Add(Tuple.Create(linhaBase - 1, colunaBase + 2));
            }
            else
            {
                colunaBase = colunaBase - 2;
                itens.Add(Tuple.Create(linhaBase, colunaBase));
                itens.Add(Tuple.Create(linhaBase, colunaBase + 1));
                itens.Add(Tuple.Create(linhaBase - 1, colunaBase + 1));
                itens.Add(Tuple.Create(linhaBase - 2, colunaBase + 1));
            }

            return new Tetramino(itens, 4, TipoTetramino.L, opcao, 4);
        }

        public static Tetramino BlocoS(int linhaBase, int colunaBase, int opcao = -1)
        {
            var itens = new List<Tuple<int, int>>();

            if (opcao < 0)
                opcao = SorteiaItem(2);

            if (opcao == 0)
            {
                itens.Add(Tuple.Create(linhaBase, colunaBase - 1));
                itens.Add(Tuple.Create(linhaBase, colunaBase));
                itens.Add(Tuple.Create(linhaBase - 1, colunaBase));
                itens.Add(Tuple.Create(linhaBase - 1, colunaBase + 1));
            }
            else
            {
                itens.Add(Tuple.Create(linhaBase, colunaBase + 1));
                itens.Add(Tuple.Create(linhaBase - 1, colunaBase + 1));
                itens.Add(Tuple.Create(linhaBase - 1, colunaBase));
                itens.Add(Tuple.Create(linhaBase - 2, colunaBase));
            }

            return new Tetramino(itens, 5, TipoTetramino.S, opcao, 2);
        }
    }
}
