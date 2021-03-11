using System;
using gameBoard;

namespace xadrez_console
{
    class Screen
    {

        public static void printGameBoard(GameBoard board)
        {
            for(int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");

                for(int j = 0; j < board.columns; j++)
                {                       
                    if (board.piece(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        printPiece(board.piece(i,j));
                        Console.Write(" ");
                    }                                 
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printPiece(Piece piece)
        {
           if (piece.color == Color.White)
           {
               Console.Write(piece);
           }
           else
           {
               ConsoleColor aux = Console.ForegroundColor;
               Console.ForegroundColor = ConsoleColor.Yellow;
               Console.Write(piece);
               Console.ForegroundColor = aux;
           }
        }
    }
}