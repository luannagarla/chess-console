using System;
using gameBoard;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard board = new GameBoard(8,8);

            Screen.printGameBoard(board);

            
        }
    }
}
