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
        
    }
}