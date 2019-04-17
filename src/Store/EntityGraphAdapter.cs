using GraphQL.Builders;
using GraphQL.Resolvers;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Reflection;

namespace GraphQL.Entity
{
    public class EntityGraphAdapter : IEntityGraphAdapter
    {
        GlobalFilters filters;

        public EntityGraphAdapter(EdmModel model, GlobalFilters filters)
        {
            // Guard.AgainstNull(nameof(model), model);
            this.filters = filters;
            includeAppender = new IncludeAppender(NavigationReader.GetNavigationProperties(model));
        }

        IncludeAppender includeAppender;

        static Type MakeListGraphType(Type graphType)
        {
            var listGraphType = typeof(ListGraphType<>);
            return listGraphType.MakeGenericType(graphType);
        }

        #region navigation
        public FieldType AddNavigationField<TSource, TReturn>(
            ObjectGraphType<TSource> graph,
            string name,
            Func<ResolveFieldContext<TSource>, TReturn> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null,
            IEnumerable<string> includeNames = null)
            where TReturn : class
        {
            Guard.AgainstNull(nameof(graph), graph);
            var field = BuildNavigationField(name, resolve, includeNames, graphType, arguments);
            return graph.AddField(field);
        }

        public FieldType AddNavigationField<TReturn>(
            ObjectGraphType graph,
            string name,
            Func<ResolveFieldContext<object>, TReturn> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null,
            IEnumerable<string> includeNames = null)
            where TReturn : class
        {
            Guard.AgainstNull(nameof(graph), graph);
            var field = BuildNavigationField(name, resolve, includeNames, graphType, arguments);
            return graph.AddField(field);
        }

        FieldType BuildNavigationField<TSource, TReturn>(
            string name,
            Func<ResolveFieldContext<TSource>, TReturn> resolve,
            IEnumerable<string> includeNames,
            Type graphType,
            IEnumerable<QueryArgument> arguments)
            where TReturn : class
        {
            Guard.AgainstNullWhiteSpace(nameof(name), name);
            Guard.AgainstNull(nameof(resolve), resolve);
            graphType = GraphTypeFinder.FindGraphType<TReturn>(graphType);
            return new FieldType
            {
                Name = name,
                Type = graphType,
                Arguments = ArgumentAppender.GetQueryArguments(arguments),
                Metadata = IncludeAppender.GetIncludeMetadata(name, includeNames),
                Resolver = new AsyncFieldResolver<TSource, TReturn>(async context =>
                {
                    var result = resolve(context);
                    if (await filters.ShouldInclude(context.UserContext, result))
                    {
                        return result;
                    }

                    return null;
                })
            };
        }
        #endregion
        #region navigation connection
        public void AddNavigationConnectionField<TReturn>(
            ObjectGraphType graph,
            string name,
            Func<ResolveFieldContext<object>, IEnumerable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null,
            IEnumerable<string> includeNames = null,
            int pageSize = 10)
            where TReturn : class
        {
            Guard.AgainstNull(nameof(graph), graph);
            var connection = BuildListConnectionField(name, resolve, includeNames, pageSize, graphType);
            var field = graph.AddField(connection.FieldType);
            field.AddWhereArgument(arguments);
        }

        public void AddNavigationConnectionField<TSource, TReturn>(
            ObjectGraphType<TSource> graph,
            string name,
            Func<ResolveFieldContext<TSource>, IEnumerable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null,
            IEnumerable<string> includeNames = null,
            int pageSize = 10)
            where TReturn : class
        {
            Guard.AgainstNull(nameof(graph), graph);
            var connection = BuildListConnectionField(name, resolve, includeNames, pageSize, graphType);
            var field = graph.AddField(connection.FieldType);
            field.AddWhereArgument(arguments);
        }

