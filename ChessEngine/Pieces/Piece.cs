using System;
using System.Collections.Generic;
using System.Linq;
using ChessEngine.Pieces;

namespace ChessEngine
{
    public abstract class Piece
    {
        private bool isWhite;

        protected List<Coordinate> moves = new List<Coordinate>();
        protected short lastMoveUpdate = -1;
        protected bool hasMovedBefore = false;

        public Piece(bool isWhite)
        {
            this.isWhite = isWhite;
        }

        public bool HasMovedBefore => hasMovedBefore;


        public Move move(Piece[,] board, Move move, short currentMove)
        {
            Move possibleMove = new Move(new Coordinate(-1, -1), new Coordinate(-1, -1));
            if (currentMove != lastMoveUpdate)
            {
                moves = getMoves(board, move.Start, currentMove);
            }


            moves.ForEach(i =>
            {
                if (i.X == move.End.X && i.Y == move.End.Y)
                {
                    if (i.GetType() == typeof(CastlingCoordinate))
                    {
                        possibleMove = new CastlingMove(move.Start, move.End, ((CastlingCoordinate) i).Tower);
                    }
                    else
                    {
                        possibleMove = move;
                    }
                }
            });
            if (possibleMove.Start.X != -1)
            {
                hasMovedBefore = true;
            }

            return possibleMove;
        }

        public List<Coordinate> getMoves(Piece[,] board, Coordinate position, short currentMove)
        {
            if (lastMoveUpdate == currentMove)
            {
                return moves;
            }

            moves = removeImpossibleMoves(board, getMoves(board, position), position, isWhite);
            //moves = getMoves(board, position);
            lastMoveUpdate = currentMove;
            return moves;
        }

        protected abstract List<Coordinate> getMoves(Piece[,] board, Coordinate position);

        public bool isCheck(Piece[,] board)
        {
            (King, Coordinate) king = findKing(board, !isWhite);
            return king.Item1.isCheck(board, king.Item2);
        }

        public bool isMate(Piece[,] board)
        {
            List<Coordinate> possibleMoves = new List<Coordinate>();
            for (int r = 0; r < board.GetLength(0); r++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[r, j] == null || board[r, j].isWhite == isWhite)
                    {
                        continue;
                    }

                    Coordinate cord = new Coordinate(r, j);
                    possibleMoves = board[r, j].getMoves(board, cord);
                    int x = removeImpossibleMoves(board, possibleMoves, cord, !isWhite).Count;
                    if (removeImpossibleMoves(board, possibleMoves, cord, isWhite).Count != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        protected List<Coordinate> removeImpossibleMoves(Piece[,] board, List<Coordinate> possibleMoves,
            Coordinate position, bool kingIsWhite)
        {
            //creating simulated board of all possible moves 

            for (short index = 0; index < possibleMoves.Count; index++)
            {
                Coordinate i = possibleMoves[index];
                Piece[,] simulatedBoard = (Piece[,]) board.Clone();
                simulatedBoard[i.X, i.Y] = simulatedBoard[position.X, position.Y];
                simulatedBoard[position.X, position.Y] = null;

                (King, Coordinate) king = findKing(simulatedBoard, kingIsWhite);

                if (king.Item1.isCheck(simulatedBoard, king.Item2))
                {
                    Coordinate move = possibleMoves[index];
                    possibleMoves.RemoveAt(index);
                    index--;
                }
            }


            return possibleMoves;
        }

        private (King, Coordinate) findKing(Piece[,] board, bool kingIsWhite)
        {
            King king = null;
            Coordinate kingPosition = null;
            for (int r = 0; r < board.GetLength(0); r++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[r, j] == null)
                    {
                        continue;
                    }

                    if (board[r, j].GetType() == typeof(King) &&
                        board[r, j].IsWhite == kingIsWhite)
                    {
                        kingPosition = new Coordinate(r, j);
                        king = (King) board[r, j];
                    }
                }
            }

            return (king, kingPosition);
        }

        public bool IsWhite => isWhite;
    }
}