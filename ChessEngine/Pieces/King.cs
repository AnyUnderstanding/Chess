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
                    //Y
                    if (!checkBounds((short) i, 0, (short) board.GetLength(0)) ||
                        !checkBounds((short) (translate + position.Y), 0, (short) board.GetLength(1)))
                    {
                        continue;
                    }

                    if (board[i, position.Y + translate] == null)
                    {
                        possibleMoves.Add(new Coordinate(i, position.Y + translate));
                    }
                }

                //X
                if (checkBounds((short) (translate + position.X), 0, (short) board.GetLength(1)))
                {
                    if (board[position.X + translate, position.Y] == null)
                    {
                        possibleMoves.Add(new Coordinate(position.X + translate, position.Y));
                    }
                }

             

                translate = -1;
            }

            return possibleMoves;
        }

        private bool checkBounds(short x, short lowerBound, short upperBound)
        {
            //lowerBound is included upperBound not
            return x >= lowerBound && x < upperBound;
        }

        public bool isCheck(List<Piece[,]> boards)
        {
            return false;
        }
    }
}