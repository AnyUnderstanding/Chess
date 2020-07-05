using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ChessEngine.Pieces;

namespace ChessEngine
{
    public class UI
    {
        private short x = 1;
        private short y = 1;
        private bool isMove = false;
        private Coordinate start;

        private Dictionary<Type, char> whitePieces = new Dictionary<Type, char>();
        private Dictionary<Type, char> blackPieces = new Dictionary<Type, char>();

        public UI()
        {
            whitePieces.Add(typeof(Tower), '♖');
            blackPieces.Add(typeof(Tower), '♜');

            whitePieces.Add(typeof(Knight), '♘');
            blackPieces.Add(typeof(Knight), '♞');

            whitePieces.Add(typeof(Bishop), '♗');
            blackPieces.Add(typeof(Bishop), '♝');

            whitePieces.Add(typeof(Queen), '♕');
            blackPieces.Add(typeof(Queen), '♛');

            whitePieces.Add(typeof(King), '♔');
            blackPieces.Add(typeof(King), '♚');

            whitePieces.Add(typeof(Pawn), '♙');
            blackPieces.Add(typeof(Pawn), '♟');
        }

        public void printBoard(Piece[,] pBoard, List<Coordinate> pM)
        {
            /*
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
                        pM.ForEach(pm => Console.Write(pm+"\n"));
                        pM.ForEach(pm => { sb[pm.Y * 18 + pm.X * 2+1] = '+'; });
                        
                        Console.WriteLine(sb+"\n---------------------------");*/
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("White");
            Console.ForegroundColor = ConsoleColor.Gray;
            bool isWhiteSquare = false;

            for (int i = 0; i < 8; i++)
            {
                isWhiteSquare = !isWhiteSquare;

                for (int j = 0; j < 8; j++)
                {
                    Console.Write("|");
                    if (isWhiteSquare)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    isWhiteSquare = !isWhiteSquare;
                    bool cont = false;
                    pM.ForEach(e =>
                    {
                        if (i == e.X && j == e.Y)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("+");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            cont = true;
                        }
                    });
                    if (cont)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        continue;
                    }

                    if (pBoard[i, j] == null)
                    {
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Black;

                        continue;
                    }

                    if (pBoard[i, j].IsWhite)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    if (pBoard[i, j].IsWhite)
                    {
                    }

                    Console.Write(pBoard[i, j].IsWhite
                        ? whitePieces[pBoard[i, j].GetType()]
                        : blackPieces[pBoard[i, j].GetType()]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.Write("|\n");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Black\n");
            Console.WriteLine(Convert.ToString((x - 1) / 2) + "|" + Convert.ToString(y - 1));
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public Instruction inputHandler()
        {
            Coordinate cursor = getCursorPos();
            GetMoveInstruction instruction = new GetMoveInstruction();
            if (isMove)
            {
                MoveInstruction moveInstruction = new MoveInstruction();
                Coordinate end = getCursorPos();
                if (end == null)
                {
                    instruction.position = cursor;
                    return instruction;
                }

                moveInstruction.Move = new Move(cursor, end);
                return moveInstruction;
            }

            instruction.position = cursor;
            return instruction;
        }

        public Coordinate getCursorPos()
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            while (true)
            {
                Console.SetCursorPosition(x, y);

                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        y--;
                        if (!checkBounds((short) (y - 1), 0, 8)) y++;

                        break;
                    case ConsoleKey.DownArrow:
                        y++;
                        if (!checkBounds((short) (y - 1), 0, 8)) y--;

                        break;
                    case ConsoleKey.LeftArrow:
                        x -= 2;
                        if (!checkBounds((short) ((x - 1) / 2), 0, 8)) x += 2;

                        break;
                    case ConsoleKey.RightArrow:
                        x += 2;
                        if (!checkBounds((short) ((x - 1) / 2), 0, 8)) x -= 2;
                        break;
                    case ConsoleKey.M:
                        isMove = !isMove;

                        if (!isMove)
                        {
                            return null;
                        }
                        else
                        {
                            return new Coordinate(y - 1, (x - 1) / 2);
                        }

                    case ConsoleKey.Enter:
                        if (isMove)
                        {
                            isMove = false;
                            return new Coordinate(y - 1, (x - 1) / 2);
                        }

                        break;
                }


                if (!isMove)
                {
                    return new Coordinate(y - 1, (x - 1) / 2);
                }
            }
        }

        private bool checkBounds(short x, short lowerBound, short upperBound)
        {
            //lowerBound is included upperBound not
            return x >= lowerBound && x < upperBound;
        }
    }
}