using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces {
    public class Pawn : Piece {
        public Pawn(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board) {
            Square currentPosition = board.FindPiece(this);

            List<Square> availableMoves = new List<Square>();

            if (Player == Player.White) {
                availableMoves.Add(Square.At(currentPosition.Row - 1, currentPosition.Col));
                if (currentPosition.Row == 6) {
                    availableMoves.Add(Square.At(currentPosition.Row - 2, currentPosition.Col));
                }
            } else {
                availableMoves.Add(Square.At(currentPosition.Row + 1, currentPosition.Col));
                if (currentPosition.Row == 1) {
                    availableMoves.Add(Square.At(currentPosition.Row + 2, currentPosition.Col));
                }
            }

            return availableMoves;
        }
    }
}