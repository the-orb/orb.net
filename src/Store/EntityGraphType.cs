using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL.Entity
{
    public class EntityGraphType : CompositeObjectGraphType
    {
        IEntityGraphAdapter _context;

        public EntityGraphType(IEntityGraphAdapter context)
        {
            // Guard.AgainstNull(nameof(service), service);
            _context = context;
        }

        protected void AddNavigationConnectionField<TReturn>(
            string name,
            Func<ResolveFieldContext<object>, IEnumerable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null,
            IEnumerable<string> includeNames = null,
            int pageSize = 10)
            where TReturn : class
        {
            _context.AddNavigationConnectionField(this, name, resolve, graphType, arguments, includeNames, pageSize);
        }

        protected FieldType AddNavigationField<TReturn>(
            string name,
            Func<ResolveFieldContext<object>, TReturn> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null,
            IEnumerable<string> includeNames = null)
            where TReturn : class
        {
            return _context.AddNavigationField(this, name, resolve, graphType, arguments, includeNames);
        }

        protected FieldType AddNavigationListField<TReturn>(
            string name,
            Func<ResolveFieldContext<object>, IEnumerable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null,
            IEnumerable<string> includeNames = null)
            where TReturn : class
        {
            return _context.AddNavigationListField(this, name, resolve, graphType, arguments, includeNames);
        }

        protected void AddQueryConnectionField<TReturn>(
            string name,
            Func<ResolveFieldContext<object>, IQueryable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null,
            int pageSize = 10)
            where TReturn : class
        {
            _context.AddQueryConnectionField(this, name, resolve, graphType, arguments, pageSize);
        }

        protected FieldType AddQueryField<TReturn>(
            string name,
            Func<ResolveFieldContext<object>, IQueryable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null)
            where TReturn : class
        {
            return _context.AddQueryField(this, name, resolve, graphType, arguments);
        }

        protected FieldType AddSingleField<TReturn>(
            Func<ResolveFieldContext<object>, IQueryable<TReturn>> resolve,
            Type graphType = null,
            string name = nameof(TReturn))
            where TReturn : class
        {
            return _context.AddSingleField(this, name, resolve, graphType);
        }
    }
}
