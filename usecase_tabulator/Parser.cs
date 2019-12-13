using System;
using System.Collections.Generic;
using System.Text;
using usecase_tabulator.AST;

namespace usecase_tabulator
{
    class Parser
    {
        Lexer lexer;

        Token current_token;

        public Parser(Lexer l)
        {
            lexer = l;
            current_token = lexer.GetNextToken();
        }

        void Error(string msg)
        {
            throw new Exception($"{msg} at ({lexer.CurrentLine}:{lexer.CurrentPosInLine}) : {lexer.CurrentLineSource} ");
        }

        void Error()
        {
            Error($"Invalid Token: {current_token}");
        }

        void Error(TokenType expecting)
        {
            Error($"Expecting: {expecting}");
        }

        void Eat(TokenType t)
        {
            if (current_token.type == t)
            {
                current_token = lexer.GetNextToken();
            }
            else
            {
                Error(t);
            }
        }

        ASTNode SingleLine()
        {
            var type = current_token;
            Eat(TokenType.SingleLine);
            var line = current_token;
            Eat(TokenType.STRING);
            return new SingleLine(type, line.lexeme);
        }

        ASTNode MultiLine()
        {
            var type = current_token;
            Eat(TokenType.MultiLine);
            List<string> lines = new List<string>();
            while (current_token.type == TokenType.STRING)
            {
                lines.Add(current_token.lexeme);
                Eat(TokenType.STRING);
            }
            return new MultiLine(type, lines.ToArray());
        }

        ASTNode Property()
        {
            /*
             * prop : singleLine | multiLine
             */

            switch (current_token.type)
            {
                case TokenType.SingleLine:
                    return SingleLine();
                case TokenType.MultiLine:
                    return MultiLine();
                default:
                    Error();
                    return null;
            }
        }

        UseCaseASTNode UseCase()
        {
            List<ASTNode> props = new List<ASTNode>();
            while (current_token.type != TokenType.DELIMITER)
            {
                props.Add(Property());
            }
            Eat(TokenType.DELIMITER);
            return new UseCaseASTNode(props);
        }

        public ASTNode Parse()
        {
            List<UseCaseASTNode> useCases = new List<UseCaseASTNode>();
            while (lexer.PeekNextToken().type != TokenType.EOF)
            {
                useCases.Add(UseCase());
            }
            return new AST.List(useCases);
        }
    }
}
