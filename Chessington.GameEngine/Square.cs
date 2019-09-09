namespace Chessington.GameEngine {
    public struct Square {
        public readonly int Row;
        public readonly int Col;

        private Square(int row, int col) {
            Row = row;
            Col = col;
        }

        public static Square At(int row, int col) {
            return new Square(row, col);
        }

        public bool Equals(Square other) {
            return Row == other.Row && Col == other.Col;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Square && Equals((Square) obj);
        }

        public override int GetHashCode() {
            unchecked {
                return (Row * 397) ^ Col;
            }
        }

        public static bool operator ==(Square left, Square right) {
            return left.Equals(right);
        }

        public static bool operator !=(Square left, Square right) {
            return !left.Equals(right);
        }

        public Square NextSquare(Direction direction) {
            if (direction == Direction.UP) {
                return new Square(Row - 1, Col);
            }
            if (direction == Direction.DOWN) {
                return new Square(Row + 1, Col);
            }
            if (direction == Direction.LEFT) {
                return new Square(Row, Col - 1);
            }
            if (direction == Direction.RIGHT) {
                return new Square(Row, Col + 1);
            }

            return this;
        }

        public override string ToString() {
            return string.Format("Row {0}, Col {1}", Row, Col);
        }
    }
}