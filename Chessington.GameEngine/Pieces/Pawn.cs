using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board) {
            Square currentPosition = board.FindPiece(this);

            return new List<Square> {
                new Square(currentPosition.Row + 1, currentPosition.Col),
                new Square(currentPosition.Row - 1, currentPosition.Col)
            };
        }
    }
}