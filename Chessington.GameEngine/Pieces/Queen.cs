using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces {
    public class Queen : Piece {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board) {
            Square currentPosition = board.FindPiece(this);

            List<Square> availableMoves = new List<Square>();

            List<Board.Movement> directions = new List<Board.Movement> {
                square => square.NextSquare(Direction.UP).NextSquare(Direction.RIGHT),
                square => square.NextSquare(Direction.UP).NextSquare(Direction.LEFT),
                square => square.NextSquare(Direction.DOWN).NextSquare(Direction.RIGHT),
                square => square.NextSquare(Direction.DOWN).NextSquare(Direction.LEFT),
                square => square.NextSquare(Direction.UP),
                square => square.NextSquare(Direction.RIGHT),
                square => square.NextSquare(Direction.DOWN),
                square => square.NextSquare(Direction.LEFT)
            };
            
            directions.ForEach(direction => 
                availableMoves.AddRange(board.GetSquaresHitByRepeatedMovement(currentPosition, direction))
            );
            
            return availableMoves;
        }
    }
}