using System.Collections.Generic;

namespace ChessEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(bool isWhite) : base(isWhite)
        {
        }

        public override List<Coordinate> getMoves(Piece[,] board, Coordinate position, short currentMove)
        {
            byte translate = 0;
            List<Coordinate> possibleMoves = new List<Coordinate>();
            Piece currentPiece = board[position.X, position.Y];
            for (byte i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, translate] == null)possibleMoves.Add(new Coordinate(i,translate));
            }

            return possibleMoves;
        }
    }
}