        ConnectionBuilder<FakeGraph, TSource> BuildListConnectionField<TSource, TReturn>(
            string name,
            Func<ResolveFieldContext<TSource>, IEnumerable<TReturn>> resolve,
            IEnumerable<string> includeName,
            int pageSize,
            Type graphType)
            where TReturn : class
        {
            Guard.AgainstNullWhiteSpace(nameof(name), name);
            Guard.AgainstNull(nameof(resolve), resolve);
            Guard.AgainstNegative(nameof(pageSize), pageSize);
            graphType = GraphTypeFinder.FindGraphType<TReturn>(graphType);
            var fieldType = GetFieldType<TSource>(name, graphType);
            var builder = ConnectionBuilder<FakeGraph, TSource>.Create(name);
            builder.PageSize(pageSize);
            SetField(builder, fieldType);
            IncludeAppender.SetIncludeMetadata(builder.FieldType, name, includeName);
            builder.ResolveAsync(async context =>
            {
                var enumerable = resolve(context);
                enumerable = enumerable.ApplyGraphQlArguments(context);
                enumerable = await filters.ApplyFilter(enumerable, context.UserContext);
                var page = enumerable.ToList();

                return ConnectionConverter.ApplyConnectionContext(
                    page,
                    context.First,
                    context.After,
                    context.Last,
                    context.Before);
            });
            return builder;
        }

