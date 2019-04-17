using GraphQL;
using GraphQL.Http;
using GraphQL.Instrumentation;
using GraphQL.Types;
using GraphQL.Validation.Complexity;
using StarWars;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Linq;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace Server.Web.Controllers
{
    using Models;

    [Route("graphql/starwars")]
    public sealed class StarWarsGraphQLController : ApiController
    {
        const string QUERY = @"
        query Query1($vaderId: String!) {
            all: characters(last: 2, before: ""3"") {
                totalCount
                edges
                {
                    node
                    {
                        id
                        name
                    }
                    cursor
                }
                pageInfo {
                    hasPreviousPage
                    startCursor
                    endCursor
                    hasNextPage
                }
            }
            luke: human(id: ""1"") {
                ...HumanFragment
            }
            r2d2: hero {
                ...CharacterFragment
            }
            vader: human(id: $vaderId) {
                ...HumanFragment
            }
        }

        fragment HumanFragment on Human {
            name
            friends {
                name
            }
            appearsIn,
            homePlanet
        }

        fragment CharacterFragment on Character {
            name
            __typename
            friends {
                name
            }
            appearsIn
        }

        mutation createHuman($human: HumanInput!) {
            createHuman(human: $human) {
                name
                homePlanet
            }
        }";

        readonly ISchema _schema;
        readonly IDocumentExecuter _executer;
        readonly IDocumentWriter _writer;
        readonly IDictionary<string, string> _namedQueries;

        public StarWarsGraphQLController(
            IDocumentExecuter executer,
            IDocumentWriter writer,
            StarWarsSchema schema)
        {
            _executer = executer;
            _writer = writer;
            _schema = schema;
        }

        public async Task<HttpResponseMessage> GetAsync(
            HttpRequestMessage request,
            string query,
            string variables,
            string operationName,
            CancellationToken cancellation)
        {
            var result = await ExecuteAsync(query, operationName, JObject.Parse(variables), cancellation);

            var response = await RespondAsync(request, result);

            return response;
        }

        [Route("{oparationName}")]
        public Task<HttpResponseMessage> GetAsync(HttpRequestMessage request, string operationName, CancellationToken cancellation)
        {
            var variables = new JObject();
            foreach (var x in request.GetQueryNameValuePairs())
                variables.Add(x.Key, x.Value);

            return PostAsync(request, new GraphQLQuery {
                OperationName = operationName,
                Query = QUERY,
                Variables = variables
            }, cancellation);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> PostAsync(HttpRequestMessage request, GraphQLQuery query, CancellationToken cancellation)
        {
            var inputs = query?.Variables?.ToInputs();
            var queryToExecute = query.Query;

            if (!string.IsNullOrWhiteSpace(query.NamedQuery))
            {
                queryToExecute = _namedQueries[query.NamedQuery];
            }

            var result = await _executer.ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = queryToExecute;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;

                _.ComplexityConfiguration = new ComplexityConfiguration { MaxDepth = 15 };
                _.FieldMiddleware.Use<InstrumentFieldsMiddleware>();
                _.CancellationToken = cancellation;
#if (DEBUG)
                _.ExposeExceptions = true;
                _.EnableMetrics = true;
#endif

            }).ConfigureAwait(false);

            var httpResult = result.Errors?.Count > 0
                ? HttpStatusCode.BadRequest
                : HttpStatusCode.OK;

            var response = request.CreateResponse(httpResult);

            var stream = new MemoryStream();

            await _writer.WriteAsync(stream, result);

            stream.Position = 0L;

            response.Content = new StreamContent(stream);

            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json"); // MimeMapping.GetMimeMapping(imagePath)

            return response;
        }

        async Task<ExecutionResult> ExecuteAsync(
            string query,
            string operationName,
            JObject variables,
            CancellationToken cancellation)
        {
            var inputs = variables?.ToInputs();
            var queryToExecute = query;

            var result = await _executer.ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = queryToExecute;
                _.OperationName = operationName;
                _.Inputs = inputs;

                _.ComplexityConfiguration = new ComplexityConfiguration { MaxDepth = 15 };
                _.FieldMiddleware.Use<InstrumentFieldsMiddleware>();
                _.CancellationToken = cancellation;
#if (DEBUG)
                _.ExposeExceptions = true;
                _.EnableMetrics = true;
#endif

            }).ConfigureAwait(false);

            return result;
        }

        async Task<HttpResponseMessage> RespondAsync(HttpRequestMessage request, ExecutionResult result)
        {
            var httpResult = result.Errors?.Count > 0
                ? HttpStatusCode.BadRequest
                : HttpStatusCode.OK;

            var response = request.CreateResponse(httpResult);

            var stream = new MemoryStream();

            await _writer.WriteAsync(stream, result);

            stream.Position = 0L;

            response.Content = new StreamContent(stream);

            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json"); // MimeMapping.GetMimeMapping(imagePath)

            return response;
        }
    }
}
