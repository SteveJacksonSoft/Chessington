using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces {
    public class Pawn : Piece {
        public Pawn(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board) {
            Square currentPosition = board.FindPiece(this);

            List<Square> availableMoves = new List<Square>();

            if (CanMoveOneSquareForwards(board)) {
                availableMoves.Add(currentPosition.GetRelativeSquare(AttackingDirection, 1));
            }

            if (CanMoveTwoSquaresForwards(board)) {
                availableMoves.Add(currentPosition.GetRelativeSquare(AttackingDirection, 2));
            }

            return availableMoves;
        }

        private bool CanMoveOneSquareForwards(Board board) {
            return board.SquareIsEmpty(board.FindPiece(this).GetRelativeSquare(AttackingDirection, 1));
        }

        private bool CanMoveTwoSquaresForwards(Board board) {
            Square currentPosition = board.FindPiece(this);
            return board.SquareIsEmpty(currentPosition.GetRelativeSquare(AttackingDirection, 1))
                   && !HasMoved
                   && board.SquareIsEmpty(currentPosition.GetRelativeSquare(AttackingDirection, 2));
        }
    }
}