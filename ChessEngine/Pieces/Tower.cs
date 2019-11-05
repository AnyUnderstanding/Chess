using System;
using System.Linq;
using System.Collections.Generic;

namespace ChessEngine.Pieces
{
    public class Tower : Piece
    {
        public override List<Coordinate> getMoves(Piece[,] board, Coordinate position, short currentMove)
        {
            if (currentMove == lastMoveUpdate)
            {
                return moves;
            }

            List<Coordinate> possibleMoves = new List<Coordinate>();
            if (board[position.X, position.Y] == null) return possibleMoves;

            //  if (isMate()) return possibleMoves;

            for (byte i = (byte) position.X; i < board.GetLength(0); i++)
            {
                if (i == position.Y)
                {
                    continue;
                }

                if (board[position.X, i] == null)
                {
                    possibleMoves.Add(new Coordinate(position.Y, i));
                }
                else if (board[position.X, i].IsWhite != isWhite)
                {
                    possibleMoves.Add(new Coordinate(position.Y, i));
                    break;
                }
                else if (board[position.X, i].IsWhite == isWhite)
                {
                    break;
                }
            }


            for (byte i = (byte) position.Y; i < board.GetLength(1); i++)
            {
                if (i == position.X)
                {
                    continue;
                }

                if (board[i, position.Y] == null)
                {
                    possibleMoves.Add(new Coordinate(i, position.Y));
                }
                else if (board[i, position.Y].IsWhite != isWhite)
                {
                    possibleMoves.Add(new Coordinate(i, position.Y));
                    break;
                }
                else if (board[i, position.Y].IsWhite == isWhite)
                {
                    break;
                }
            }


            for (byte i = (byte) position.X; i > 0; i--)
            {
                if (i == position.Y)
                {
                    continue;
                }

                if (board[position.X, i] == null)
                {
                    possibleMoves.Add(new Coordinate(position.Y, i));
                }
                else if (board[position.X, i].IsWhite != isWhite)
                {
                    possibleMoves.Add(new Coordinate(position.Y, i));
                    break;
                }
                else if (board[position.X, i].IsWhite == isWhite)
                {
                    break;
                }
            }


            for (byte i = (byte) position.Y; i > 0; i--)
            {
                if (i == position.X)
                {
                    continue;
                }

                if (board[i, position.Y] == null)
                {
                    possibleMoves.Add(new Coordinate(i, position.Y));
                }
                else if (board[i, position.Y].IsWhite != isWhite)
                {
                    possibleMoves.Add(new Coordinate(i, position.Y));
                    break;
                }
                else if (board[i, position.Y].IsWhite == isWhite)
                {
                    break;
                }
            }

            lastMoveUpdate = currentMove;
            moves = possibleMoves;
            return possibleMoves;
        }

        public Tower(bool isWhite) : base(isWhite)
        {
        }
    }
}