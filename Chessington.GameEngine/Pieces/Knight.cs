using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces {
    public class Knight : Piece {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board) {
            Square currentPosition = board.FindPiece(this);

            List<Square> availableMoves = new List<Square> {
                Square.At(currentPosition.Row + 2, currentPosition.Col + 1),
                Square.At(currentPosition.Row + 2, currentPosition.Col - 1),
                Square.At(currentPosition.Row - 2, currentPosition.Col + 1),
                Square.At(currentPosition.Row - 2, currentPosition.Col - 1),
                Square.At(currentPosition.Row + 1, currentPosition.Col + 2),
                Square.At(currentPosition.Row + 1, currentPosition.Col - 2),
                Square.At(currentPosition.Row - 1, currentPosition.Col + 2),
                Square.At(currentPosition.Row - 1, currentPosition.Col - 2),
            };

            return availableMoves.Where(square => {
                if (!board.ContainsSquare(square)) {
                    return false;
                }
                Piece occupyingPiece = board.GetPiece(square);
                return occupyingPiece == null || occupyingPiece.Player != this.Player;
                // QQ question - Should this be sectioned into two methods? Or even two `Where`s?
                // Where would the second method live?
            });
        }
    }
}