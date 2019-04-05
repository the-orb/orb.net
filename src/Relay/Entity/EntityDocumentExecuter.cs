namespace GraphQL.Entity
{
    using Execution;
    using Language.AST;

    public class EntityDocumentExecuter : DocumentExecuter
    {
        protected override IExecutionStrategy SelectExecutionStrategy(ExecutionContext context)
        {
            Guard.AgainstNull(nameof(context), context);
            if (context.Operation.OperationType == OperationType.Query)
            {
                return new SerialExecutionStrategy();
            }
            return base.SelectExecutionStrategy(context);
        }
    }
}