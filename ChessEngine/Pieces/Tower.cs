using System;
using System.Linq;
using System.Collections.Generic;

namespace ChessEngine.Pieces
{
    public class Tower : Piece
    {
        protected override List<Coordinate> getMoves(Piece[,] board, Coordinate position)
        {
            List<Coordinate> possibleMoves = new List<Coordinate>();

            //  if (isMate()) return possibleMoves;


            for (short i = (short) position.X; i < board.GetLength(0); i++)
            {
                if (i == position.X)
                {
                    continue;
                }

                if (board[i, position.Y] == null)
                {
                    possibleMoves.Add(new Coordinate(i, position.Y));
                }
                else if (board[i, position.Y].IsWhite == IsWhite)
                {
                    break;
                }
                else
                {
                    possibleMoves.Add(new Coordinate(i, position.Y));
                    break;
                }
            }

            for (short i = (short) position.X; i >= 0; i--)
            {
                if (i == position.X)
                {
                    continue;
                }

                if (board[i, position.Y] == null)
                {
                    possibleMoves.Add(new Coordinate(i, position.Y));
                }
                else if (board[i, position.Y].IsWhite == IsWhite)
                {
                    break;
                }
                else
                {
                    possibleMoves.Add(new Coordinate(i, position.Y));
                    break;
                }
            }

            for (short i = (short) position.Y; i < board.GetLength(1); i++)
            {
                if (i == position.Y)
                {
                    continue;
                }

                if (board[position.X, i] == null)
                {
                    possibleMoves.Add(new Coordinate(position.X, i));
                }
                else if (board[position.X, i].IsWhite == IsWhite)
                {
                    break;
                }
                else
                {
                    possibleMoves.Add(new Coordinate(position.X, i));
                    break;
                }
            }

            for (short i = (short) position.Y; i >= 0; i--)
            {
                if (i == position.Y)
                {
                    continue;
                }

                if (board[position.X, i] == null)
                {
                    possibleMoves.Add(new Coordinate(position.X, i));
                }
                else if (board[position.X, i].IsWhite == IsWhite)
                {
                    break;
                }
                else
                {
                    possibleMoves.Add(new Coordinate(position.X, i));
                    break;
                }
            }

            moves = possibleMoves;
            return possibleMoves;
        }

        public Tower(bool isWhite) : base(isWhite)
        {
        }
    }
}