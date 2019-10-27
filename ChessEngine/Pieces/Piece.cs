using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessEngine
{
    public abstract class Piece
    {
        protected bool isWhite;

        protected List<Coordinate> moves = new List<Coordinate>();
        protected short lastMoveUpdate = -1;

        public Piece(bool isWhite)
        {
            this.isWhite = isWhite;
        }

        protected Coordinate position;

        public bool move(Piece[,] board, Coordinate move, short currentMove)
        {
            bool moveIsPossible = false;
            if (currentMove != lastMoveUpdate)
            {
                moves = getMoves(board, move, currentMove);
                lastMoveUpdate += currentMove;
            }

            moves.ForEach(i =>
            {
                if (i.X == move.X && i.Y == move.Y)
                    moveIsPossible = true;
            });
            return moveIsPossible;
        }

        public abstract List<Coordinate> getMoves(Piece[,] board, Coordinate position, short currentMove);

        protected bool isMate()
        {
            throw new NotImplementedException();
        }

        public bool IsWhite => isWhite;

        public Coordinate Position => position;
    }
}