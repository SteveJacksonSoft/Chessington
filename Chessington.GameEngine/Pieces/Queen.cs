using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces {
    public class Queen : Piece {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board) {
            Square currentPosition = board.FindPiece(this);

            List<Func<Square, Square>> directions = new List<Func<Square, Square>> {
                square => square.GetRelativeSquare(Direction.UpRight, 1),
                square => square.GetRelativeSquare(Direction.UpLeft, 1),
                square => square.GetRelativeSquare(Direction.DownRight, 1),
                square => square.GetRelativeSquare(Direction.DownLeft, 1),
                square => square.GetRelativeSquare(Direction.Up, 1),
                square => square.GetRelativeSquare(Direction.Right, 1),
                square => square.GetRelativeSquare(Direction.Down, 1),
                square => square.GetRelativeSquare(Direction.Left, 1)
            };

            return directions.SelectMany(direction => board.GetSquaresHitByRepeatedMovement(currentPosition, direction));
        }
    }
}