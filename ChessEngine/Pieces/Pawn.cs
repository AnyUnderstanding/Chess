using System;
using System.Collections.Generic;

namespace ChessEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(bool isWhite) : base(isWhite)
        {
        }

        protected override List<Coordinate> getMoves(Piece[,] board, Coordinate position)
        {
            List<Coordinate> possibleMoves = new List<Coordinate>();
            if (!board[position.X, position.Y].IsWhite)
            {
                //check if move is inside the board
                if (position.X + 1 >= board.GetLength(0))
                {
                    return possibleMoves;
                }
                //double move
                if (position.X - 2 >= 0)
                {
                    if (board[position.X - 2, position.Y] == null && !hasMovedBefore)
                    {
                        possibleMoves.Add(new Coordinate(position.X - 2, position.Y));
                    }
                }
                
                //single move
                if (board[position.X - 1, position.Y] == null)
                {
                    possibleMoves.Add(new Coordinate(position.X - 1, position.Y));
                }
                
                //capture 
                if (position.Y + 1 < board.GetLength(1))
                {
                    if (board[position.X - 1, position.Y + 1] == null)
                    {
                    }
                    else if (board[position.X - 1, position.Y + 1].IsWhite != board[position.X, position.Y].IsWhite)
                    {
                        possibleMoves.Add(new Coordinate(position.X - 1, position.Y + 1));
                    }
                }

                if (position.Y - 1 >= 0)
                {
                    if (board[position.X - 1, position.Y - 1] == null)
                    {
                    }
                    else if (board[position.X - 1, position.Y - 1].IsWhite != board[position.X, position.Y].IsWhite)
                    {
                        possibleMoves.Add(new Coordinate(position.X - 1, position.Y - 1));
                    }
                }
            }
            else
            {
                if (position.X + 1 >= board.GetLength(0))
                {
                    return possibleMoves;
                }

                if (position.X + 2 < board.GetLength(0))
                {
                    if (board[position.X + 2, position.Y] == null && !hasMovedBefore)
                    {
                        possibleMoves.Add(new Coordinate(position.X + 2, position.Y));
                    }
                }


                if (board[position.X + 1, position.Y] == null)
                {
                    possibleMoves.Add(new Coordinate(position.X + 1, position.Y));
                }

                if (position.Y + 1 < board.GetLength(1))
                {
                    if (board[position.X + 1, position.Y + 1] == null)
                    {
                    }
                    else if (board[position.X + 1, position.Y + 1].IsWhite != board[position.X, position.Y].IsWhite)
                    {
                        possibleMoves.Add(new Coordinate(position.X + 1, position.Y + 1));
                    }
                }

                if (position.Y -1>= 0)
                {
                    if (board[position.X + 1, position.Y - 1] == null)
                    {
                    }
                    else if (board[position.X + 1, position.Y - 1].IsWhite != board[position.X, position.Y].IsWhite)
                    {
                        possibleMoves.Add(new Coordinate(position.X + 1, position.Y - 1));
                    }
                }
            }

            return possibleMoves;
        }
    }
}