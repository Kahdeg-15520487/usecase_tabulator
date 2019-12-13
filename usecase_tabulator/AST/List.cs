using System;
using System.Collections.Generic;
using System.Text;

namespace usecase_tabulator.AST
{
    class List : ASTNode
    {
        public List(List<UseCaseASTNode> useCases)
        {
            this.UseCases = useCases;
        }

        public List<UseCaseASTNode> UseCases { get; private set; }

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
