namespace ChessEngine
{
    public class Move
    {
        private Coordinate start;
        private Coordinate end;

        public Move(Coordinate start, Coordinate end)
        {
            this.start = start;
            this.end = end;
        }

        public Coordinate Start => start;

        public Coordinate End => end;
    }
}