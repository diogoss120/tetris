using Tetris.Enuns;

namespace Tetris
{
    public class Movimentacao
    {
        private Tetramino _Tetramino { get; set; }
        private int _QtdLinhasRemovidas { get; set; }
        public StatusJogo StatusJogo { get; private set; }

        public Movimentacao()
        {
            NovoTetramino();
        }

        public void MoverTetraminoParaLados(ConsoleKey comando)
        {
            if (comando != ConsoleKey.LeftArrow && comando != ConsoleKey.RightArrow)
                return;

            if (!ValidaSePodeMoverParaLado(comando))
                return;

            var temp = new List<Tuple<int, int>>();
            foreach (var item in _Tetramino.Posicoes)
            {
                int linha = item.Item1;
                int coluna = item.Item2;

                if (comando == ConsoleKey.LeftArrow)
                    coluna--;
                else if (comando == ConsoleKey.RightArrow)
                    coluna++;

                temp.Add(Tuple.Create(linha, coluna));
            }

            Mover(temp);
        }

        private bool ValidaSePodeMoverParaLado(ConsoleKey key)
        {
            var validacao = new List<Tuple<int, int>>();
            var linhas = _Tetramino.Posicoes.Select(x => x.Item1).AsQueryable().Distinct().ToList();
            foreach (var linha in linhas)
            {
                int colunaDoLado = 0;
                if (key == ConsoleKey.LeftArrow)
                    colunaDoLado = _Tetramino.Posicoes.Where(e => e.Item1 == linha).Min(e => e.Item2);
                else if (key == ConsoleKey.RightArrow)
                    colunaDoLado = _Tetramino.Posicoes.Where(e => e.Item1 == linha).Max(e => e.Item2);
                else
                    throw new Exception("Erro ao validar se pode mover para o lado");

                validacao.Add(Tuple.Create(linha, colunaDoLado));
            }

            bool podeMover = true;
            foreach (var item in validacao)
            {
                if (key == ConsoleKey.RightArrow)
                    podeMover = item.Item2 < Matriz.QtdColunas - 1 && Matriz.Posicoes[item.Item1, item.Item2 + 1] == 0;
                else if (key == ConsoleKey.LeftArrow)
                    podeMover = item.Item2 > 0 && Matriz.Posicoes[item.Item1, item.Item2 - 1] == 0;

                if (!podeMover)
                    break;
            }
            return podeMover;
        }

        public void MoverTetraminoParaBaixo(ConsoleKey comando, int volta)
        {
            if (!ValidaSePodeMoverParaBaixo())
            {
                VerificarSeExistemLinhasCompletas();
                VerificarVitoria();
                VerificarDerrota();
                NovoTetramino();
                return;
            }

            if (volta > 0 && comando != ConsoleKey.DownArrow)
                return;

            var temp = new List<Tuple<int, int>>();
            foreach (var item in _Tetramino.Posicoes)
            {
                int linha = item.Item1 - 1;
                int coluna = item.Item2;
                temp.Add(Tuple.Create(linha, coluna));
            }

            Mover(temp);
        }

        private bool ValidaSePodeMoverParaBaixo()
        {
            var validacao = new List<Tuple<int, int>>();
            var colunas = _Tetramino.Posicoes.Select(x => x.Item2).AsQueryable().Distinct().ToList();
            foreach (var coluna in colunas)
            {
                var linhaMaisBaixa = _Tetramino.Posicoes.Where(e => e.Item2 == coluna).Min(e => e.Item1);
                validacao.Add(Tuple.Create(linhaMaisBaixa, coluna));
            }

            bool podeMover = true;
            foreach (var item in validacao)
            {
                if (item.Item1 == 0 || Matriz.Posicoes[item.Item1 - 1, item.Item2] > 0)
                    podeMover = false;

                if (!podeMover)
                    break;
            }
            return podeMover;
        }

        public void RotacionarTetramino(ConsoleKey comando)
        {
            if (comando != ConsoleKey.UpArrow)
                return;

            EscreverEmPosicao(0);
            _Tetramino.Rotacionar();
            EscreverEmPosicao(_Tetramino.Cor);
        }

        private void VerificarVitoria()
        {
            for (int i = 0; i < Matriz.QtdColunas - 1; i++)
            {
                if (Matriz.Posicoes[0, i] == 0)
                {
                    StatusJogo = StatusJogo.Vitoria;
                    return;
                }
            }
            StatusJogo = StatusJogo.EmAndamento;
        }

        private void VerificarDerrota()
        {
            for (int i = 0; i < Matriz.QtdColunas - 1; i++)
            {
                if (Matriz.Posicoes[Matriz.QtdLinhas - 1, i] != 0)
                {
                    StatusJogo = StatusJogo.Derrota;
                    return;
                }
            }
            StatusJogo = StatusJogo.EmAndamento;
        }

        private void Mover(List<Tuple<int, int>> temp)
        {
            EscreverEmPosicao(0);

            _Tetramino.Posicoes.Clear();
            _Tetramino.Posicoes.AddRange(temp);
            EscreverEmPosicao(_Tetramino.Cor);
        }

        private IEnumerable<int> LinhasCompletas()
        {
            var linhasParaRemover = new List<int>();
            for (int i = 0; i < Matriz.QtdLinhas; i++)
            {
                bool linhaCompleta = true;
                for (int j = 0; j < Matriz.QtdColunas; j++)
                {
                    if (Matriz.Posicoes[i, j] == 0)
                    {
                        linhaCompleta = false;
                        break;
                    }
                }
                if (linhaCompleta)
                {
                    for (int j = 0; j < Matriz.QtdColunas; j++)
                    {
                        // seta o número 10 para ele ser printado na cor branca e o usuário perceber qual linha será removida
                        Matriz.Posicoes[i, j] = 10; 
                    }
                    new Exibicao().ExibirEliminacaoLinha();
                    linhasParaRemover.Add(i);
                }
            }
            return linhasParaRemover;
        }

        private void VerificarSeExistemLinhasCompletas()
        {
            var linhasParaRemover = LinhasCompletas();

            if (!linhasParaRemover.Any())
            {
                _QtdLinhasRemovidas = linhasParaRemover.Count();
                return;
            }

            // cria uma nova matriz e copia para ela os dados da matriz original, ignorando as linhas completas
            int[,] novaMatriz = new int[Matriz.QtdLinhas, Matriz.QtdColunas];
            int destinoIndice = 0;
            for (int i = 0; i < Matriz.QtdLinhas; i++)
            {
                if (!linhasParaRemover.Contains(i))
                {
                    for (int j = 0; j < Matriz.QtdColunas; j++)
                    {
                        novaMatriz[destinoIndice, j] = Matriz.Posicoes[i, j];
                    }
                    destinoIndice++;
                }
            }

            Matriz.Posicoes = novaMatriz;
            _QtdLinhasRemovidas = linhasParaRemover.Count();
        }

        public int ObterQtdLinhasEliminadas()
        {
            var qtd = _QtdLinhasRemovidas;
            _QtdLinhasRemovidas = 0;
            return qtd;
        }

        private void NovoTetramino()
        {
            _Tetramino = new Tetramino();
            EscreverEmPosicao(_Tetramino.Cor);
        }

        private void EscreverEmPosicao(int valor)
        {
            foreach (var item in _Tetramino.Posicoes)
            {
                Matriz.Posicoes[item.Item1, item.Item2] = valor;
            }
        }
    }
}
