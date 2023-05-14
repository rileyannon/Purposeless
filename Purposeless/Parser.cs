namespace Purposeless
{
    public static class Parser
    {
        public static readonly char[] delimiters = { '<', '>', '=', '{', '}', '+', '-', '*', '/', ';', '(', ')' };
        public static List<Token> Tokenize(string input)
        {
            List<Token> tokens = new List<Token>();

            string currToken = "";  //to keep track of current token
            int index = 0;          //keep track of current index

            while(index < input.Length)
            {
                char c = input[index];

                if (c == ' ' || c == '\n' || c == '\t')
                {
                    //CASE 1: It's a space so we skip it (and add the next token if possible)
                    if (!String.IsNullOrWhiteSpace(currToken))
                    {
                        tokens.Add(new Token(currToken));
                    }

                    currToken = "";
                }
                else if (c == '\"') {
                    //CASE 2: string/char literal
                    bool stopSearch = true;
                    index++;

                    while (stopSearch) {

                        if (input[index] == '\"' && input[index - 1] != '\\')
                        {
                            stopSearch = false;
                            index++;
                        }
                        else { 
                            currToken += input[index];
                        }

                        index++;
                    }

                    tokens.Add(new Token(currToken));
                    currToken = "";
                }
                else if (delimiters.Contains(c))
                {
                    //CASE 2: It has a delimiter (so we add the token AND the delimiter)
                    if (!String.IsNullOrWhiteSpace(currToken))
                    {
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

                index++;
            }

            return tokens;
        }

        public static string[] Parse(string input)
        {
            return input.Split(' ');
        }
    }
}
