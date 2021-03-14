using gameBoard;


namespace chess
{
    class ChessMatch
    {
        public GameBoard board {get; private set;}
        public int turn {get; private set;}
        public Color currentPlayer {get; private set;}
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
            p.incrementMovements();
            Piece capturedPiece  = board.removePiece(destiny);

            board.putPiece(p, destiny);
        }

        //pt-br: realiza a jogada
        public void move(Position origin, Position destiny)
        {
            carryOutMovement(origin, destiny);

            turn++;

            chancePLayers();
        }

        public void validateOriginPosition(Position pos)
        {
            if (board.piece(pos) == null)
            {
                throw new BoardException ("There is no part in the chosen starting position. Press enter to continue...");
            }
            if (currentPlayer != board.piece(pos).color)
            {
                throw new BoardException ("The piece of chosen origin is not yours.Press enter to continue...");
            }
            if(board.piece(pos).testPossibleMovements())
            {
                throw new BoardException ("There are no possible movements for the chosen piece of origin. Press enter to continue...");
            }
        }

        public void validateDestinyPosition(Position origin, Position destiny)
        {
           if (!board.piece(origin).canMoveTo(destiny)) 
           {
               throw new BoardException("Invalid target Position. Press enter to continue...");
           }
        }

        public void chancePLayers()
        {
            if(currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }
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