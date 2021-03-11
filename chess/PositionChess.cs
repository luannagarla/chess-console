using gameBoard;

namespace chess
{
    class PositionChess
    {
        public char column {get; set;}
        public int line { get; set; }

        public PositionChess(char column, int line)
        {
            this.column = column;
            this.line = line;
        }

        public Position toPosition()
        {
            return new Position ( 8 - line, column - 'a');
        }

        public override string ToString()
        {
            return "" + column + line;
        }


    }
}