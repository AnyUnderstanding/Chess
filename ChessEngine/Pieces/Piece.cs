using System;
using System.Collections.Generic;

namespace ChessEngine
{
    public abstract class Piece
    {
        protected bool isWhite;

        public Piece(bool isWhite)
        {
            this.isWhite = isWhite;
        }

        protected Coordinate position;
        public abstract void move(Coordinate move);
        public abstract List<Coordinate> getMoves(Piece[,] board,Coordinate position);

        protected bool isMate()
        {
            throw new NotImplementedException();
        }
        
        public bool IsWhite => isWhite;

        public Coordinate Position => position;
    }
}