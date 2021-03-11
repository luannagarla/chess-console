using System;
//using gameBoard;

namespace gameBoard
{
    class Position
    {
        public int linha { get; set; }
        public int coluna { get; set; }

        public Position(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
        }

        public override string ToString()
        {
            return linha
            + ", "
            + coluna;
        }

    }
}