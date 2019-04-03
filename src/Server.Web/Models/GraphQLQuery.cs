using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Web.Models
{
    public class GraphQLQuery
    {
        public string OperationName { get; set; }

        public string NamedQuery { get; set; }

        public string Query { get; set; }

        public string Variables { get; set; }
    }
}