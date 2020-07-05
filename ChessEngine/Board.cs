using System;
using System.Collections.Generic;
using System.Linq;
using ChessEngine.Pieces;

namespace ChessEngine
{
    public class Board
    {
        private bool isCheck = false;
        private bool isMate = false;
        private Piece[,] board = new Piece[8, 8];
        private List<Move> moveHistory = new List<Move>();

        public Piece[,] Board1 => board;

        public Board()
        {
            createBoard();
            //  ui.printBoard(board, board[7, 7].getMoves(board, new Coordinate(7, 7), (short) moveHistory.Count));
        }

        public bool IsCheck => isCheck;

        public bool IsMate => isMate;

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
            Move possibleMove = board[move.Start.X, move.Start.Y].move(board, move, (short) moveHistory.Count);
            if (possibleMove.Start.X == -1)
            {
                return;
            }

            if (board[move.Start.X, move.Start.Y].IsWhite != ((moveHistory.Count - 1) % 2 == 0))
            {
                if (possibleMove.GetType() == typeof(CastlingMove))
                {
                    int i = possibleMove.Start.Y + (possibleMove.End.Y - possibleMove.Start.Y) / 2;
                    board[possibleMove.End.X, possibleMove.End.Y] = board[possibleMove.Start.X, possibleMove.Start.Y];
                    board[possibleMove.Start.X, possibleMove.Start.Y + (possibleMove.End.Y - possibleMove.Start.Y) / 2]
                        = board[((CastlingMove) possibleMove).Tower.X, ((CastlingMove) possibleMove).Tower.Y];
                    board[((CastlingMove) possibleMove).Tower.X, ((CastlingMove) possibleMove).Tower.Y] = null;
                    board[possibleMove.Start.X, possibleMove.Start.Y] = null;

                    moveHistory.Add(possibleMove);
                }
                else
                {
                    board[possibleMove.End.X, possibleMove.End.Y] = board[possibleMove.Start.X, possibleMove.Start.Y];
                    board[possibleMove.Start.X, possibleMove.Start.Y] = null;
                    moveHistory.Add(possibleMove);
                }
                
                isCheck = board[possibleMove.End.X, possibleMove.End.Y].isCheck(board);
                isMate = board[possibleMove.End.X, possibleMove.End.Y].isMate(board);
            }
        }

        private void createBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                // board[1, i] = new Pawn(true);
                // board[6, i] = new Pawn(false);
            }


            board[0, 0] = new Tower(true);
            board[7, 0] = new Tower(false);
            board[0, 7] = new Tower(true);
            board[7, 7] = new Tower(false);

            // board[0, 1] = new Knight(true);
            // board[7, 1] = new Knight(false);
            // board[4, 1] = new Knight(true);
            // board[7, 6] = new Knight(false);
            //
            // board[0, 2] = new Bishop(true);
            // board[7, 2] = new Bishop(false);
            // board[0, 5] = new Bishop(true);
            // board[7, 5] = new Bishop(false);

            board[0, 3] = new Queen(true);
            board[7, 3] = new Queen(false);
            board[0, 4] = new King(true);
            board[7, 4] = new King(false);
        }
    }
}