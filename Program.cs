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
                try 
                {
                    Console.Clear();
                    Screen.printChess(chess);

                    Console.WriteLine();

                    Console.Write("Origin: ");
                    Position origin = Screen.readPositionChess().toPosition();

                    chess.validateOriginPosition(origin);

                    bool[,] possiblePositions = chess.board.piece(origin).possibleMovements();


                    Console.Clear();
                    Screen.printGameBoard(chess.board, possiblePositions);
                        
                    Console.WriteLine();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.readPositionChess().toPosition();
                    
                    chess.validateDestinyPosition(origin, destiny);

                    chess.move(origin,destiny);
                }
                catch(BoardException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
               }
                Console.Clear();
                Screen.printChess(chess);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            
        }
    }
}
