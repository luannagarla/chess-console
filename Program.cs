using System;
using gameBoard;
using chess;

namespace chess_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
               ChessMatch chess = new ChessMatch();

               while(!chess.finished)
               {
                    Console.Clear();
                    Screen.printGameBoard(chess.board);

                    Console.WriteLine();

                    Console.Write("Origin: ");
                    Position origin = Screen.readPositionChess().toPosition();

                    bool[,] possiblePositions = chess.board.piece(origin).possibleMovements();


                    Console.Clear();
                    Screen.printGameBoard(chess.board, possiblePositions);
                        
                    Console.WriteLine();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.readPositionChess().toPosition();


                    chess.carryOutMovement(origin,destiny);

               }

               


            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            
        }
    }
}
