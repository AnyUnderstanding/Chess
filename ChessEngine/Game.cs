using System;
using System.Collections.Generic;

namespace ChessEngine
{
    public class Game
    {
        public void GameLoop()
        {
            UI ui = new UI();
            Board board = new Board();
            ui.printBoard(board.Board1, new List<Coordinate>());

            while (true)
            {
                Instruction iNstruction = ui.inputHandler();

                if (iNstruction.getType() == InstructionType.getMove)
                {
                    ui.printBoard(board.Board1, board.getPossibleMoves(((GetMoveInstruction) iNstruction).position));
                }
                else
                {
                    Move move = ((MoveInstruction) iNstruction).Move;
                    board.move(move);
                    ui.printBoard(board.Board1, new List<Coordinate>());
                    Console.WriteLine(move.Start.X + "," + move.Start.Y + "|" + move.End.X + "," + move.End.Y);
                }
            }

            Console.ReadKey();
        }
    }
}