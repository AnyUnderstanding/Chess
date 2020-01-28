/*using System.IO;
using System.Text;

namespace ChessEngine
{
    public class BoardToJson
    {
        public static void convertToJson(Piece[,] board, short currentMove)
        {
            string[] content = new string[2];
            StringBuilder jsonfyedBoard = new StringBuilder();
            content[0] = $"{{\"currentMove\": {currentMove},\n";
            jsonfyedBoard.Append("\"board\": {\n");
            for (int i = 0; i < board.GetLength(0); i++)
            {
                jsonfyedBoard.Append($"{i}: {{");
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    
                    if (board[i, j] == null)
                    {
                    }
                    else
                    {
                        jsonfyedBoard.Append()
                    }
                }
            }
            File.WriteAllLines("board.json", content);
        }
    }
}*/