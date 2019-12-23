using System;
using System.Collections.Generic;
using System.Linq;

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

        protected bool isMate()
        {
            throw new NotImplementedException();
        }

        public bool IsWhite => isWhite;
    }
}