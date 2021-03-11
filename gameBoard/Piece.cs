using gameBoard;

namespace gameBoard
{
    class Piece
    {
        public Position position { get; set; }
        public GameBoard board { get; protected set; }
        public Color color { get; protected set; }
        public int movements { get; protected set; }
       

        public Piece(Position position, GameBoard board, Color color)
        {
            this.position = position;
            this.board = board;
            this.color = color;
            this.movements = 0;
        }
    }

}