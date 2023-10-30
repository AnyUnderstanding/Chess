namespace ChessEngine
{
    public class GetMoveInstruction : Instruction
    {
        public Coordinate position;
        InstructionType Instruction.getType()
        {
            return InstructionType.getMove;
        }
    }
}