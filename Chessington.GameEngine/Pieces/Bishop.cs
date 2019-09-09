using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces {
    public class Bishop : Piece {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board) {
            Square currentPosition = board.FindPiece(this);

            List<Square> availableMoves = new List<Square>();

            availableMoves.AddRange(
                IterateMovementWhileOnBoard(board, currentPosition, square => 
                    square.NextSquare(Direction.UP).NextSquare(Direction.RIGHT)
                )
            );
            availableMoves.AddRange(
                IterateMovementWhileOnBoard(board, currentPosition, square => 
                    square.NextSquare(Direction.UP).NextSquare(Direction.LEFT)
                )
            );
            availableMoves.AddRange(
                IterateMovementWhileOnBoard(board, currentPosition, square => 
                    square.NextSquare(Direction.DOWN).NextSquare(Direction.RIGHT)
                )
            );
            availableMoves.AddRange(
                IterateMovementWhileOnBoard(board, currentPosition, square => 
                    square.NextSquare(Direction.DOWN).NextSquare(Direction.LEFT)
                )
            );
            
            return availableMoves;
        }

        private delegate Square Movement(Square square);

        private List<Square> IterateMovementWhileOnBoard(Board board, Square startingSquare, Movement movement) {
            Square nextSquare = movement(startingSquare);
            List<Square> collectedSquares = new List<Square>();
            
            while (board.ContainsSquare(nextSquare)) {
                collectedSquares.Add(nextSquare);
                nextSquare = movement(nextSquare);
            }

            return collectedSquares;
        }
    }
}