namespace Tetris
{
    static class TetraminoEstrutura
    {
        private static Random rd { get; set; }

        static TetraminoEstrutura()
        {
            rd = new Random();
        }

        private static int SorteiaItem(int totalOpcoes)
        {
            return rd.Next(0, totalOpcoes);
        }

        public static Bloco ObterTetramino()
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

        public static Bloco BlocoQuadrado(int linhaBase, int colunaBase, int _ = -1)
        {
            var itens = new List<Tuple<int, int>> {
                   Tuple.Create(linhaBase, colunaBase - 1),
                   Tuple.Create(linhaBase, colunaBase),
                   Tuple.Create(linhaBase - 1, colunaBase - 1),
                   Tuple.Create(linhaBase - 1, colunaBase)
            };

            return new Bloco(itens, 1, "Quadrado", 1, 1);
        }

        public static Bloco BlocoLinha(int linhaBase, int colunaBase, int opcao = -1)
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

            return new Bloco(itens, 2, "Linha", opcao, 2);
        }

        public static Bloco BlocoT(int linhaBase, int colunaBase, int opcao = 0)
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

            return new Bloco(itens, 3, "T", opcao, 4);
        }

        public static Bloco BlocoL(int linhaBase, int colunaBase, int opcao = -1)
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

            return new Bloco(itens, 4, "L", opcao, 4);
        }

        public static Bloco BlocoS(int linhaBase, int colunaBase, int opcao = -1)
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

            return new Bloco(itens, 5, "S", opcao, 2);
        }
    }
}
