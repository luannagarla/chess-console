using System;
using gameBoard;
using chess;

namespace chess_console
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
                    printPiece(board.piece(i,j));                              
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printGameBoard(GameBoard board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor nonOriginalBackground = ConsoleColor.DarkGray;

            for(int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");

                for(int j = 0; j < board.columns; j++)
                {      
                    if(possiblePositions[i,j]) 
                    {
                       Console.BackgroundColor = nonOriginalBackground; 
                    }         
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }       
                    printPiece(board.piece(i,j));       
                    Console.BackgroundColor = originalBackground;                  
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static PositionChess readPositionChess()
        {
            string s = Console.ReadLine();
            char column = s[0];

            int line = int.Parse(s[1] + "");
            return new PositionChess(column, line);
        }

        public static void printPiece(Piece piece)
        {
            if(piece == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }

           
        }
    }
}