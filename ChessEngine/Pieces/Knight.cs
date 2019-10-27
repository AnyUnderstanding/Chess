using System.Collections.Generic;

namespace ChessEngine.Pieces
{
    public class Knight : Piece
    {


        public Knight(bool isWhite) : base(isWhite)
        {
        }

        public override List<Coordinate> getMoves(Piece[,] board, Coordinate position, short currentMove)
        {
            throw new System.NotImplementedException();
        }
    }
}