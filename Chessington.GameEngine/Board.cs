using System;
using System.Collections.Generic;
using Chessington.GameEngine.Pieces;

namespace Chessington.GameEngine {
    public class Board {
        private readonly Piece[,] board;
        public Square[] PreviousMove { get; private set; }
        public Player CurrentPlayer { get; private set; }
        public IList<Piece> CapturedPieces { get; private set; }

        public Board()
            : this(Player.White) { }

        public Board(Player currentPlayer, Piece[,] boardState = null) {
            board = boardState ?? new Piece[GameSettings.BoardSize, GameSettings.BoardSize];
            CurrentPlayer = currentPlayer;
            CapturedPieces = new List<Piece>();
            PreviousMove = new Square[2];
        }

        public void AddPiece(Square square, Piece pawn) {
            board[square.Row, square.Col] = pawn;
        }

        public Piece GetPiece(Square square) {
            return board[square.Row, square.Col];
        }

        public Square FindPiece(Piece piece) {
            for (var row = 0; row < GameSettings.BoardSize; row++)
            for (var col = 0; col < GameSettings.BoardSize; col++)
                if (board[row, col] == piece)
                    return Square.At(row, col);

            throw new ArgumentException("The supplied piece is not on the board.", "piece");
        }

        public void MovePiece(Square from, Square to) {
            var movingPiece = board[from.Row, from.Col];
            if (movingPiece == null) {
                return;
            }

            if (movingPiece.Player != CurrentPlayer) {
                throw new ArgumentException("The supplied piece does not belong to the current player.");
            }

            MarkAnyCapturedPiece(to);
            RelocateMovingPiece(from, to);
            ImplementAnyEnPassant(movingPiece, from, to);
            RecordAsPreviousMove(from, to);
            PassToNextPlayer(movingPiece);
        }

        private void MarkAnyCapturedPiece(Square target) {
            if (board[target.Row, target.Col] != null) {
                OnPieceCaptured(board[target.Row, target.Col]);
            }
        }

        private void RelocateMovingPiece(Square startingSquare, Square destination) {
            board[destination.Row, destination.Col] = board[startingSquare.Row, startingSquare.Col];
            board[startingSquare.Row, startingSquare.Col] = null;
        }

        private void ImplementAnyEnPassant(Piece movingPiece, Square from, Square to) {
            if (!(movingPiece is Pawn) || from.Col == to.Col) {
                return;
            }
            
            OnPieceCaptured(board[from.Row, to.Col]);
            board[from.Row, to.Col] = null;
        }

        private void RecordAsPreviousMove(Square from, Square to) {
            PreviousMove[0] = from;
            PreviousMove[1] = to;
        }

        private void PassToNextPlayer(Piece movingPiece) {
            CurrentPlayer = movingPiece.Player == Player.White ? Player.Black : Player.White;
            OnCurrentPlayerChanged(CurrentPlayer);
        }
        
        public bool ContainsSquare(Square square) {
            return square.Row >= 0 && square.Row < GameSettings.BoardSize &&
                   square.Col >= 0 && square.Col < GameSettings.BoardSize;
        }

        public bool SquareIsEmpty(Square square) {
            return board[square.Row, square.Col] == null;
        }

        /**
         * Collects an IEnumerable of Squares, starting with the first square away from the startingSquare in the
         * specified direction, and continuing in that direction until it hits an occupied square (which is also
         * returned), or until the edge of the board if no occupied square is hit.
         */
        public IEnumerable<Square> GetLineInDirectionUpToBlockingPiece(Square startingSquare, Direction direction) {
            Square nextSquare = startingSquare.GetRelativeSquare(direction, 1);
            while (true) {
                if (!ContainsSquare(nextSquare)) {
                    yield break;
                }

                yield return nextSquare;
                if (!SquareIsEmpty(nextSquare)) {
                    yield break;
                }

                nextSquare = nextSquare.GetRelativeSquare(direction, 1);
            }
        }

        public delegate void PieceCapturedEventHandler(Piece piece);

        public event PieceCapturedEventHandler PieceCaptured;

        protected virtual void OnPieceCaptured(Piece piece) {
            var handler = PieceCaptured;
            if (handler != null) handler(piece);
        }

        public delegate void CurrentPlayerChangedEventHandler(Player player);

        public event CurrentPlayerChangedEventHandler CurrentPlayerChanged;

        protected virtual void OnCurrentPlayerChanged(Player player) {
            var handler = CurrentPlayerChanged;
            if (handler != null) handler(player);
        }
    }
}