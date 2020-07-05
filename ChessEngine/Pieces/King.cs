using System;
using System.Collections.Generic;
using System.Linq;

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

                    if (board[i, position.Y + translate] == null || board[i, position.Y + translate].IsWhite !=
                        IsWhite)
                    {
                        possibleMoves.Add(new Coordinate(i, position.Y + translate));
                    }
                }

                //X
                if (checkBounds((short) (translate + position.X), 0, (short) board.GetLength(1)))
                {
                    if (board[position.X + translate, position.Y] == null ||
                        board[position.X + translate, position.Y].IsWhite != IsWhite)
                    {
                        possibleMoves.Add(new Coordinate(position.X + translate, position.Y));
                    }
                }


                translate = -1;
            }

            possibleMoves.AddRange(castling(board, position));

            return possibleMoves;
        }

        private List<Coordinate> castling(Piece[,] board, Coordinate postion)
        {
            List<Coordinate> castleMoves = new List<Coordinate>(2);
            if (hasMovedBefore)
            {
                return castleMoves;
            }

            bool isPossible = true;
            if (board[postion.X, 7] != null && board[postion.X, 7].GetType() == typeof(Tower) &&
                board[postion.X, 7].IsWhite == IsWhite && !board[postion.X, 7].HasMovedBefore)
            {
                for (int i = postion.Y + 1; i < board.GetLength(0)-1; i++)
                {
                    if (board[postion.X, i] != null || isCheck(board, new Coordinate(postion.X, i)))
                    {
                        isPossible = false;
                        break;
                    }
                }

                if (isPossible)
                {
                    castleMoves.Add(new CastlingCoordinate(postion.X, postion.Y + 2, new Coordinate(postion.X, 7)));
                }
            }

            isPossible = true;
            if (board[postion.X, 0] != null && board[postion.X, 0].GetType() == typeof(Tower) &&
                board[postion.X, 0].IsWhite == IsWhite && !board[postion.X, 0].HasMovedBefore)
            {
                for (int i = postion.Y - 1; i >= 1; i--)
                {
                    if (board[postion.X, i] != null || isCheck(board, new Coordinate(postion.X, i)))
                    {
                        isPossible = false;
                        break;
                    }
                }

                if (isPossible)
                {
                    castleMoves.Add(new CastlingCoordinate(postion.X, postion.Y - 2, new Coordinate(postion.X, 0)));
                }
            }

            return castleMoves;
        }

        private bool checkBounds(short x, short lowerBound, short upperBound)
        {
            //lowerBound is included upperBound not
            return x >= lowerBound && x < upperBound;
        }

        public bool isCheck(Piece[,] board, Coordinate position)
        {
           
            short translate = 2;
            for (int i = 0; i < 2; i++)
            {
                short translate1 = 1;
                for (int j = 0; j < 2; j++)
                {
                    if (checkBounds((short) (position.Y + translate1), 0, (short) board.GetLength(1)) &&
                        checkBounds((short) (position.X + translate), 0, (short) board.GetLength(0)))
                    {
                        if (board[position.X + translate, position.Y + translate1] != null &&
                            board[position.X + translate, position.Y + translate1].GetType() == typeof(Knight) &&
                            board[position.X + translate, position.Y + translate1].IsWhite != IsWhite) return true;
                    }

                    if (checkBounds((short) (position.X + translate1), 0, (short) board.GetLength(1)) &&
                        checkBounds((short) (position.Y + translate), 0, (short) board.GetLength(0)))
                    {
                        if (board[position.X + translate1, position.Y + translate] != null &&
                            board[position.X + translate1, position.Y + translate].GetType() == typeof(Knight) &&
                            board[position.X + translate1, position.Y + translate].IsWhite != IsWhite)
                        {
                            return true;
                        }
                    }

                    translate1 = -1;
                }

                translate = -2;
            }


            for (short i = (short) position.X; i < board.GetLength(0); i++)
            {
                if (i == position.X || board[i, position.Y] == null)
                {
                    continue;
                }

                if (board[i, position.Y].IsWhite == IsWhite ||
                    !(board[i, position.Y].GetType() == typeof(Queen) ||
                      board[i, position.Y].GetType() == typeof(Tower)))
                {
                    break;
                }


                if (board[i, position.Y].IsWhite != IsWhite &&
                    (board[i, position.Y].GetType() == typeof(Queen) ||
                     board[i, position.Y].GetType() == typeof(Tower)))
                {
                    return true;
                }
            }

            for (short i = (short) position.X; i >= 0; i--)
            {
                if (board[i, position.Y] == null || i == position.X)
                {
                    continue;
                }

                if (board[i, position.Y].IsWhite == IsWhite ||
                    !(board[i, position.Y].GetType() == typeof(Queen) ||
                      board[i, position.Y].GetType() == typeof(Tower)))
                {
                    break;
                }


                if (board[i, position.Y].IsWhite != IsWhite &&
                    (board[i, position.Y].GetType() == typeof(Queen) ||
                     board[i, position.Y].GetType() == typeof(Tower)))
                {
                    return true;
                }
            }

            for (short i = (short) position.Y; i < board.GetLength(1); i++)
            {
                if (board[position.X, i] == null || i == position.Y)
                {
                    continue;
                }

                if (board[position.X, i].IsWhite ==IsWhite ||
                    !(board[position.X, i].GetType() == typeof(Queen) ||
                      board[position.X, i].GetType() == typeof(Tower)))
                {
                    break;
                }


                if (board[position.X, i].IsWhite != IsWhite &&
                    (board[position.X, i].GetType() == typeof(Queen) ||
                     board[position.X, i].GetType() == typeof(Tower)))
                {
                    return true;
                }
            }

            for (short i = (short) position.Y; i >= 0; i--)
            {
                if (board[position.X, i] == null || i == position.Y)
                {
                    continue;
                }

                if (board[position.X, i].IsWhite == IsWhite ||
                    !(board[position.X, i].GetType() == typeof(Queen) ||
                      board[position.X, i].GetType() == typeof(Tower)))
                {
                    break;
                }


                if (board[position.X, i].IsWhite != IsWhite &&
                    (board[position.X, i].GetType() == typeof(Queen) ||
                     board[position.X, i].GetType() == typeof(Tower)))
                {
                    return true;
                }
            }

            short translateY = (short) position.Y;

            for (short i = (short) position.X; i < board.GetLength(0); i++)
            {
                if (translateY >= board.GetLength(1))
                {
                    break;
                }

                if (i == position.X || board[i, translateY] == null)
                {
                    translateY++;
                    continue;
                }

                if (board[i, translateY].IsWhite == IsWhite ||
                    !(board[i, translateY].GetType() == typeof(Queen) ||
                      board[i, translateY].GetType() == typeof(Bishop)))
                {
                    break;
                }


                if (board[i, translateY].IsWhite != IsWhite &&
                    (board[i, translateY].GetType() == typeof(Queen) ||
                     board[i, translateY].GetType() == typeof(Bishop)))
                {
                    return true;
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

                if (i == position.X || board[i, translateY] == null)
                {
                    translateY--;
                    continue;
                }

                if (board[i, translateY].IsWhite ==IsWhite ||
                    !(board[i, translateY].GetType() == typeof(Queen) ||
                      board[i, translateY].GetType() == typeof(Bishop)))
                {
                    break;
                }


                if (board[i, translateY].IsWhite != IsWhite &&
                    (board[i, translateY].GetType() == typeof(Queen) ||
                     board[i, translateY].GetType() == typeof(Bishop)))
                {
                    return true;
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

                if (i == position.X || board[i, translateY] == null)
                {
                    translateY++;
                    continue;
                }

                if (board[i, translateY].IsWhite ==IsWhite ||
                    !(board[i, translateY].GetType() == typeof(Queen) ||
                      board[i, translateY].GetType() == typeof(Bishop)))
                {
                    break;
                }


                if (board[i, translateY].IsWhite != IsWhite &&
                    (board[i, translateY].GetType() == typeof(Queen) ||
                     board[i, translateY].GetType() == typeof(Bishop)))
                {
                    return true;
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

                if (i == position.X || board[i, translateY] == null)
                {
                    translateY--;
                    continue;
                }

                if (board[i, translateY].IsWhite == IsWhite ||
                    !(board[i, translateY].GetType() == typeof(Queen) ||
                      board[i, translateY].GetType() == typeof(Bishop)))
                {
                    break;
                }


                if (board[i, translateY].IsWhite != IsWhite &&
                    (board[i, translateY].GetType() == typeof(Queen) ||
                     board[i, translateY].GetType() == typeof(Bishop)))
                {
                    return true;
                }


                translateY--;
            }

            if (position.X == 6 && position.Y == 4)
            {
                Console.WriteLine(1);
            }

            translate = (short) (position.X + (IsWhite ? 1 : -1));
            if (position.Y + 1 < board.GetLength(0) && board[translate, position.Y + 1] != null &&
                board[translate, position.Y + 1].GetType() == typeof(Pawn) &&
                board[translate, position.Y + 1].IsWhite != IsWhite)
            {
                return true;
            }

            if (position.Y - 1 >= 0 && board[translate, position.Y - 1] != null &&
                board[translate, position.Y - 1].GetType() == typeof(Pawn) &&
                board[translate, position.Y - 1].IsWhite != IsWhite)
            {
                return true;
            }

            return false;
        }
    }
}