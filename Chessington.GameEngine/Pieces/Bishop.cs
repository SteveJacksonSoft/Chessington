using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces {
    public class Bishop : Piece {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board) {
            Square currentPosition = board.FindPiece(this);

            List<Square> availableMoves = new List<Square>();

            List<Func<Square, Square>> directions = new List<Func<Square, Square>> {
                square => square.GetRelativeSquare(Direction.UpRight, 1),
                square => square.GetRelativeSquare(Direction.UpLeft, 1),
                square => square.GetRelativeSquare(Direction.DownRight, 1),
                square => square.GetRelativeSquare(Direction.DownLeft, 1)
            };

            directions.SelectMany(direction => board.GetSquaresHitByRepeatedMovement(currentPosition, direction));
            
            directions.ForEach(direction => 
                availableMoves.AddRange(board.GetSquaresHitByRepeatedMovement(currentPosition, direction))
            );
            
            return availableMoves;
        }
    }
}