namespace ChessEngine
{
    public class Coordinate
    {
        private int x;
        private int y;

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X => x;

        public int Y => y;
    }
}