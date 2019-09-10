using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces {
    public class King : Piece {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board) {
            Square currentPosition = board.FindPiece(this);

            return new List<Square> {
                currentPosition.GetSquareByRelativePosition(Direction.Up, 1),
                currentPosition.GetSquareByRelativePosition(Direction.Right, 1),
                currentPosition.GetSquareByRelativePosition(Direction.Down, 1),
                currentPosition.GetSquareByRelativePosition(Direction.Left, 1),
                currentPosition.GetSquareByRelativePosition(Direction.UpLeft, 1),
                currentPosition.GetSquareByRelativePosition(Direction.UpRight, 1),
                currentPosition.GetSquareByRelativePosition(Direction.DownLeft, 1),
                currentPosition.GetSquareByRelativePosition(Direction.DownRight, 1),
            };
        }
    }
}