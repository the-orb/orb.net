using GraphQL.Types;
using GraphQL.Types.Relay.DataObjects;
using StarWars.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars
{
    public class StarWarsQuery : ObjectGraphType<object>
    {
        public StarWarsQuery(StarWarsData data)
        {
            Name = "Query";

            Connection<CharacterInterface>()
                .Name("characters")
                .Description("RandomDescription")
                .Bidirectional()
                .Resolve(context =>
                {
                    var source = data.GetAll();
                    var totalCount = source.Count;
                    IEnumerable<StarWarsCharacter> characters = source;

                    if (context.After != null)
                    {
                        var index = source.Select(x => x.Id).ToList().IndexOf(context.After);

                        if (index > -1)
                        {
                            characters = characters.Skip(index + 1);
                        }
                    }

                    if (context.Before != null)
                    {
                        var index = source.Select(x => x.Id).ToList().IndexOf(context.Before);

                        source = source.Take(index).ToList();
                    }

                    if (context.First.HasValue)
                    {
                        characters = characters.Take(context.First.Value);
                    }
                    else if (context.Last.HasValue)
                    {
                        characters = source.Skip(Math.Max(0, source.Count - context.Last.Value));
                    }

                    return new Connection<StarWarsCharacter>
                    {
                        TotalCount = totalCount,
                        PageInfo = new PageInfo
                        {
                            HasNextPage = true,
                            HasPreviousPage = false,
                            StartCursor = "1",
                            EndCursor = "4",
                        },
                        Edges = new List<Edge<StarWarsCharacter>>(characters.Select(node =>
                            new Edge<StarWarsCharacter>
                            {
                                Cursor = node.Id,
                                Node = node
                            }
                        ))
                    };
                });

            /*Field<ListGraphType<CharacterInterface>>(
                "characters", resolve: context => data.GetAllAsync());*/

            Field<CharacterInterface>("hero", resolve: context => data.GetDroidByIdAsync("3"));
            Field<HumanType>(
                "human",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the human" }
                ),
                resolve: context => data.GetHumanByIdAsync(context.GetArgument<string>("id"))
            );

            Func<ResolveFieldContext, string, object> func = (context, id) => data.GetDroidByIdAsync(id);

            FieldDelegate<DroidType>(
                "droid",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the droid" }
                ),
                resolve: func
            );
        }
    }
}
