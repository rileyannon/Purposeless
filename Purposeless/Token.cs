using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purposeless
{
    //Token class was defined for future expansions
    //TokenTypes defined for easier parsing
    public enum TokenType { 
            INT_KEYWORD,
            STRING_KEYWORD,
            DOUBLE_KEYWORD,
            IDENTIFIER,
            STRING_LITERAL,
            INT_LITERAL,
            DOUBLE_LITERAL,
            OPERATOR
    }
    public class Token
    {
        public string String;
        public TokenType TokenType;

        public Token(string text) {
            String = text;
            defineToken(text);
        }

        public Token(string text, TokenType tokenType) {
            String = text;
            TokenType = tokenType;
        }

        //TODO: Finish complete typing system
        private void defineToken(string text) {

            if (int.TryParse(text, out _))
            {
                TokenType = TokenType.INT_LITERAL;
            }
            else if (double.TryParse(text, out _))
            {
                TokenType = TokenType.DOUBLE_LITERAL;
            }
            else if (text == "string")
            {
                TokenType = TokenType.STRING_KEYWORD;
            }
            else if (text == "int")
            {
                TokenType = TokenType.INT_KEYWORD;
            }
            else if (text == "double") {
                TokenType = TokenType.DOUBLE_KEYWORD;
            }
            else
            {
                TokenType = TokenType.IDENTIFIER;
            }
        }
    }
}
