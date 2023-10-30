using System;
using System.Collections.Generic;

namespace ChessEngine
{
    public class Game
    {
        public void gameLoop()
        {
            UI ui = new UI();
            Board board = new Board();
            ui.printBoard(board.Board1, new List<Coordinate>(), board.IsCheck, board.IsMate);

            while (true)
            {
                Instruction instruction = ui.inputHandler();

                if (instruction.getType() == InstructionType.getMove)
                {
                    ui.printBoard(board.Board1,
                        board.getPossibleMoves(((GetMoveInstruction) instruction).position), board.IsCheck, board.IsMate);
                }
                else
                {
                    Move move = ((MoveInstruction) instruction).Move;
                    board.move(move);
                    ui.printBoard(board.Board1, new List<Coordinate>(), board.IsCheck, board.IsMate);
                }

                if (board.IsMate)
                {
                    break;
                }
            }

            Console.ReadKey();

        }
    }
}