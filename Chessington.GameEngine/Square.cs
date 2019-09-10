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

        public Square GetSquareByRelativePosition(Direction direction, int distance) {
            switch (direction) {
                case Direction.Up:
                    return new Square(Row - distance, Col);
                case Direction.Down:
                    return new Square(Row + distance, Col);
                case Direction.Left:
                    return new Square(Row, Col - distance);
                case Direction.Right:
                    return new Square(Row, Col + distance);
                case Direction.UpRight:
                    return new Square(Row - distance, Col + distance);
                case Direction.UpLeft:
                    return new Square(Row - distance, Col - distance);
                case Direction.DownLeft:
                    return new Square(Row + distance, Col + distance);
                case Direction.DownRight:
                    return new Square(Row + distance, Col - distance);
                default:
                    return this;
            }
        }

        public override string ToString() {
            return string.Format("Row {0}, Col {1}", Row, Col);
        }
    }
}