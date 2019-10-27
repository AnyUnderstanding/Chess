using System;
using System.Linq;
using System.Collections.Generic;

namespace ChessEngine.Pieces
{
    public class Tower : Piece
    {
        public override void move(Coordinate move)
        {
            throw new System.NotImplementedException();
        }

        public override List<Coordinate> getMoves(Piece[,] board, Coordinate position)
        {
            List<Coordinate> possibleMoves = new List<Coordinate>();
            Piece currentPiece = board[position.X, position.Y];
            if (isMate()) return possibleMoves;

            for (int i = 0; i < board.Length; i++)
            {
                if (i == position.Y)
                {
                    continue;
                }

                if (board[position.X, i] == null)
                {
                    possibleMoves.Add(new Coordinate(position.Y, i));
                }
                else if (board[position.X, i].IsWhite != currentPiece.IsWhite)
                {
                    possibleMoves.Add(new Coordinate(position.Y, i));
                    break;
                }
                else if (board[position.X, i].IsWhite == currentPiece.IsWhite)
                {
                    break;
                }
            }
            
            
            for (int i = 0; i < board.Length; i++)
            {
                if (i == position.X)
                {
                    continue;
                }

                if (board[i, position.Y] == null)
                {
                    possibleMoves.Add(new Coordinate(i, position.Y));
                }
                else if (board[i, position.Y].IsWhite != currentPiece.IsWhite)
                {
                    possibleMoves.Add(new Coordinate(i, position.Y));
                    break;
                }
                else if (board[i, position.Y].IsWhite == currentPiece.IsWhite)
                {
                    break;
                }
            }

            return possibleMoves;
        }

        public Tower(bool isWhite) : base(isWhite)
        {
        }
    }
}