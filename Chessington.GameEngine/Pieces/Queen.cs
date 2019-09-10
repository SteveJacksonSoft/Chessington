using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces {
    public class Queen : Piece {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board) {
            List<Direction> availableDirections = new List<Direction> {
                Direction.Up,
                Direction.Right,
                Direction.Down,
                Direction.Left,
                Direction.UpRight,
                Direction.DownRight,
                Direction.DownLeft,
                Direction.UpLeft
            };

            return availableDirections.SelectMany(direction =>
                board.GetLineInDirectionUpToBlockingPiece(
                    board.FindPiece(this),
                    direction
                )
            );
        }
    }
}