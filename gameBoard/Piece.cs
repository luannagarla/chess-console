namespace gameBoard
{
    abstract class Piece 
    {
        public Position position { get; set; }
        public GameBoard board { get; protected set; }
        public Color color { get; protected set; }
        public int movements { get; protected set; }
       

        public Piece(GameBoard board, Color color)
        {
            this.position = null;
            this.board = board;
            this.color = color;
            this.movements = 0;
        }

        // public void incrementMovement()
        // {
        //     movements++;
        // }

        public abstract bool[,] possibleMovements();
        
    }

}