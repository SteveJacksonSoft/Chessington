using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board) {
            Square currentPosition = board.FindPiece(this);

            List<Direction> availableDirections = new List<Direction> {
                Direction.Up,
                Direction.Right,
                Direction.Down,
                Direction.Left
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