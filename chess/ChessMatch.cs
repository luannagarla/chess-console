using gameBoard;


namespace chess
{
    class ChessMatch
    {
        public GameBoard board {get; private set;}
        private int turn;
        private Color currentPlayer;
        public bool finished {get; private set;}

        public ChessMatch()
        {
            board = new GameBoard(8,8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            putPieces();
        }

        public void carryOutMovement(Position origin, Position destiny)
        {
            Piece p = board.removePiece(origin);
            p.incrementMovement();
            Piece capturedPiece  = board.removePiece(destiny);

            board.putPiece(p, destiny);
        }

        private void putPieces()
        {
            board.putPiece(new Rook(board, Color.White), new PositionChess('c', 1).toPosition());
            board.putPiece(new Rook(board, Color.White), new PositionChess('c', 2).toPosition());
            board.putPiece(new Rook(board, Color.White), new PositionChess('d', 2).toPosition());
            board.putPiece(new Rook(board, Color.White), new PositionChess('e', 2).toPosition());
            board.putPiece(new Rook(board, Color.White), new PositionChess('e', 1).toPosition());
            board.putPiece(new King(board, Color.White), new PositionChess('d', 1).toPosition());

            board.putPiece(new Rook(board, Color.Black), new PositionChess('c', 7).toPosition());
            board.putPiece(new Rook(board, Color.Black), new PositionChess('c', 8).toPosition());
            board.putPiece(new Rook(board, Color.Black), new PositionChess('d', 7).toPosition());
            board.putPiece(new Rook(board, Color.Black), new PositionChess('e', 7).toPosition());
            board.putPiece(new Rook(board, Color.Black), new PositionChess('e', 8).toPosition());
            board.putPiece(new King(board, Color.Black), new PositionChess('d', 8).toPosition());


        }

    }


}