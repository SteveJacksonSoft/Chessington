using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece {
        protected readonly Direction AttackingDirection;
        public bool HasMoved { protected get; set; }
        
        protected Piece(Player player)
        {
            Player = player;
            AttackingDirection = player == Player.White ? Direction.Up : Direction.Down;
        }

        public Player Player { get; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }
    }
}