﻿using System.Collections.Generic;

namespace GraphQL.Types
{
    public class MutationGraphType : ObjectGraphType
    {
        public MutationGraphType()
        {
            Name = "Mutation";
        }

        public FieldType Mutation<TMutationInput, TMutationType>(string name)
            where TMutationType : IMutationPayload<object>
            where TMutationInput : MutationInputGraphType
        {
            return Field(
                name: name,
                type: typeof(TMutationType),
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<TMutationInput>> {Name = "input"}
                ),
                resolve: c =>
                {
                    var inputs = c.GetArgument<Dictionary<string, object>>("input");

                    return ((TMutationType) c.ReturnType).MutateAndGetPayload(new MutationInputs(inputs), c);
                }
            );
        }
    }
}