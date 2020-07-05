using ChessEngine.Pieces;

namespace ChessEngine
{
    public class CastlingCoordinate : Coordinate
    {
        private Coordinate tower;
        public CastlingCoordinate(int x, int y, Coordinate tower) : base(x, y)
        {
            this.tower = tower;
        }

        public Coordinate Tower => tower;
    }
}