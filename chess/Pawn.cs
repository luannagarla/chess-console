//PT-BR: Peão

using gameBoard;

namespace chess 
{

    class Pawn : Piece 
    {

        private ChessMatch chess;

        public Pawn(GameBoard board, Color color, ChessMatch chess) : base(board, color) 
        {
            this.chess = chess;
        }

        public override string ToString() 
        {
            return "P";
        }

        private bool enemy(Position pos) 
        {
            Piece p = board.piece(pos);
            return p != null && p.color != color;
        }

        private bool free(Position pos) 
        {
            return board.piece(pos) == null;
        }

        public override bool[,] possibleMovements() 
        {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            if (color == Color.White) 
            {
                pos.setValues(position.line - 1, position.column);
                if (board.validPosition(pos) && free(pos)) 
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(position.line - 2, position.column);
                Position p2 = new Position(position.line - 1, position.column);
                if (board.validPosition(p2) && free(p2) && board.validPosition(pos) && free(pos) && movements == 0) 
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(position.line - 1, position.column - 1);
                if (board.validPosition(pos) && enemy(pos)) 
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(position.line - 1, position.column + 1);
                if (board.validPosition(pos) && enemy(pos)) 
                {
                    mat[pos.line, pos.column] = true;
                }

                // En passant
                if (position.line == 3) 
                {
                    Position left = new Position(position.line, position.column - 1);
                    if (board.validPosition(left) && enemy(left) && board.piece(left) == chess.vulnerableEnPassant) 
                    {
                        mat[left.line - 1, left.column] = true;
                    }
                    Position right = new Position(position.line, position.column + 1);
                    if (board.validPosition(right) && enemy(right) && board.piece(right) == chess.vulnerableEnPassant) 
                    {
                        mat[right.line - 1, right.column] = true;
                    }
                }
            }
            else {
                pos.setValues(position.line + 1, position.column);
                if (board.validPosition(pos) && free(pos)) 
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(position.line + 2, position.column);
                Position p2 = new Position(position.line + 1, position.column);
                if (board.validPosition(p2) && free(p2) && board.validPosition(pos) && free(pos) && movements == 0) 
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(position.line + 1, position.column - 1);
                if (board.validPosition(pos) && enemy(pos)) 
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValues(position.line + 1, position.column + 1);
                if (board.validPosition(pos) && enemy(pos)) 
                {
                    mat[pos.line, pos.column] = true;
                }

                //En passant
                if (position.line == 4) 
                {
                    Position left = new Position(position.line, position.column - 1);
                    if (board.validPosition(left) && enemy(left) && board.piece(left) == chess.vulnerableEnPassant) 
                    {
                        mat[left.line + 1, left.column] = true;
                    }
                    Position right = new Position(position.line, position.column + 1);
                    if (board.validPosition(right) && enemy(right) && board.piece(right) == chess.vulnerableEnPassant) 
                    {
                        mat[right.line + 1, right.column] = true;
                    }
                }
            }

            return mat;
        }
    }
}