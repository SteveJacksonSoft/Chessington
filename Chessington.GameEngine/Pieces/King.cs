using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces {
    public class King : Piece {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board) {
            Square currentPosition = board.FindPiece(this);

            return new List<Square> {
                currentPosition.NextSquare(Direction.UP),
                currentPosition.NextSquare(Direction.RIGHT),
                currentPosition.NextSquare(Direction.DOWN),
                currentPosition.NextSquare(Direction.LEFT),
                currentPosition.NextSquare(Direction.UP).NextSquare(Direction.LEFT),
                currentPosition.NextSquare(Direction.UP).NextSquare(Direction.RIGHT),
                currentPosition.NextSquare(Direction.DOWN).NextSquare(Direction.LEFT),
                currentPosition.NextSquare(Direction.DOWN).NextSquare(Direction.RIGHT),
            };
        }
    }
}