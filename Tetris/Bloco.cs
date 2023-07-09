using System.Collections.Generic;

namespace Tetris
{
    public class Bloco
    {
        public List<Tuple<int, int>> Posicoes { get; set; }
        public int Cor { get; private set; }
        public string TipoBloco { get; private set; }
        public int Versao { get; private set; }
        private int MaximoOpcoes { get; set; }

        public Bloco(List<Tuple<int, int>> posicoes, int cor, string tipoDeBloco, int versao, int maximoOpcoes)
        {
            Posicoes = posicoes;
            Cor = cor;
            TipoBloco = tipoDeBloco;
            Versao = versao;
            MaximoOpcoes = maximoOpcoes;
        }

        public Bloco()
        {
        }

        public void Rotacionar()
        {
            Versao++;
            if (Versao >= MaximoOpcoes)
                Versao = 0;

            int coluna = Posicoes[0].Item2;

            if (TipoBloco == "Linha")
            {
                coluna += 1;
            }
            else if (TipoBloco == "T")
            {
                if (Versao == 1) coluna -= 1;
                if (Versao == 3) coluna += 2;
            }

            if (coluna == 10)
                coluna = 9;

            List<Tuple<int, int>> temp;
            if (TipoBloco == "L")
                temp = TetraminoEstrutura.BlocoL(Posicoes[0].Item1, coluna, Versao).Posicoes;
            else if (TipoBloco == "S")
                temp = TetraminoEstrutura.BlocoS(Posicoes[0].Item1, coluna, Versao).Posicoes;
            else if (TipoBloco == "T")
                temp = TetraminoEstrutura.BlocoT(Posicoes[0].Item1, coluna, Versao).Posicoes;
            else if (TipoBloco == "Quadrado")
                temp = TetraminoEstrutura.BlocoQuadrado(Posicoes[0].Item1, coluna, Versao).Posicoes;
            else // bloco linha
                temp = TetraminoEstrutura.BlocoLinha(Posicoes[0].Item1, coluna, Versao).Posicoes;

            
            // validações

            temp = ValidarPosicaoEstremidades(temp);

            if (PodeGirar(temp))
                Posicoes = temp;
        }

        private bool PodeGirar(List<Tuple<int, int>> tetraminoRotacionado)
        {
            var podeGirar = true;

            // valida se na matriz, mas novas posições já estão preenchidas com algo
            foreach(var item in tetraminoRotacionado)
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
                    if(qtdColunasParaMovimentar > colunaDaEsquerda - 0)
                        qtdColunasParaMovimentar = colunaDaEsquerda - 0;
                }

                if (colunaDaDireita >= Matriz.QtdColunas)
                {
                    problemaLadoDireito = true;
                    if(qtdColunasParaMovimentar < colunaDaDireita - (Matriz.QtdColunas - 1))
                        qtdColunasParaMovimentar = colunaDaDireita - (Matriz.QtdColunas - 1);
                }
            }

            if (problemaLadoEsquerdo || problemaLadoDireito)
                return Reposicionar(Math.Abs(qtdColunasParaMovimentar), problemaLadoEsquerdo, problemaLadoDireito, tetraminoRotacionado);

            return tetraminoRotacionado;
        }

        private List<Tuple<int, int>> Reposicionar(int qtdColunasParaMovimentar, bool problemaLadoEsquerdo, bool problemaLadoDireito, List<Tuple<int, int>> tetraminoRotacionado)
        {
            var temp = new List<Tuple<int, int>> ();
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
