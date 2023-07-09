using Tetris.Enuns;

namespace Tetris
{
    public class Tetramino
    {
        public List<Tuple<int, int>> Posicoes { get; set; }
        public int Cor { get; private set; }
        private TipoTetramino TipoTetramino { get; set; }
        private int VersaoAtual { get; set; }
        private int MaximoVersoes { get; set; }

        public Tetramino(List<Tuple<int, int>> posicoes, int cor, TipoTetramino tipoDeBloco, int versao, int maximoOpcoes)
        {
            Posicoes = posicoes;
            Cor = cor;
            TipoTetramino = tipoDeBloco;
            VersaoAtual = versao;
            MaximoVersoes = maximoOpcoes;
        }

        public Tetramino()
        {
            Posicoes = new();
            ObterTetramino();
        }

        private int SorteiaItem(int totalOpcoes)
        {
            return new Random().Next(0, totalOpcoes);
        }

        public void ObterTetramino()
        {
            int linhaBase = Matriz.QtdLinhas - 1;
            int colunaBase = Matriz.QtdColunas / 2;

            var opcao = SorteiaItem(5);
            if (opcao == 0)
                BlocoQuadrado(linhaBase, colunaBase);
            else if (opcao == 1)
                BlocoT(linhaBase, colunaBase);
            else if (opcao == 2)
                BlocoL(linhaBase, colunaBase);
            else if (opcao == 3)
                BlocoS(linhaBase, colunaBase);
            else
                BlocoLinha(linhaBase, colunaBase);
        }

        private void BlocoQuadrado(int linhaBase, int colunaBase)
        {
            MaximoVersoes = 1;
            VersaoAtual = SorteiaItem(MaximoVersoes);
            Posicoes = TetraminoBase.BlocoQuadrado(linhaBase, colunaBase, VersaoAtual);
            Cor = 1;
            TipoTetramino = TipoTetramino.Quadrado;
        }

        private void BlocoLinha(int linhaBase, int colunaBase)
        {
            MaximoVersoes = 2;
            VersaoAtual = SorteiaItem(MaximoVersoes);
            Posicoes = TetraminoBase.BlocoLinha(linhaBase, colunaBase, VersaoAtual);
            Cor = 2;
            TipoTetramino = TipoTetramino.Linha;
        }

        private void BlocoT(int linhaBase, int colunaBase)
        {
            MaximoVersoes = 4;
            VersaoAtual = SorteiaItem(MaximoVersoes);
            Posicoes = TetraminoBase.BlocoT(linhaBase, colunaBase, VersaoAtual);
            Cor = 3;
            TipoTetramino = TipoTetramino.T;
        }

        private void BlocoL(int linhaBase, int colunaBase)
        {
            MaximoVersoes = 4;
            VersaoAtual = SorteiaItem(MaximoVersoes);
            Posicoes = TetraminoBase.BlocoL(linhaBase, colunaBase, VersaoAtual);
            Cor = 4;
            TipoTetramino = TipoTetramino.L;
        }

        private void BlocoS(int linhaBase, int colunaBase)
        {
            MaximoVersoes = 2;
            VersaoAtual = SorteiaItem(MaximoVersoes);
            Posicoes = TetraminoBase.BlocoS(linhaBase, colunaBase, VersaoAtual);
            Cor = 5;
            TipoTetramino = TipoTetramino.S;
        }

        public void Rotacionar()
        {
            VersaoAtual++;
            if (VersaoAtual >= MaximoVersoes)
                VersaoAtual = 0;

            int coluna = Posicoes[0].Item2;

            if (TipoTetramino == TipoTetramino.Linha)
            {
                coluna += 1;
            }
            else if (TipoTetramino == TipoTetramino.T)
            {
                if (VersaoAtual == 1) coluna -= 1;
                if (VersaoAtual == 3) coluna += 2;
            }

            if (coluna == Matriz.QtdColunas)
                coluna = Matriz.QtdColunas - 1;

            List<Tuple<int, int>> temp;
            if (TipoTetramino == TipoTetramino.L)
                temp = TetraminoBase.BlocoL(Posicoes[0].Item1, coluna, VersaoAtual);
            else if (TipoTetramino == TipoTetramino.S)
                temp = TetraminoBase.BlocoS(Posicoes[0].Item1, coluna, VersaoAtual);
            else if (TipoTetramino == TipoTetramino.T)
                temp = TetraminoBase.BlocoT(Posicoes[0].Item1, coluna, VersaoAtual);
            else if (TipoTetramino == TipoTetramino.Quadrado)
                temp = TetraminoBase.BlocoQuadrado(Posicoes[0].Item1, coluna, VersaoAtual);
            else // bloco linha
                temp = TetraminoBase.BlocoLinha(Posicoes[0].Item1, coluna, VersaoAtual);

            temp = ValidarPosicaoEstremidades(temp);

            if (PodeGirar(temp))
                Posicoes = temp;
        }

        private bool PodeGirar(List<Tuple<int, int>> tetraminoRotacionado)
        {
            var podeGirar = true;

            // valida se na matriz, mas novas posições já estão preenchidas com algo
            foreach (var item in tetraminoRotacionado)
            {
                if (Matriz.Posicoes[item.Item1, item.Item2] > 0)
                    podeGirar = false;
            }
            return podeGirar;
        }

        public List<Tuple<int, int>> ValidarPosicaoEstremidades(List<Tuple<int, int>> tetraminoRotacionado)
        {
            var linhas = tetraminoRotacionado.Select(x => x.Item1).AsQueryable().Distinct().ToList();
            int qtdColunasParaMovimentar = 0;
            bool problemaLadoEsquerdo = false, problemaLadoDireito = false;
            foreach (var linha in linhas)
            {
                int colunaDaEsquerda = tetraminoRotacionado.Where(e => e.Item1 == linha).Min(e => e.Item2);
                int colunaDaDireita = tetraminoRotacionado.Where(e => e.Item1 == linha).Max(e => e.Item2);

                if (colunaDaEsquerda < 0)
                {
                    problemaLadoEsquerdo = true;
                    if (qtdColunasParaMovimentar > colunaDaEsquerda - 0)
                        qtdColunasParaMovimentar = colunaDaEsquerda - 0;
                }

                if (colunaDaDireita >= Matriz.QtdColunas)
                {
                    problemaLadoDireito = true;
                    if (qtdColunasParaMovimentar < colunaDaDireita - (Matriz.QtdColunas - 1))
                        qtdColunasParaMovimentar = colunaDaDireita - (Matriz.QtdColunas - 1);
                }
            }

            if (problemaLadoEsquerdo || problemaLadoDireito)
                return Reposicionar(Math.Abs(qtdColunasParaMovimentar), problemaLadoEsquerdo, problemaLadoDireito, tetraminoRotacionado);

            return tetraminoRotacionado;
        }

        private List<Tuple<int, int>> Reposicionar(int qtdColunasParaMovimentar, bool problemaLadoEsquerdo, bool problemaLadoDireito, List<Tuple<int, int>> tetraminoRotacionado)
        {
            var temp = new List<Tuple<int, int>>();
            foreach (var item in tetraminoRotacionado)
            {
                if (problemaLadoEsquerdo)
                    temp.Add(Tuple.Create(item.Item1, item.Item2 + qtdColunasParaMovimentar));
                else if (problemaLadoDireito)
                    temp.Add(Tuple.Create(item.Item1, item.Item2 - qtdColunasParaMovimentar));
                else
                    throw new Exception("Problema para reposicionar tetramino, possivelmente iria estourar a matriz");
            }
            return temp;
        }
    }
}
