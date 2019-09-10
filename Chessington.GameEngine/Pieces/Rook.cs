using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board) {
            List<Direction> availableDirections = new List<Direction> {
                Direction.Up,
                Direction.Right,
                Direction.Down,
                Direction.Left
            };

            return availableDirections.SelectMany(direction =>
                board.GetLineInDirectionUpToBlockingPiece(board.FindPiece(this), direction)
            ).Where(square => {
                Piece occupyingPiece = board.GetPiece(square);
                return occupyingPiece == null || occupyingPiece.Player != this.Player;
            });
        }
    }
}