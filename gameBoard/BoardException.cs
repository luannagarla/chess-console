using System;

namespace gameBoard
{
    class BoardException : Exception
    {
        public BoardException(string msg) : base(msg)
        {

        }
    }
}