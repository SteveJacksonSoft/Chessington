using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces {
    public class King : Piece {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board) {
            List<Direction> availableDirections = new List<Direction> {
                Direction.Up,
                Direction.Right,
                Direction.Down,
                Direction.Left,
                Direction.UpLeft,
                Direction.UpRight,
                Direction.DownLeft,
                Direction.DownRight
            };

            return FilterOutMovesToIllegalSquares(
                board,
                availableDirections.Select(direction =>
                    board.FindPiece(this).GetRelativeSquare(direction, 1)
                )
            );
        }
    }
}