using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces {
    public class King : Piece {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board) {
            Square currentPosition = board.FindPiece(this);

            return new List<Square> {
                currentPosition.GetRelativeSquare(Direction.Up, 1),
                currentPosition.GetRelativeSquare(Direction.Right, 1),
                currentPosition.GetRelativeSquare(Direction.Down, 1),
                currentPosition.GetRelativeSquare(Direction.Left, 1),
                currentPosition.GetRelativeSquare(Direction.UpLeft, 1),
                currentPosition.GetRelativeSquare(Direction.UpRight, 1),
                currentPosition.GetRelativeSquare(Direction.DownLeft, 1),
                currentPosition.GetRelativeSquare(Direction.DownRight, 1),
            };
        }
    }
}