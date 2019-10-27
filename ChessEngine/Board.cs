using System;
using System.Collections.Generic;
using System.Linq;
using ChessEngine.Pieces;

namespace ChessEngine
{
    public class Board
    {
        public Board()
        {
            createBoard();
        }
        private Piece[,] board = new Piece[8,8];
        private List<Move> moveHistory = new List<Move>();

        private void move(Move move)
        {
            Coordinate coordinate = move.Start;
            board[coordinate.X,coordinate.Y].move(move.End);
        }
        
        private void createBoard()
        {
            for (int i = 0; i < board.Length; i++)
            {
                board[1,i] = new Pawn(true);
                board[6,i] = new Pawn(false);
            }
            
            board[0,0] = new Tower(true);
            board[7,0] = new Tower(false);
            board[0,7] = new Tower(true);
            board[7,7] = new Tower(false);
            
            board[0,1] = new Knight(true);
            board[7,1] = new Knight(false);
            board[0,6] = new Knight(true);
            board[7,6] = new Knight(false);
            
            board[0,2] = new Bishop(true);
            board[7,2] = new Bishop(false);
            board[0,5] = new Bishop(true);
            board[7,5] = new Bishop(false);
            
            board[0,3] = new Queen(true);
            board[7,3] = new Queen(false);
            board[0,4] = new King(true);
            board[7,4] = new King(false);
            
        }
    }
}