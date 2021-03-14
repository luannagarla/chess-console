using gameBoard;
using System.Collections.Generic;

namespace chess
{
    class ChessMatch
    {
        public GameBoard board {get; private set;}
        public int turn {get; private set;}
        public Color currentPlayer {get; private set;}
        public bool finished {get; private set;}
        private HashSet<Piece> pieces;
        private HashSet<Piece> capturedPieces;

        public ChessMatch()
        {
            board = new GameBoard(8,8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            pieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            putPieces();
        }

        public void carryOutMovement(Position origin, Position destiny)
        {
            Piece p = board.removePiece(origin);
            p.incrementMovements();
            Piece capturedPiece  = board.removePiece(destiny);

            board.putPiece(p, destiny);

            if(capturedPiece != null)
            {
                capturedPieces.Add(capturedPiece);
            }
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

        public HashSet<Piece> captured(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();

            foreach (Piece piece in capturedPieces)
            {
                if (piece.color == color)
                {
                    aux.Add(piece);
                }
            }
            return aux;
        }

        public HashSet<Piece> piecesInPlay(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in pieces)
            {
                if (piece.color == color)
                {
                    aux.Add(piece);
                }
            }
            aux.ExceptWith(captured(color));
            return aux;
        }

        public void putNewPiece(char column, int line, Piece piece)
        {
            board.putPiece(piece, new PositionChess(column, line).toPosition());
            pieces.Add(piece);
        }

        private void putPieces()
        {
            putNewPiece('c', 1, new Rook(board, Color.White));            
            putNewPiece('c', 2, new Rook(board, Color.White));
            putNewPiece('d', 2, new Rook(board, Color.White));
            putNewPiece('e', 2, new Rook(board, Color.White));
            putNewPiece('e', 1, new Rook(board, Color.White));
            putNewPiece('d', 1, new King(board, Color.White));

            putNewPiece('c', 7, new Rook(board, Color.Black));
            putNewPiece('c', 8, new Rook(board, Color.Black));
            putNewPiece('d', 7, new Rook(board, Color.Black));
            putNewPiece('e', 7, new Rook(board, Color.Black));
            putNewPiece('e', 8, new Rook(board, Color.Black));
            putNewPiece('d', 8, new King(board, Color.Black));


        }

    }


}