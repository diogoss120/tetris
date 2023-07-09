namespace Tetris
{
    static class TetraminoBase
    {
        public static List<Tuple<int, int>> BlocoQuadrado(int linhaBase, int colunaBase, int _ = -1)
        {
            return new List<Tuple<int, int>> {
                   Tuple.Create(linhaBase, colunaBase - 1),
                   Tuple.Create(linhaBase, colunaBase),
                   Tuple.Create(linhaBase - 1, colunaBase - 1),
                   Tuple.Create(linhaBase - 1, colunaBase)
            };
        }

        public static List<Tuple<int, int>> BlocoLinha(int linhaBase, int colunaBase, int opcao = -1)
        {
            var itens = new List<Tuple<int, int>>();

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

            return itens;
        }

        public static List<Tuple<int, int>> BlocoT(int linhaBase, int colunaBase, int opcao = 0)
        {
            var itens = new List<Tuple<int, int>>();

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

            return itens;
        }

        public static List<Tuple<int, int>> BlocoL(int linhaBase, int colunaBase, int opcao = -1)
        {
            var itens = new List<Tuple<int, int>>();

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

            return itens;
        }

        public static List<Tuple<int, int>> BlocoS(int linhaBase, int colunaBase, int opcao = -1)
        {
            var itens = new List<Tuple<int, int>>();

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

            return itens;
        }
    }
}
