namespace GraphQL.Types
{
    public class NodeInterface : InterfaceGraphType
    {
        public NodeInterface()
        {
            Name = "Node";

            Field<IdGraphType>("id", "Global node Id");
        }
    }
}