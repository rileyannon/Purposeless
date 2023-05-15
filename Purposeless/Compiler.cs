namespace Purposeless
{
    public class Compiler
    {
        Stack<int> leftParTokens = new Stack<int>();
        Queue<int> rightParTokens = new Queue<int>();

        public static bool Run(string fileName)
        { //if file is valid = true; otherwise, false

            if (!File.Exists(fileName)) return false;   //can't find file so we stop the program

            List<Token> tokens = Parser.Tokenize(File.ReadAllText(fileName));

            for (int index = 0; index < tokens.Count; index++)
            {
                //Console.WriteLine(tokens[index].String);
            }

            Parser.Parse(tokens);

            return true; //if file can be run
        }
    }
}
