namespace ChessEngine
{
    public class CastlingMove : Move
    {
        private Coordinate tower;

        public CastlingMove(Coordinate start, Coordinate end,Coordinate tower) : base(start, end)
        {
            this.tower = tower;
        }
        

        public Coordinate Tower => tower;
    }
}