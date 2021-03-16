using System;
using System.Collections.Generic;
using gameBoard;
using chess;

namespace chess_console
{
    class Screen
    {

        public static void printChess(ChessMatch chess)
        {
            printGameBoard(chess.board);
            Console.WriteLine();
            printCapturedPieces(chess);
            Console.WriteLine();
            Console.WriteLine("Turn: "+ chess.turn);

            if(!chess.finished)
            {
                Console.WriteLine("Awaiting move: " + chess.currentPlayer); 

                if(chess.check)
                {
                    Console.WriteLine("CHECKMATE!"); 
                }
            }
            else
            {
                Console.WriteLine("CHECKMATE!");
                Console.WriteLine("WINNER: " + chess.currentPlayer);
            }    

           
        }

        public static void printCapturedPieces(ChessMatch chess)
        {
            Console.WriteLine("Captured Pieces");
            Console.Write("Pieces captured by the black player: ");
            printSet(chess.captured(Color.White));
            Console.WriteLine();

            Console.Write("Pieces captured by the white player: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            printSet(chess.captured(Color.Black));
            Console.ForegroundColor = aux;
            
            Console.WriteLine();
        }

        public static void printSet(HashSet<Piece> set )
        {
            Console.Write("[");
            foreach (Piece piece in set)
            {
                Console.Write(piece + " ");
            }
            Console.Write("]");
        }

        public static void printGameBoard(GameBoard board)
        {
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("  a b c d e f g h");
            Console.ForegroundColor = aux;
           
            for(int i = 0; i < board.lines; i++)
            {                  
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = aux;

                for(int j = 0; j < board.columns; j++)
                {                       
                    printPiece(board.piece(i,j));                              
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(8 - i + " ");
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("  a b c d e f g h");
            Console.ForegroundColor = aux;
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
            string s = Console.ReadLine().ToLower();
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