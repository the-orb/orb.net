using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL.Entity
{
    public interface IEntityGraphAdapter
    {
        #region navigation
        FieldType AddNavigationField<TSource, TReturn>(ObjectGraphType<TSource> graph,
            string name,
            Func<ResolveFieldContext<TSource>, TReturn> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null,
            IEnumerable<string> includeNames = null)
            where TReturn : class;

        FieldType AddNavigationField<TReturn>(ObjectGraphType graph,
            string name,
            Func<ResolveFieldContext<object>, TReturn> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null,
            IEnumerable<string> includeNames = null)
            where TReturn : class;

        FieldType AddNavigationListField<TSource, TReturn>(ObjectGraphType<TSource> graph,
            string name,
            Func<ResolveFieldContext<TSource>, IEnumerable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null,
            IEnumerable<string> includeNames = null)
            where TReturn : class;

        FieldType AddNavigationListField<TReturn>(ObjectGraphType graph,
            string name,
            Func<ResolveFieldContext<object>, IEnumerable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null,
            IEnumerable<string> includeNames = null)
            where TReturn : class;
        #endregion
        #region navigation connection
        void AddNavigationConnectionField<TReturn>(
            ObjectGraphType graph,
            string name,
            Func<ResolveFieldContext<object>, IEnumerable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null,
            IEnumerable<string> includeNames = null,
            int pageSize = 10)
            where TReturn : class;

        void AddNavigationConnectionField<TSource, TReturn>(
            ObjectGraphType<TSource> graph,
            string name,
            Func<ResolveFieldContext<TSource>, IEnumerable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null,
            IEnumerable<string> includeNames = null,
            int pageSize = 10)
            where TReturn : class;
        #endregion
        #region queryable
        FieldType AddQueryField<TReturn>(
            ObjectGraphType graph,
            string name,
            Func<ResolveFieldContext<object>, IQueryable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null)
            where TReturn : class;

        FieldType AddQueryField<TSource, TReturn>(
            ObjectGraphType<TSource> graph,
            string name,
            Func<ResolveFieldContext<TSource>, IQueryable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null)
            where TReturn : class;

        FieldType AddQueryField<TSource, TReturn>(
            ObjectGraphType graph,
            string name,
            Func<ResolveFieldContext<TSource>, IQueryable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null)
            where TReturn : class;
        #endregion
        #region queryable connection
        void AddQueryConnectionField<TReturn>(ObjectGraphType graph,
            string name,
            Func<ResolveFieldContext<object>, IQueryable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null,
            int pageSize = 10)
            where TReturn : class;

        void AddQueryConnectionField<TSource, TReturn>(
            ObjectGraphType graph,
            string name,
            Func<ResolveFieldContext<TSource>, IQueryable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null,
            int pageSize = 10)
            where TReturn : class;

        void AddQueryConnectionField<TSource, TReturn>(ObjectGraphType<TSource> graph,
            string name,
            Func<ResolveFieldContext<TSource>, IQueryable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null,
            int pageSize = 10)
            where TReturn : class;
        #endregion
        #region single
        FieldType AddSingleField<TReturn>(
            ObjectGraphType graph,
            string name,
            Func<ResolveFieldContext<object>, IQueryable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null)
            where TReturn : class;

        FieldType AddSingleField<TSource, TReturn>(
            ObjectGraphType<TSource> graph,
            string name,
            Func<ResolveFieldContext<TSource>, IQueryable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null)
            where TReturn : class;

        FieldType AddSingleField<TSource, TReturn>(
            ObjectGraphType graph,
            string name,
            Func<ResolveFieldContext<TSource>, IQueryable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null)
            where TReturn : class;
        #endregion
    }
}
