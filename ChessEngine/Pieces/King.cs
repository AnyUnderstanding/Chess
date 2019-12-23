using System.Collections.Generic;

namespace ChessEngine.Pieces
{
    public class King : Piece
    {
        public King(bool isWhite) : base(isWhite)
        {
        }

        protected override List<Coordinate> getMoves(Piece[,] board, Coordinate position)
        {
            List<Coordinate> possibleMoves = new List<Coordinate>();
            short translate = 1;
            for (int j = 0; j < 2; j++)
            {
                for (int i = position.X - 1; i <= position.X + 1; i++)
                {
                    if (i < 0 || i >= board.GetLength(0))
                    {
                        continue;
                    }
                    if (board[i, position.Y + translate] == null)
                    {
                        possibleMoves.Add(new Coordinate(i, position.Y));
                    }
                    else if (board[i, position.Y].IsWhite == board[position.X, position.Y].IsWhite)
                    {
                        break;
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinate(i, position.Y));
                        break;
                    }
                }

                translate = -1;
            }

            return possibleMoves;
        }
    }
}