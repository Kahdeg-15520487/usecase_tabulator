using System;
using System.Collections.Generic;
using System.Text;

namespace usecase_tabulator.AST
{
    class SingleLine : ASTNode
    {
        public SingleLine(Token token, string line)
        {
            this.Token = token;
            this.Line = line;
        }

        public Token Token { get; private set; }
        public string Line { get; private set; }
        public override void Accept(IVisitor visitor)
        {
            throw new NotImplementedException();
        }

        public override string Value()
        {
            throw new NotImplementedException();
        }
    }
}