        static void SetField(object builder, object fieldType)
        {
            var fieldTypeField = builder.GetType().GetProperty("FieldType", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            fieldTypeField.SetValue(builder, fieldType);
        }

        static object GetFieldType<TSource>(string name, Type graphType)
        {
            var makeGenericType = typeof(ConnectionBuilder<,>).MakeGenericType(graphType, typeof(TSource));
            dynamic x = makeGenericType.GetMethod("Create").Invoke(null, new object[] { name });
            return x.FieldType;
        }

        class FakeGraph : GraphType
        {
        }
        #endregion
        #region navigation list
        public FieldType AddNavigationListField<TSource, TReturn>(
            ObjectGraphType<TSource> graph,
            string name,
            Func<ResolveFieldContext<TSource>, IEnumerable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null,
            IEnumerable<string> includeNames = null)
            where TReturn : class
        {
            Guard.AgainstNull(nameof(graph), graph);
            var field = BuildNavigationField(graphType, name, resolve, includeNames, arguments);
            return graph.AddField(field);
        }

        public FieldType AddNavigationListField<TReturn>(
            ObjectGraphType graph,
            string name,
            Func<ResolveFieldContext<object>, IEnumerable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null,
            IEnumerable<string> includeNames = null)
            where TReturn : class
        {
            Guard.AgainstNull(nameof(graph), graph);
            var field = BuildNavigationField(graphType, name, resolve, includeNames, arguments);
            return graph.AddField(field);
        }

        FieldType BuildNavigationField<TSource, TReturn>(
            Type graphType,
            string name,
            Func<ResolveFieldContext<TSource>, IEnumerable<TReturn>> resolve,
            IEnumerable<string> includeNames,
            IEnumerable<QueryArgument> arguments)
            where TReturn : class
        {
            graphType = GraphTypeFinder.FindGraphType<TReturn>(graphType);
            var listGraphType = MakeListGraphType(graphType);
            return BuildNavigationField(name, resolve, includeNames, listGraphType, arguments);
        }

        FieldType BuildNavigationField<TSource, TReturn>(
            string name,
            Func<ResolveFieldContext<TSource>, IEnumerable<TReturn>> resolve,
            IEnumerable<string> includeNames,
            Type listGraphType,
            IEnumerable<QueryArgument> arguments)
            where TReturn : class
        {
            Guard.AgainstNullWhiteSpace(nameof(name), name);
            Guard.AgainstNull(nameof(resolve), resolve);
            return new FieldType
            {
                Name = name,
                Type = listGraphType,
                Arguments = ArgumentAppender.GetQueryArguments(arguments),
                Metadata = IncludeAppender.GetIncludeMetadata(name, includeNames),
                Resolver = new AsyncFieldResolver<TSource, IEnumerable<TReturn>>(
                    async context =>
                    {
                        var result = resolve(context);
                        result = result.ApplyGraphQlArguments(context);
                        return await filters.ApplyFilter(result, context.UserContext);
                    })
            };
        }
        #endregion
        #region queryable
        public FieldType AddQueryField<TReturn>(
            ObjectGraphType graph,
            string name,
            Func<ResolveFieldContext<object>, IQueryable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null)
            where TReturn : class
        {
            Guard.AgainstNull(nameof(graph), graph);
            var field = BuildQueryField(graphType, name, resolve, arguments);
            return graph.AddField(field);
        }

        public FieldType AddQueryField<TSource, TReturn>(
            ObjectGraphType<TSource> graph,
            string name,
            Func<ResolveFieldContext<TSource>, IQueryable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null)
            where TReturn : class
        {
            Guard.AgainstNull(nameof(graph), graph);
            var field = BuildQueryField(graphType, name, resolve, arguments);
            return graph.AddField(field);
        }

        public FieldType AddQueryField<TSource, TReturn>(
            ObjectGraphType graph,
            string name,
            Func<ResolveFieldContext<TSource>, IQueryable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null)
            where TReturn : class
        {
            Guard.AgainstNull(nameof(graph), graph);
            var field = BuildQueryField(graphType, name, resolve, arguments);
            return graph.AddField(field);
        }

        FieldType BuildQueryField<TSource, TReturn>(
            Type graphType,
            string name,
            Func<ResolveFieldContext<TSource>, IQueryable<TReturn>> resolve,
            IEnumerable<QueryArgument> arguments)
            where TReturn : class
        {
            return BuildQueryField(name, resolve, arguments, graphType);
        }

        FieldType BuildQueryField<TSource, TReturn>(
            string name,
            Func<ResolveFieldContext<TSource>, IQueryable<TReturn>> resolve,
            IEnumerable<QueryArgument> arguments,
            Type graphType)
            where TReturn : class
        {
            Guard.AgainstNullWhiteSpace(nameof(name), name);
            Guard.AgainstNull(nameof(resolve), resolve);
            graphType = GraphTypeFinder.FindGraphType<TReturn>(graphType);
            var listGraphType = MakeListGraphType(graphType);
            return new FieldType
            {
                Name = name,
                Type = listGraphType,
                Arguments = ArgumentAppender.GetQueryArguments(arguments),
                Resolver = new AsyncFieldResolver<TSource, IEnumerable<TReturn>>(
                    async context =>
                    {
                        var returnTypes = resolve(context);
                        var withIncludes = includeAppender.AddIncludes(returnTypes, context);
                        var withArguments = withIncludes.ApplyGraphQlArguments(context);
                        var list = await withArguments.ToListAsync(context.CancellationToken);
                        return await filters.ApplyFilter(list, context.UserContext);
                    })
            };
        }
        #endregion
        #region queryable connection
        public void AddQueryConnectionField<TReturn>(
            ObjectGraphType graph,
            string name,
            Func<ResolveFieldContext<object>, IQueryable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null,
            int pageSize = 10)
            where TReturn : class
        {
            Guard.AgainstNull(nameof(graph), graph);
            var connection = BuildQueryConnectionField(name, resolve, pageSize, graphType);
            var field = graph.AddField(connection.FieldType);
            field.AddWhereArgument(arguments);
        }

        public void AddQueryConnectionField<TSource, TReturn>(
            ObjectGraphType graph,
            string name,
            Func<ResolveFieldContext<TSource>, IQueryable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null,
            int pageSize = 10)
            where TReturn : class
        {
            Guard.AgainstNull(nameof(graph), graph);
            var connection = BuildQueryConnectionField(name, resolve, pageSize, graphType);
            var field = graph.AddField(connection.FieldType);
            field.AddWhereArgument(arguments);
        }

        public void AddQueryConnectionField<TSource, TReturn>(
            ObjectGraphType<TSource> graph,
            string name,
            Func<ResolveFieldContext<TSource>, IQueryable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null,
            int pageSize = 10)
            where TReturn : class
        {
            Guard.AgainstNull(nameof(graph), graph);
            var connection = BuildQueryConnectionField(name, resolve, pageSize, graphType);
            var field = graph.AddField(connection.FieldType);
            field.AddWhereArgument(arguments);
        }

        ConnectionBuilder<FakeGraph, TSource> BuildQueryConnectionField<TSource, TReturn>(
            string name,
            Func<ResolveFieldContext<TSource>, IQueryable<TReturn>> resolve,
            int pageSize,
            Type graphType)
            where TReturn : class
        {
            Guard.AgainstNullWhiteSpace(nameof(name), name);
            Guard.AgainstNull(nameof(resolve), resolve);
            Guard.AgainstNegative(nameof(pageSize), pageSize);

            graphType = GraphTypeFinder.FindGraphType<TReturn>(graphType);
            var fieldType = GetFieldType<TSource>(name, graphType);
            var builder = ConnectionBuilder<FakeGraph, TSource>.Create(name);
            builder.PageSize(pageSize);
            SetField(builder, fieldType);

            builder.Resolve(
                context =>
                {
                    var withIncludes = includeAppender.AddIncludes(resolve(context), context);
                    var withArguments = withIncludes.ApplyGraphQlArguments(context);
                    return withArguments
                        .ApplyConnectionContext(
                            context.First,
                            context.After,
                            context.Last,
                            context.Before,
                            context,
                            context.CancellationToken,
                            filters);
                });
            return builder;
        }
        #endregion
        #region single
        public FieldType AddSingleField<TReturn>(
            ObjectGraphType graph,
            string name,
            Func<ResolveFieldContext<object>, IQueryable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null)
            where TReturn : class
        {
            Guard.AgainstNull(nameof(graph), graph);
            var field = BuildSingleField(name, resolve, arguments, graphType);
            return graph.AddField(field);
        }

        public FieldType AddSingleField<TSource, TReturn>(
            ObjectGraphType<TSource> graph,
            string name,
            Func<ResolveFieldContext<TSource>, IQueryable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null)
            where TReturn : class
        {
            Guard.AgainstNull(nameof(graph), graph);
            var field = BuildSingleField(name, resolve, arguments, graphType);
            return graph.AddField(field);
        }

        public FieldType AddSingleField<TSource, TReturn>(
            ObjectGraphType graph,
            string name,
            Func<ResolveFieldContext<TSource>, IQueryable<TReturn>> resolve,
            Type graphType = null,
            IEnumerable<QueryArgument> arguments = null)
            where TReturn : class
        {
            Guard.AgainstNull(nameof(graph), graph);
            var field = BuildSingleField(name, resolve, arguments, graphType);
            return graph.AddField(field);
        }

        FieldType BuildSingleField<TSource, TReturn>(
            string name,
            Func<ResolveFieldContext<TSource>, IQueryable<TReturn>> resolve,
            IEnumerable<QueryArgument> arguments,
            Type graphType)
            where TReturn : class
        {
            Guard.AgainstNullWhiteSpace(nameof(name), name);
            Guard.AgainstNull(nameof(resolve), resolve);

            graphType = GraphTypeFinder.FindGraphType<TReturn>(graphType);
            return new FieldType
            {
                Name = name,
                Type = graphType,
                Arguments = ArgumentAppender.GetQueryArguments(arguments),
                Resolver = new AsyncFieldResolver<TSource, TReturn>(
                    async context =>
                    {
                        var returnTypes = resolve(context);
                        var withIncludes = includeAppender.AddIncludes(returnTypes, context);
                        var withArguments = withIncludes.ApplyGraphQlArguments(context);

                        var single = await withArguments.SingleOrDefaultAsync(context.CancellationToken);
                        if (await filters.ShouldInclude(context.UserContext, single))
                        {
                            return single;
                        }

                        return null;
                    })
            };
        }
        #endregion
    }
}
