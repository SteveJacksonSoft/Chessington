using System.Collections.Generic;
using System.Linq;

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

            availableMoves.AddRange(GetAttackableSquares(board));
            
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

        private IEnumerable<Square> GetAttackableSquares(Board board) {
            Square currentPosition = board.FindPiece(this);
            List<Square> potentialTargetSquares = new List<Square> {
                currentPosition.GetRelativeSquare(AttackingDirection, 1).GetRelativeSquare(Direction.Left, 1),
                currentPosition.GetRelativeSquare(AttackingDirection, 1).GetRelativeSquare(Direction.Right, 1)
            };

            return potentialTargetSquares
                .Where(board.ContainsSquare)
                .Where(square => board.GetPiece(square) != null && board.GetPiece(square).Player != this.Player);
        }
    }
}