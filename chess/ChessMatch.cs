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
        public bool check {get; private set;}

        public ChessMatch()
        {
            board = new GameBoard(8,8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            check = false;
            pieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            putPieces();
        }

        public Piece carryOutMovement(Position origin, Position destiny)
        {
            Piece p = board.removePiece(origin);
            p.incrementMovements();
            Piece capturedPiece  = board.removePiece(destiny);

            board.putPiece(p, destiny);

            if(capturedPiece != null)
            {
                capturedPieces.Add(capturedPiece);
            }

            return capturedPiece;
        }

        public void undoMovement(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = board.removePiece(destiny);
            p.decrementMovements();

            if(capturedPiece != null)
            {
                board.putPiece(capturedPiece, destiny);
                capturedPieces.Remove(capturedPiece);
            }
            board.putPiece(p, origin);
        }

        //pt-br: realiza a jogada
        public void move(Position origin, Position destiny)
        {
            Piece capturedPiece = carryOutMovement(origin, destiny);

            if(itsCheckmate(currentPlayer))
            {
                undoMovement(origin, destiny, capturedPiece);
                throw new BoardException("You can't put yourself in check.");
            }

            if(itsCheckmate(adversary(currentPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            if(testCheckmate(adversary(currentPlayer)))
            {
                finished = true;
            }
            else
            {
               turn++;
                changePLayers(); 
            }            
        }

        public void validateOriginPosition(Position pos)
        {
            if (board.piece(pos) == null)
            {
                throw new BoardException ("There is no part in the chosen starting position. Press enter to continue...");
            }
            if (currentPlayer != board.piece(pos).color)
            {
                throw new BoardException ("The piece of chosen origin is not yours. Press enter to continue...");
            }
            if(!board.piece(pos).testPossibleMovements())
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

        public void changePLayers()
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

         private Color adversary (Color color)
        {
            if(color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece king(Color color)
        {
            foreach (Piece piece in piecesInPlay(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        public bool itsCheckmate(Color color)
        {
            Piece K = king(color);
            if (K == null)
            {
                throw new BoardException("King don't exists.");
            }

            foreach (Piece piece in piecesInPlay(adversary(color)))
            {
                bool[,] mat = piece.possibleMovements();

                if(mat[K.position.line, K.position.column])
                {
                    return true;
                }
                                              
            }
            return false;
        }

        public bool testCheckmate(Color color)
        {
            if(!itsCheckmate(color))
            {
                return false;
            }
            foreach (Piece piece in piecesInPlay(color))
            {
                bool[,] mat = piece.possibleMovements();

                for (int i = 0; i < board.lines; i++)
                {
                    for (int j = 0; j < board.columns; j++)
                    {
                        if(mat[i,j])
                        {   
                            Position origin = piece.position;
                            Position destiny = new Position(i,j);

                            Piece capturedPiece = carryOutMovement(origin, destiny);

                            bool testCheck = itsCheckmate(color);

                            undoMovement(origin, destiny, capturedPiece);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
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