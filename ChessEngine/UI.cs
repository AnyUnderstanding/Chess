using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessEngine
{
    public class UI
    {
        public void printBoard(Piece[,] pBoard, List<Coordinate> pM)
        {
            StringBuilder sb = new StringBuilder("|_|@|_|@|_|@|_|@|\n" +
                                                 "|@|_|@|_|@|_|@|_|\n" +
                                                 "|_|@|_|@|_|@|_|@|\n" +
                                                 "|@|_|@|_|@|_|@|_|\n" +
                                                 "|_|@|_|@|_|@|_|@|\n" +
                                                 "|@|_|@|_|@|_|@|_|\n" +
                                                 "|_|@|_|@|_|@|_|@|\n" +
                                                 "|@|_|@|_|@|_|@|_|");
            for (int x = 0; x < pBoard.GetLength(0); x++)
            {
                for (int y = 0; y < pBoard.GetLength(1); y++)
                {
                    if (pBoard[x,y] != null)
                        sb[y*18+x*2+1] = pBoard[x,y].GetType().Name[0];
                }
            }

            pM.ForEach(pm => { sb[pm.Y * 18 + pm.X * 2+1] = '+'; });
            
            Console.WriteLine(sb+"\n---------------------------");
        }
    }
}