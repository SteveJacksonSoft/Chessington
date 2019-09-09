using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board) {
            Square currentPosition = board.FindPiece(this);

            List<Square> availableMoves = new List<Square>();

            for (int i = 0; i < 8; i++) {
                if (i != currentPosition.Row) {
                    availableMoves.Add(Square.At(i, currentPosition.Col));
                }
                if (i != currentPosition.Col) {
                    availableMoves.Add(Square.At(currentPosition.Row, i));
                }
            }

            return availableMoves;
        }
    }
}