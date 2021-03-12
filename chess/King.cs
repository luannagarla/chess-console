// Português (Brasil) = Rei

using gameBoard;

namespace chess
{
    class King : Piece
    {
        public King (GameBoard board, Color color) : base(board, color) {}

        public override string ToString ()
        {
            return "K";
        }

        public bool canMove(Position pos)
        {
            Piece p = board.piece(pos);

            return p == null || p.color != color;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0,0);

            
            // ↑ 
            pos.setValues(position.line -1, position.column);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            //↗
            pos.setValues(position.line -1, position.column +1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            // →
            pos.setValues(position.line, position.column +1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            //↘
            pos.setValues(position.line +1, position.column +1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }


            // ↓ 
            pos.setValues(position.line +1, position.column);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            // ↙
            pos.setValues(position.line +1, position.column -1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            // ←
            pos.setValues(position.line, position.column -1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            // ↖
            pos.setValues(position.line -1, position.column -1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            return mat;

        }
        
    }
}