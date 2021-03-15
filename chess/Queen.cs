//PT-BR: Rainha/Dama

using gameBoard;

namespace chess
{

    class Queen : Piece 
    {

        public Queen(GameBoard board, Color color) : base(board, color) {}
        

        public override string ToString() 
        {
            return "Q";
        }

        private bool canMove(Position pos) 
        {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMovements() 
        {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            // →
            pos.setValues(position.line, position.column - 1);
            while (board.validPosition(pos) && canMove(pos)) 
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) 
                {
                    break;
                }
                pos.setValues(pos.line, pos.column - 1);
            }

            // ←
            pos.setValues(position.line, position.column + 1);
            while (board.validPosition(pos) && canMove(pos)) 
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) 
                {
                    break;
                }
                pos.setValues(pos.line, pos.column + 1);
            }

            // ↑ 
            pos.setValues(position.line - 1, position.column);
            while (board.validPosition(pos) && canMove(pos)) 
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) 
                {
                    break;
                }
                pos.setValues(pos.line - 1, pos.column);
            }

            // ↓
            pos.setValues(position.line + 1, position.column);
            while (board.validPosition(pos) && canMove(pos)) 
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.line + 1, pos.column);
            }

            // NO
            pos.setValues(position.line - 1, position.column - 1);
            while (board.validPosition(pos) && canMove(pos)) 
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) 
                {
                    break;
                }
                pos.setValues(pos.line - 1, pos.column - 1);
            }

            // NE
            pos.setValues(position.line - 1, position.column + 1);
            while (board.validPosition(pos) && canMove(pos)) 
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) 
                {
                    break;
                }
                pos.setValues(pos.line - 1, pos.column + 1);
            }

            // SE
            pos.setValues(position.line + 1, position.column + 1);
            while (board.validPosition(pos) && canMove(pos)) 
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) 
                {
                    break;
                }
                pos.setValues(pos.line + 1, pos.column + 1);
            }

            // SO
            pos.setValues(position.line + 1, position.column - 1);
            while (board.validPosition(pos) && canMove(pos)) 
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) 
                {
                    break;
                }
                pos.setValues(pos.line + 1, pos.column - 1);
            }

            return mat;
        }
    }
}