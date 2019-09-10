using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces {
    public class Queen : LineMovingPiece {
        protected override List<Direction> AvailableDirections { get; } = new List<Direction> {
            Direction.Up,
            Direction.Right,
            Direction.Down,
            Direction.Left,
            Direction.UpRight,
            Direction.DownRight,
            Direction.DownLeft,
            Direction.UpLeft
        };

        public Queen(Player player)
            : base(player) {
        }
    }
}