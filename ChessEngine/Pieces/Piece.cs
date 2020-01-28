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

            moves = getMoves(board, position);
            lastMoveUpdate = currentMove;
            return moves;
        }

        protected abstract List<Coordinate> getMoves(Piece[,] board, Coordinate position);

        protected bool isMate(Piece[,] board,List<Coordinate> possibleMoves,Coordinate position)
        {
            //searching king
            King king = null;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j].GetType() == typeof(King) && board[i, j].IsWhite == isWhite)
                    {
                        king = (King) board[i, j];
                    }
                }
            }
            //creating simulated of possible moves board
            possibleMoves.ForEach(i =>
            {
                Piece[,] simulatedBoard = board;
                simulatedBoard[i.X, i.Y] = simulatedBoard[position.X, position.Y];
                simulatedBoard[position.X, position.Y] = null;
            });
            return true;
        }

        public bool IsWhite => isWhite;
    }
}