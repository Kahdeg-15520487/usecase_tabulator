namespace usecase_tabulator.AST
{
    interface IVisitable
    {
        void Accept(IVisitor visitor);
    }

    abstract class ASTNode : IVisitable
    {
        public abstract string Value();

        public abstract void Accept(IVisitor visitor);
    }

    interface IVisitor
    {
        void Visit(ASTNode node);
        void Visit(SingleLine singleLine);
        void Visit(MultiLine multiLine);
    }
}
