using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces {
    public class Pawn : Piece {
        public Pawn(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board) {
            Square currentPosition = board.FindPiece(this);

            List<Square> availableMoves = new List<Square>();

            if (Player == Player.White) {
                Square firstSquareUp = currentPosition.GetSquareByRelativePosition(Direction.Up, 1);
                if (board.GetPiece(firstSquareUp) == null) {
                    availableMoves.Add(firstSquareUp);
                    if (currentPosition.Row == 6) {
                        Square secondSquareUp = firstSquareUp.GetSquareByRelativePosition(Direction.Up, 1);
                        if (board.GetPiece(secondSquareUp) == null) {
                            availableMoves.Add(Square.At(currentPosition.Row - 2, currentPosition.Col));
                        }
                    }
                }
            } else {
                Square firstSquareDown = currentPosition.GetSquareByRelativePosition(Direction.Down, 1);
                if (board.GetPiece(firstSquareDown) == null) {
                    availableMoves.Add(firstSquareDown);
                    if (currentPosition.Row == 1) {
                        Square secondSquareDown = firstSquareDown.GetSquareByRelativePosition(Direction.Down, 1);
                        if (board.GetPiece(secondSquareDown) == null) {
                            availableMoves.Add(secondSquareDown);
                        }
                    }
                }
            }

            return availableMoves;
        }

        private IEnumerable<Square> RemoveDisallowedMoves(IEnumerable<Square> availableMoves, Board board) {
            return new List<Square>();
        }
    }
}