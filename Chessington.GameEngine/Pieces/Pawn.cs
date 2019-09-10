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
            Square targetSquare = board.FindPiece(this).GetRelativeSquare(AttackingDirection, 1);
            return board.ContainsSquare(targetSquare) && board.SquareIsEmpty(targetSquare);
        }

        private bool CanMoveTwoSquaresForwards(Board board) {
            Square currentPosition = board.FindPiece(this);
            Square firstSquareForwards = currentPosition.GetRelativeSquare(AttackingDirection, 1);
            Square secondSquareForwards = firstSquareForwards.GetRelativeSquare(AttackingDirection, 1);
            return board.ContainsSquare(firstSquareForwards)
                   && board.SquareIsEmpty(firstSquareForwards)
                   && !HasMoved
                   && board.ContainsSquare(secondSquareForwards)
                   && board.SquareIsEmpty(secondSquareForwards);
        }
    }
}