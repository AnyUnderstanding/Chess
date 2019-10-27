namespace ChessEngine.Pieces
{
    public class Pawn : Piece
    {
        public override void move(Coordinate move)
        {
            throw new System.NotImplementedException();
        }

        public override Move[] getMoves()
        {
            throw new System.NotImplementedException();
        }

        public Pawn(bool isWhite) : base(isWhite)
        {
        }
    }
}