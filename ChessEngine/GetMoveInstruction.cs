namespace ChessEngine
{
    public class GetMoveInstruction : Instruction
    {
        public Coordinate position;
        private InstructionType type = InstructionType.getMove;

        InstructionType Instruction.getType()
        {
            return type;
        }
    }
}