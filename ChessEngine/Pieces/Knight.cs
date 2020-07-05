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
            short translate = 2;
            for (int i = 0; i < 2; i++)
            {
                short translate1 = 1;
                for (int j = 0; j < 2; j++)
                {
                    if (checkBounds((short) (position.Y + translate1), 0, (short) board.GetLength(1)) &&
                        checkBounds((short) (position.X + translate), 0, (short) board.GetLength(0)))
                    {
                        if (board[position.X + translate, position.Y + translate1] == null)
                        {
                            possibleMoves.Add(new Coordinate(position.X + translate, position.Y + translate1));
                        }
                        else if (board[position.X + translate, position.Y + translate1].IsWhite !=
                                 IsWhite)
                        {
                            possibleMoves.Add(new Coordinate(position.X + translate, position.Y + translate1));
                        }
                    }

                    if (checkBounds((short) (position.X + translate1), 0, (short) board.GetLength(1)) &&
                        checkBounds((short) (position.Y + translate), 0, (short) board.GetLength(0)))
                    {
                        if (board[position.X + translate1, position.Y + translate] == null)
                        {
                            possibleMoves.Add(new Coordinate(position.X + translate1, position.Y + translate));
                        }
                        else if (board[position.X + translate1, position.Y + translate].IsWhite !=
                                 IsWhite) 
                        {
                            possibleMoves.Add(new Coordinate(position.X + translate1, position.Y + translate));
                        }
                    }

                    translate1 = -1;
                }

                translate = -2;
            }


            return possibleMoves;
        }


        private bool checkBounds(short x, short lowerBound, short upperBound)
        {
            //lowerBound is included upperBound not
            return x >= lowerBound && x < upperBound;
        }
    }
}