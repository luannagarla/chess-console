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
        
    }
}