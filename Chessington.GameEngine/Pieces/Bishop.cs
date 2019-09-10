using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces {
    public class Bishop : LineMovingPiece {
        protected override List<Direction> AvailableDirections { get; } = new List<Direction> {
            Direction.UpRight,
            Direction.DownRight,
            Direction.DownLeft,
            Direction.UpLeft
        };

        public Bishop(Player player)
            : base(player) { }
    }
}