namespace ChessEngine
{
    public class MoveInstruction : Instruction
    {
        public Move Move;
        InstructionType Instruction.getType()
        {
            return InstructionType.move;
        }
    }
}