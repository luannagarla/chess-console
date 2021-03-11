using System;
using gameBoard;
using chess;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {

         PositionChess pos = new PositionChess('c',7);   
         Console.WriteLine(pos);

         Console.WriteLine(pos.toPosition());

            
        }
    }
}
