namespace ChessEngine.Pieces
{
    public class Queen : Piece

    {
        public override void move(Coordinate move)
        {
            throw new System.NotImplementedException();
        }

        public override Move[] getMoves()
        {
            throw new System.NotImplementedException();
        }

        public Queen(bool isWhite) : base(isWhite)
        {
        }
    }
}