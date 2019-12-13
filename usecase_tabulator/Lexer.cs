using System;
using System.Collections.Generic;
using System.Text;

namespace usecase_tabulator
{
    class Lexer
    {
        string text;
        int pos;
        char current_char;
        int current_line;
        int current_pos_in_line;

        public int CurrentLine { get => current_line; }
        public int CurrentPosInLine { get => current_pos_in_line; }
        public string CurrentLineSource
        {
            get
            {
                return text.Substring(pos - current_pos_in_line, current_pos_in_line);
            }
        }

        public Lexer(string t)
        {
            text = t;
            pos = 0;
            current_char = text[pos];
            current_line = 0;
            current_pos_in_line = 0;
        }

        public Lexer(Lexer other)
        {
            text = other.text;
            pos = other.pos;
            current_char = other.current_char;
            current_line = other.current_line;
            current_pos_in_line = other.current_pos_in_line;
        }

        public void Error()
        {
            throw new Exception("Error parsing input : " + current_char);
        }

        void Advance()
        {
            pos++;
            current_pos_in_line++;
            if (pos > text.Length - 1)
            {
                current_char = '\0';
            }
            else
            {
                current_char = text[pos];
            }
        }
        char Peek()
        {
            if (pos > text.Length - 1)
            {
                current_char = '\0';
            }
            return text[pos + 1];
        }

        void SkipWhitespace()
        {
            while (current_char != '\0' && char.IsWhiteSpace(current_char))
                Advance();
        }

        void SkipComment()
        {
            while (current_char != '\0' && current_char != '\n')
            {
                Advance();
            }
        }

        Token String()
        {
            string result = "";
            while (current_char != '\0' && current_char != '\r' && current_char != '\n')
            {
                result += current_char;
                Advance();
            }
            return new Token(TokenType.STRING, result);
        }

        Token Ident()
        {
            StringBuilder temp = new StringBuilder();
            while (current_char != '\0' && current_char.IsIdent())
            {
                temp.Append(current_char);
                Advance();
            }

            string result = temp.ToString();

            switch (result)
            {
                case "Name":
                case "Purpose":
                case "Actor":
                case "PreCond":
                case "PostCond":
                case "OtherEvent":
                    return new Token(TokenType.SingleLine, result);

                case "MainFlow":
                case "AltFlow":
                case "Exception":
                case "Markup":
                    return new Token(TokenType.MultiLine, result);
            }

            return new Token(TokenType.IDENT, result);
        }

        public Token GetNextToken()
        {
            while (current_char != '\0')
            {
                if (current_char == '\r')
                {
                    current_line++;
                    current_pos_in_line = 0;
                }

                if (char.IsWhiteSpace(current_char))
                {
                    SkipWhitespace();
                    continue;
                }

                if (current_char == '/' && Peek() == '/')
                {
                    SkipComment();
                    continue;
                }

                if (current_char == '=' && Peek() == '=')
                {
                    SkipComment();
                    return new Token(TokenType.DELIMITER, null);
                }

                char peek = this.Peek();
                char cur = current_char;
                //if (current_char.IsIdent())
                //{
                //    return Ident();
                //}

                if (cur == 'N' && peek == 'a'
                 || cur == 'P' && peek == 'u'
                 || cur == 'A' && peek == 'c'
                 || cur == 'P' && peek == 'r'
                 || cur == 'P' && peek == 'o'
                 || cur == 'M' && peek == 'a'
                 || cur == 'A' && peek == 'l'
                 || cur == 'E' && peek == 'x'
                 || cur == 'O' && peek == 't'
                 || cur == 'M' && peek == 'a')
                {
                    return Ident();
                }

                return String();
            }
            return new Token(TokenType.EOF, null);
        }

        public Token PeekNextToken()
        {
            Lexer peeker = new Lexer(this);
            return peeker.GetNextToken();
        }
    }
}
