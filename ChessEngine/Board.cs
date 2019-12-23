using System;
using System.Collections.Generic;
using System.Linq;
using ChessEngine.Pieces;

namespace ChessEngine
{
    public class Board
    {
        private Piece[,] board = new Piece[8, 8];
        private List<Move> moveHistory = new List<Move>();

        public Piece[,] Board1 => board;

        public Board()
        {
            createBoard();

            //  ui.printBoard(board, board[7, 7].getMoves(board, new Coordinate(7, 7), (short) moveHistory.Count));
        }

        public List<Coordinate> getPossibleMoves(Coordinate position)
        {
            if (board[position.X, position.Y] == null ||
                board[position.X, position.Y].IsWhite == ((moveHistory.Count - 1) % 2 == 0))

            {
                return new List<Coordinate>();
            }

            return board[position.X, position.Y].getMoves(board, position, (short) moveHistory.Count);
        }

        public void move(Move move)
        {
            if (board[move.Start.X, move.Start.Y].move(board, move, (short) moveHistory.Count)&&board[move.Start.X, move.Start.Y].IsWhite != ((moveHistory.Count - 1) % 2 == 0))
            {
                board[move.End.X, move.End.Y] = board[move.Start.X, move.Start.Y];
                board[move.Start.X, move.Start.Y] = null;
                moveHistory.Add(move);
            }
            else
            {
                Console.WriteLine("\nImpossible move l2p");
            }
        }

        private void createBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                board[1, i] = new Pawn(true);
                board[6, i] = new Pawn(false);
            }

            board[0, 0] = new Tower(true);
            board[7, 0] = new Tower(false);
            board[0, 7] = new Tower(true);
            board[7, 7] = new Tower(false);

            board[0, 1] = new Knight(true);
            board[7, 1] = new Knight(false);
            board[0, 6] = new Knight(true);
            board[7, 6] = new Knight(false);

            board[0, 2] = new Bishop(true);
            board[7, 2] = new Bishop(false);
            board[0, 5] = new Bishop(true);
            board[7, 5] = new Bishop(false);

            board[0, 3] = new Queen(true);
            board[7, 3] = new Queen(false);
            board[0, 4] = new King(true);
            board[7, 4] = new King(false);
        }
    }
}