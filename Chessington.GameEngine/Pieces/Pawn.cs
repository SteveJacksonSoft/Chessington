using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces {
    public class Pawn : Piece {
        private readonly int indexOfFifthRank;

        public Pawn(Player player)
            : base(player) {
            indexOfFifthRank = player == Player.White ? 3 : 4;
        }
        
        public override IEnumerable<Square> GetAvailableMoves(Board board) {
            Square currentPosition = board.FindPiece(this);

            List<Square> availableMoves = new List<Square>();

            if (CanMoveOneSquareForwards(board)) {
                availableMoves.Add(currentPosition.GetRelativeSquare(AttackingDirection, 1));
            }

            if (CanMoveTwoSquaresForwards(board)) {
                availableMoves.Add(currentPosition.GetRelativeSquare(AttackingDirection, 2));
            }

            availableMoves.AddRange(GetAttackableSquares(board));

            availableMoves.AddRange(GetAnyEnPassantMoves(board));

            return availableMoves;
        }

        private bool CanMoveOneSquareForwards(Board board) {
            Square targetSquare = board.FindPiece(this).GetRelativeSquare(AttackingDirection, 1);
            return board.ContainsSquare(targetSquare) && board.SquareIsEmpty(targetSquare);
        }

        private bool CanMoveTwoSquaresForwards(Board board) {
            Square currentPosition = board.FindPiece(this);
            Square firstSquareForwards = currentPosition.GetRelativeSquare(AttackingDirection, 1);
            Square secondSquareForwards = firstSquareForwards.GetRelativeSquare(AttackingDirection, 1);
            return board.ContainsSquare(firstSquareForwards)
                   && board.SquareIsEmpty(firstSquareForwards)
                   && NumberOfMovesMade == 0
                   && board.ContainsSquare(secondSquareForwards)
                   && board.SquareIsEmpty(secondSquareForwards);
        }

        private IEnumerable<Square> GetAttackableSquares(Board board) {
            Square currentPosition = board.FindPiece(this);
            List<Square> potentialTargetSquares = new List<Square> {
                currentPosition.GetRelativeSquare(AttackingDirection, 1).GetRelativeSquare(Direction.Left, 1),
                currentPosition.GetRelativeSquare(AttackingDirection, 1).GetRelativeSquare(Direction.Right, 1)
            };

            return potentialTargetSquares
                .Where(board.ContainsSquare)
                .Where(square => board.GetPiece(square) != null && board.GetPiece(square).Player != this.Player);
        }

        private IEnumerable<Square> GetAnyEnPassantMoves(Board board) {
            List<Square> availableMoves = new List<Square>();

            if (board.FindPiece(this).Row != indexOfFifthRank) {
                return availableMoves;
            }

            availableMoves.AddRange(GetAnyEnPassantMoveInDirection(board, Direction.Left));
            availableMoves.AddRange(GetAnyEnPassantMoveInDirection(board, Direction.Right));

            return availableMoves;
        }

        private IEnumerable<Square> GetAnyEnPassantMoveInDirection(Board board, Direction direction) {
            Square currentPosition = board.FindPiece(this);
            Square squareBeside = currentPosition.GetRelativeSquare(direction, 1);
            Piece pieceBeside = board.GetPiece(squareBeside);

            if (OpponentPieceIsVulnerableToEnPassant(board, pieceBeside)) {
                return new List<Square> {
                    currentPosition
                        .GetRelativeSquare(AttackingDirection, 1)
                        .GetRelativeSquare(direction, 1)
                };
            }

            return new List<Square>();
        }
        
        private bool OpponentPieceIsVulnerableToEnPassant(Board board, Piece piece) {
            Square location = board.FindPiece(piece);
            return piece is Pawn
                   && piece.Player != this.Player
                   && board.PreviousMove[0].Equals(location.GetRelativeSquare(this.AttackingDirection, 2))
                   && board.PreviousMove[1].Equals(location);
        }
    }
}