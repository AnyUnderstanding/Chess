using System.Collections.Generic;

namespace ChessEngine.Pieces
{
    public class Knight : Piece
    {


        public Knight(bool isWhite) : base(isWhite)
        {
        }

        protected override List<Coordinate> getMoves(Piece[,] board, Coordinate position)
        {
            List<Coordinate> possibleMoves = new List<Coordinate>();
            return possibleMoves;
        }
    }
}