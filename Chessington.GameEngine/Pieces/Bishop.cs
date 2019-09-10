using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces {
    public class Bishop : Piece {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board) {
            Square currentPosition = board.FindPiece(this);

            List<Direction> availableDirections = new List<Direction> {
                Direction.UpRight,
                Direction.UpLeft,
                Direction.DownRight,
                Direction.DownLeft
            };

            return availableDirections.SelectMany(direction =>
                board.GetSquaresHitByRepeatedMovementUntilBlocked(
                    currentPosition,
                    square => square.GetRelativeSquare(direction, 1)
                )
            );
        }
    }
}