using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace usecase_tabulator.AST
{
    class UseCase
    {
        public UseCase(List<ASTNode> props)
        {
            foreach (ASTNode prop in props)
            {
                switch (prop)
                {
                    case SingleLine singleLine:
                        switch (singleLine.Token.lexeme)
                        {
                            case "Name":
                                Name = singleLine.Line;
                                break;
                            case "Purpose":
                                Purpose = singleLine.Line;
                                break;
                            case "Actor":
                                Actor = singleLine.Line;
                                break;
                            case "PreCond":
                                PreCondition = singleLine.Line;
                                break;
                            case "PostCond":
                                PostCondition = singleLine.Line;
                                break;
                            case "OtherEvent":
                                OtherEvent = singleLine.Line;
                                break;
                        }
                        break;
                    case MultiLine multiLine:
                        switch (multiLine.Token.lexeme)
                        {
                            case "MainFlow":
                                // MainFlow = multiLine.Lines == null ? new string[]{ "Không có" } : multiLine.Lines;
                                MainFlow = string.Join(Environment.NewLine, multiLine.Lines);
                                break;
                            case "AltFlow":
                                // AlternativeFlow = multiLine.Lines == null ? new string[]{ "Không có" } : multiLine.Lines;
                                AlternativeFlow = string.Join(Environment.NewLine, multiLine.Lines);
                                break;
                            case "Exception":
                                // ExceptionFlow = multiLine.Lines == null ? new string[]{ "Không có" } : multiLine.Lines;
                                ExceptionFlow = string.Join(Environment.NewLine, multiLine.Lines);
                                break;
                            case "Markup":
                                SequenceDiagram = string.Join(Environment.NewLine, multiLine.Lines);
                                break;
                        }
                        break;
                }
            }
        }

        public string Name { get; set; }
        public string Purpose { get; set; }
        public string Actor { get; set; }
        public string PreCondition { get; set; }
        public string PostCondition { get; set; }
        public string MainFlow { get; set; }
        public string AlternativeFlow { get; set; }
        public string ExceptionFlow { get; set; }
        public string OtherEvent { get; set; }
        public string SequenceDiagram { get; set; }
    }
    class UseCaseASTNode : ASTNode
    {
        public List<ASTNode> Properties { get; private set; }

        public UseCase UseCase { get; private set; }

        public UseCaseASTNode(List<ASTNode> properties)
        {
            this.Properties = properties;
            UseCase = new UseCase(Properties);
        }

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
