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


        public bool move(Piece[,] board, Move move, short currentMove)
        {
            bool moveIsPossible = false;
            if (currentMove != lastMoveUpdate)
            {
                moves = getMoves(board, move.Start, currentMove);
            }

            moves.ForEach(i =>
            {
                if (i.X == move.End.X && i.Y == move.End.Y)
                    moveIsPossible = true;
            });
            if (moveIsPossible)
            {
                hasMovedBefore = true;
            }

            return moveIsPossible;
        }

        public List<Coordinate> getMoves(Piece[,] board, Coordinate position, short currentMove)
        {
            if (lastMoveUpdate == currentMove)
            {
                return moves;
            }

            moves = isMate(board, getMoves(board, position), position);
            //moves = getMoves(board, position);
            lastMoveUpdate = currentMove;
            return moves;
        }

        protected abstract List<Coordinate> getMoves(Piece[,] board, Coordinate position);

        protected List<Coordinate> isMate(Piece[,] board, List<Coordinate> possibleMoves, Coordinate position)
        {
            //creating simulated board of all possible moves 

            for (short index = 0; index < possibleMoves.Count; index++)
            {
                Coordinate i = possibleMoves[index];
                Piece[,] simulatedBoard = (Piece[,]) board.Clone();
                simulatedBoard[i.X, i.Y] = simulatedBoard[position.X, position.Y];
                simulatedBoard[position.X, position.Y] = null;
                //searching king
                King king = null;
                Coordinate kingPosition = null;
                for (int r = 0; r < simulatedBoard.GetLength(0); r++)
                {
                    for (int j = 0; j < simulatedBoard.GetLength(1); j++)
                    {
                        if (simulatedBoard[r, j] == null)
                        {
                            continue;
                        }

                        if (simulatedBoard[r, j].GetType() == typeof(King) &&
                            simulatedBoard[r, j].IsWhite == isWhite)
                        {
                            king = (King) simulatedBoard[r, j];
                            kingPosition = new Coordinate(r, j);
                        }
                    }
                }

                if (king.isCheck(simulatedBoard, kingPosition))
                {
                    Coordinate move = possibleMoves[index];
                    Console.WriteLine(move.X + "-/-" + move.Y);
                    possibleMoves.RemoveAt(index);
                    index--;
                }
            }


            return possibleMoves;
        }

        public bool IsWhite => isWhite;
    }
}