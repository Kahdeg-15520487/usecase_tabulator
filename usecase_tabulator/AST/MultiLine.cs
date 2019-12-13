using System;
using System.Collections.Generic;
using System.Text;

namespace usecase_tabulator.AST
{
    class MultiLine : ASTNode
    {
        public MultiLine(Token token, string[] lines)
        {
            this.Token = token;
            this.Lines = lines;
        }

        public Token Token { get; private set; }
        public string[] Lines { get; private set; }

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
