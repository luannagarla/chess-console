// Português (Brasil) = Torre

using gameBoard;

namespace chess
{
    class Rook : Piece
    {
        public Rook (GameBoard board, Color color) : base(board, color) {}

        public override string ToString ()
        {
            return "R";
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
            while(board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if(board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.line = pos.line - 1;
            }
                

            // ↓
            pos.setValues(position.line +1, position.column);
            while(board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if(board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.line = pos.line + 1;
            }
            
            // →
            pos.setValues(position.line, position.column + 1);
            while(board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if(board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.column = pos.column + 1;
            }
             
            // ←
            pos.setValues(position.line, position.column - 1);
            while(board.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if(board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.column = pos.column - 1;
            }         
            
            return mat;

        }
        
    }
}