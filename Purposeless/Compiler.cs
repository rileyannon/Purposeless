using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Purposeless
{
    public static class Compiler
    {
        public static bool Run(string fileName) { //if file is valid = true; otherwise, false
            List<Token> tokens = Parser.Tokenize(File.ReadAllText(fileName));

            for (int index = 0; index < tokens.Count; index++) {
                Console.WriteLine(tokens[index].String);
            }

            return false; //if file cannot be run
        }
    }
}
