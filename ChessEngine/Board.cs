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
            UI ui = new UI();
            ui.printBoard(board, new List<Coordinate>());
            move(new Move(new Coordinate(7,7),new Coordinate(4,7)));
            ui.printBoard(board, new List<Coordinate>());
          //  ui.printBoard(board, board[0, 7].getMoves(board, new Coordinate(0, 7), (short) moveHistory.Count));


        }

        private Piece[,] board = new Piece[8, 8];
        private List<Move> moveHistory = new List<Move>();

        private void move(Move move)
        {
            if (board[move.Start.X, move.Start.Y].move(board, move.End, (short) moveHistory.Count))
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
                break;
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