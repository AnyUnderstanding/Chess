namespace ChessEngine
{
    public class CastlingMove : Move
    {
        private Coordinate start;
        private Coordinate end;
        private Coordinate tower;

        public CastlingMove(Coordinate start, Coordinate end,Coordinate tower) : base(start, end)
        {
            this.start = start;
            this.end = end;
            this.tower = tower;
        }

        public Coordinate Start1 => start;

        public Coordinate End1 => end;

        public Coordinate Tower => tower;
    }
}