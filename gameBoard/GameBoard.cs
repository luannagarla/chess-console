using gameBoard;

namespace gameBoard
{
    class GameBoard
    {
        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public GameBoard(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            pieces = new Piece[lines, columns];
        }

        public Piece piece(int line, int column)
        {
            return pieces[line, column];
        }

        public Piece piece(Position pos)
        {
            return pieces[pos.line, pos.column];
        }

        public bool pieceExist(Position pos)
        {
            positionValidate(pos);
            return piece(pos) != null;
        }

        public void putPiece (Piece p, Position pos)
        {
            pieces[pos.line, pos.column] = p;
            p.position = pos;
        }

        public bool validPosition(Position pos)
        {
            if (pos.line < 0 || pos.line >= lines || pos.column < 0 || pos.column >= columns)
            {
                return false;
            }
            return true;
        }

        public void positionValidate(Position pos)
        {
            if (!validPosition(pos))
            {
                throw new BoardException ("Position invalid!");
            }


        }


    }
}