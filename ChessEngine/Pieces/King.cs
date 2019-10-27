using System.Collections.Generic;

namespace ChessEngine.Pieces
{
    public class King : Piece
    {

        public King(bool isWhite) : base(isWhite)
        {
        }

        public override List<Coordinate> getMoves(Piece[,] board, Coordinate position, short currentMove)
        {
            throw new System.NotImplementedException();
        }
    }
}