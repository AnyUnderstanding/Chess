namespace ChessEngine
{
    public class MoveInstruction : Instruction
    {
        public Move Move;
        private InstructionType type = InstructionType.move;

        InstructionType Instruction.getType()
        {
            return type;
        }
    }
}