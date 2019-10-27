namespace ChessEngine.Pieces
{
    public class King : Piece
    {
        public override void move(Coordinate move)
        {
            throw new System.NotImplementedException();
        }

        public override Move[] getMoves()
        {
            throw new System.NotImplementedException();
        }

        public King(bool isWhite) : base(isWhite)
        {
        }
    }
}