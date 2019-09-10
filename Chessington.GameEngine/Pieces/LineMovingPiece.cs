using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces {
    public abstract class LineMovingPiece : Piece {
        protected abstract List<Direction> AvailableDirections { get; }
        
        protected LineMovingPiece(Player player) : base(player) { }
        
        public override IEnumerable<Square> GetAvailableMoves(Board board) {
            return AvailableDirections.SelectMany(direction =>
                board.GetLineInDirectionUpToBlockingPiece(board.FindPiece(this),direction)
            ).Where(square => {
                Piece occupyingPiece = board.GetPiece(square);
                return occupyingPiece == null || occupyingPiece.Player != this.Player;
            });
        }
    }
}