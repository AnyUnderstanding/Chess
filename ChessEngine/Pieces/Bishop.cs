using System.Collections.Generic;

namespace ChessEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(bool isWhite) : base(isWhite)
        {
        }

        protected override List<Coordinate> getMoves(Piece[,] board, Coordinate position)
        {
            List<Coordinate> possibleMoves = new List<Coordinate>();
            short translateY = (short) position.Y;

            for (short i = (short) position.X; i < board.GetLength(0); i++)
            {
                if (translateY >= board.GetLength(1))
                {
                    break;
                }

                if (i == position.X)
                {
                    translateY++;
                    continue;
                }

                if (board[i, translateY] == null)
                {
                    possibleMoves.Add(new Coordinate(i, translateY));
                }
                else if (board[i, translateY].IsWhite == IsWhite)
                {
                    break;
                }
                else
                {
                    possibleMoves.Add(new Coordinate(i, translateY));
                    break;
                }

                translateY++;
            }

            translateY = (short) position.Y;
            for (short i = (short) position.X; i < board.GetLength(0); i++)
            {
                if (translateY < 0)
                {
                    break;
                }

                if (i == position.X)
                {
                    translateY--;
                    continue;
                }

                if (board[i, translateY] == null)
                {
                    possibleMoves.Add(new Coordinate(i, translateY));
                }
                else if (board[i, translateY].IsWhite == IsWhite)
                {
                    break;
                }
                else
                {
                    possibleMoves.Add(new Coordinate(i, translateY));
                    break;
                }

                translateY--;
            }

            translateY = (short) position.Y;
            for (short i = (short) position.X; i >= 0; i--)
            {
                if (translateY >= board.GetLength(1))
                {
                    break;
                }

                if (i == position.X)
                {
                    translateY++;
                    continue;
                }

                if (board[i, translateY] == null)
                {
                    possibleMoves.Add(new Coordinate(i, translateY));
                }
                else if (board[i, translateY].IsWhite == IsWhite)
                {
                    break;
                }
                else
                {
                    possibleMoves.Add(new Coordinate(i, translateY));
                    break;
                }

                translateY++;
            }

            translateY = (short) position.Y;
            for (short i = (short) position.X; i >= 0; i--)
            {
                if (translateY < 0)
                {
                    break;
                }

                if (i == position.X)
                {
                    translateY--;
                    continue;
                }

                if (board[i, translateY] == null)
                {
                    possibleMoves.Add(new Coordinate(i, translateY));
                }
                else if (board[i, translateY].IsWhite == IsWhite)
                {
                    break;
                }
                else
                {
                    possibleMoves.Add(new Coordinate(i, translateY));
                    break;
                }

                translateY--;
            }

            moves = possibleMoves;
            return possibleMoves;
        }
    }
}