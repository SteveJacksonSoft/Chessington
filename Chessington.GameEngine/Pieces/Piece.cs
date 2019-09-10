using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces {
    public abstract class Piece {
        protected readonly Direction AttackingDirection;
        public int NumberOfMovesMade { get; private set; }

        protected Piece(Player player) {
            Player = player;
            AttackingDirection = player == Player.White ? Direction.Up : Direction.Down;
            NumberOfMovesMade = 0;
        }

        public Player Player { get; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        protected IEnumerable<Square> FilterOutMovesToIllegalSquares(Board board, IEnumerable<Square> moves) {
            // QQ question - Is this a bit heavy-handed?
            return moves
                .Where(board.ContainsSquare)
                .Where(square => board.GetPiece(square)?.Player != this.Player);
        }

        public void MoveTo(Board board, Square newSquare) {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
            NumberOfMovesMade++;
        }
    }
}