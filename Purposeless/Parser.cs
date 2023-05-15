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

                    tokens.Add(new Token(currToken, TokenType.STRING_LITERAL));
                    currToken = "";
                }
                else if (delimiters.Contains(c))
                {
                    //CASE 2: It has a delimiter (so we add the token AND the delimiter)
                    if (!String.IsNullOrWhiteSpace(currToken))
                    {
                        tokens.Add(new Token(currToken));
                    }

                    tokens.Add(new Token(c.ToString(), TokenType.OPERATOR));
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

        public static void Parse(List<Token> tokens)
        {
            List<Variable> variables = new List<Variable>();
            int tokenIndex = 0;

            while (tokenIndex < tokens.Count)
            {
                if (tokens[tokenIndex].TokenType == TokenType.INT_KEYWORD)
                {
                    Variable v = new Variable();
                    v.Identifier = tokens[tokenIndex + 1].String;
                    v.Type = VariableType.INT;

                    //CASE: DECLARATION IS DEFINITION
                    if (tokens[tokenIndex + 2].String == "=")
                    {

                        if (int.TryParse(tokens[tokenIndex + 3].String, out int n))
                        {
                            v.intVal = n;
                        }
                        else
                        {

                            foreach (Variable var in variables)
                            {

                                if (var.Identifier == tokens[tokenIndex + 3].String && var.Type == VariableType.INT)
                                {
                                    v.intVal = var.intVal;
                                    break;
                                }

                            }

                        }

                    }

                    variables.Add(v);
                }
                else if (tokens[tokenIndex].TokenType == TokenType.DOUBLE_KEYWORD)
                {
                    Variable v = new Variable();
                    v.Identifier = tokens[tokenIndex + 1].String;
                    v.Type = VariableType.DOUBLE;

                    if (tokens[tokenIndex + 2].String == "=")
                    {
                        v.doubleVal = double.Parse(tokens[tokenIndex + 3].String);
                    }

                    variables.Add(v);
                }
                else if (tokens[tokenIndex].TokenType == TokenType.STRING_KEYWORD)
                {
                    Variable v = new Variable();
                    v.Identifier = tokens[tokenIndex + 1].String;
                    v.Type = VariableType.STRING;

                    if (tokens[tokenIndex + 3].TokenType == TokenType.STRING_LITERAL) {
                        v.StringVal = tokens[tokenIndex + 3].String;
                    }

                    variables.Add(v);
                }
                else if (tokens[tokenIndex].String == "print")
                {
                    if (tokens[tokenIndex + 1].TokenType == TokenType.STRING_LITERAL) {
                        Console.WriteLine(tokens[tokenIndex + 1].String);
                    }

                    foreach (Variable v in variables)
                    {
                        if (v.Identifier == tokens[tokenIndex + 1].String)
                        {

                            switch (v.Type)
                            {

                                case VariableType.INT:
                                    Console.WriteLine(v.intVal);
                                    break;

                                case VariableType.DOUBLE:
                                    Console.WriteLine(v.doubleVal);
                                    break;

                                case VariableType.STRING:
                                    Console.WriteLine(v.StringVal);
                                    break;

                                default:

                                    break;
                            }

                        }
                    }
                }

                tokenIndex++;
            }
        }
    }
}
