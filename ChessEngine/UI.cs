using System;
using System.Linq;

namespace ChessEngine
{
    public class UI
    {
        public void printBoard(Piece[,] board)
        {
            for (byte i = 0; i < board.GetLength(0); i++)
            {
                for (byte j = 0; j < board.GetLength(0); j++)
                {
                    if (board[i,j]==null)
                    {
                        Console.Write(" ");
                        continue;
                    }
                   Console.Write( board[i,j].GetType().Name[0]);
                }
                Console.Write("\n");
            }
        }
    }
}