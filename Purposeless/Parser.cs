using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purposeless
{
    public static class Parser
    {
        public static readonly char[] delimiters = { '<', '>', '=', '{', '}', '+', '-', '*', '/', ';' };
        public static List<Token> Tokenize(string input) { 
            List<Token> tokens = new List<Token>();

            string currToken = "";
            foreach(char c in input)
            {
                if (c == ' ' || c == '\n') {
                    //CASE 1: It's a space so we skip it (and add the next token if possible)
                    if (!String.IsNullOrWhiteSpace(currToken)) {
                        tokens.Add(new Token(currToken));
                    }

                    currToken = "";
                }
                else if (delimiters.Contains(c))
                {
                    //CASE 2: It has a delimiter (so we add the token AND the delimiter)
                    if(!String.IsNullOrWhiteSpace(currToken)) {
                        tokens.Add(new Token(currToken));
                    }

                    tokens.Add(new Token(c.ToString()));
                    currToken = "";
                }
                else
                {
                    //CASE 3: Keep parsing bbg
                    currToken += c;
                }
            }

            return tokens;
        }

        public static string[] Parse(string input)
        {
            return input.Split(' ');
        }
    }
}
