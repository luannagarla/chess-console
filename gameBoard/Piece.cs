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

        public void incrementMovements()
        {
            movements++;
        }

        public void decrementMovements()
        {
            movements--;
        }

        public bool testPossibleMovements()
        {
            bool[,] mat = possibleMovements();

            for (int i = 0; i < board.lines; i++)
            {
                for (int j = 0; j < board.columns; j++)
                {
                   if (mat[i,j])
                   {
                       return false;
                   }
                }
            }
            return true;
        }

        public bool canMoveTo(Position pos)
        {
            return possibleMovements()[pos.line, pos.column];
        }

        public abstract bool[,] possibleMovements();
        
    }

}