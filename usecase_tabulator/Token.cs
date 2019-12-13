using System;
using System.Collections.Generic;
using System.Text;

namespace usecase_tabulator
{
    enum TokenType
    {
        //NAME,
        //PURPOSE,
        //ACTOR,
        //PRECOND,
        //POSTCOND,
        //OTHEREVENT,
        SingleLine,

        //MAINFLOW,
        //ALTFLOW,
        //EXCEPTIONS,
        //MARKUP,
        MultiLine,

        IDENT,
        EOF,
        DELIMITER,
        STRING
    }

    class Token
    {
        public TokenType type { get; private set; }
        public string lexeme { get; private set; }

        public Token(TokenType t, string l = null)
        {
            type = t;
            lexeme = l;
        }

        public override string ToString()
        {
            return string.Format("{0} : {1}", type, lexeme);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 91;
                hash = hash * 71 + lexeme.GetHashCode();
                hash = hash * 71 + type.GetHashCode();
                return hash;
            }
        }
    }
}
