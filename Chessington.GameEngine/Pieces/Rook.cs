using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : LineMovingPiece
    {
        protected override List<Direction> AvailableDirections { get; } = new List<Direction> {
            Direction.Up,
            Direction.Right,
            Direction.Down,
            Direction.Left
        };
        
        public Rook(Player player)
            : base(player) { }
    }
}