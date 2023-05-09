namespace Purposeless
{
    public static class Compiler
    {
        public static bool Run(string fileName)
        { //if file is valid = true; otherwise, false

            if (!File.Exists(fileName)) return false;

            List<Token> tokens = Parser.Tokenize(File.ReadAllText(fileName));

            for (int index = 0; index < tokens.Count; index++)
            {
                Console.WriteLine(tokens[index].String);
            }

            return true; //if file can be run
        }
    }
}
