// Português (Brasil) = Rei

using gameBoard;

namespace chess
{
    class King : Piece
    {
        private ChessMatch chess;

        public King (GameBoard board, Color color, ChessMatch chess) : base(board, color) 
        {
            this.chess = chess;
        }

        public override string ToString ()
        {
            return "K";
        }

        public bool canMove(Position pos)
        {
            Piece p = board.piece(pos);

            return p == null || p.color != color;
        }

        public bool testRookToCastling(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p is Rook && p.color == color && movements == 0;
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

            // chess castling
            if(movements == 0 && !chess.check)
            {
                //smal
                Position posR1 = new Position(position.line, position.column + 3);

                if(testRookToCastling(posR1))
                {
                   Position p1 = new Position(position.line, position.column + 1); 
                   Position p2 = new Position(position.line, position.column + 2);

                   if(board.piece(p1)==null && board.piece(p2)==null)
                   {
                       mat[position.line, position.column+2] = true;
                   }
                }

                //big
                Position posR2 = new Position(position.line, position.column - 4);

                if(testRookToCastling(posR2))
                {
                   Position p1 = new Position(position.line, position.column - 1); 
                   Position p2 = new Position(position.line, position.column - 2);
                   Position p3 = new Position(position.line, position.column - 3);

                   if(board.piece(p1)==null && board.piece(p2)==null && board.piece(p3)==null)
                   {
                       mat[position.line, position.column-2] = true;
                   }
                }
                
            }

            
            return mat;

        }
        
    }
}