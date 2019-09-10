using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces {
    public abstract class LineMovingPiece : Piece {
        //QQ question - Should I have an abstract property?
        protected abstract List<Direction> AvailableDirections { get; }

        protected LineMovingPiece(Player player) : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board) {
            return FilterOutMovesToIllegalSquares(
                board,
                AvailableDirections.SelectMany(direction =>
                    board.GetLineInDirectionUpToBlockingPiece(board.FindPiece(this), direction)
                )
            );
        }
    }
}