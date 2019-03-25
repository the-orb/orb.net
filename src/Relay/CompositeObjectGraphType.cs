using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relay
{
    public class CompositeObjectGraphType : ObjectGraphType
    {
        protected void Extend(ObjectGraphType type)
        {
            foreach (var field in type.Fields)
            {
                AddField(field);
            }
        }
    }
}
