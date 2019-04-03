using GraphQL;
using GraphQL.Http;
using GraphQL.Instrumentation;
using GraphQL.Types;
using GraphQL.Validation.Complexity;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace Server.Web.Controllers
{
    using Models;

    [Route("graphql/orb")]
    public class OrbGraphQLController : ApiController
    {
        protected readonly ISchema _schema;
        protected readonly IDocumentExecuter _executer;
        protected readonly IDocumentWriter _writer;
        protected readonly IDictionary<string, string> _namedQueries;

        public OrbGraphQLController(
            IDocumentExecuter executer,
            IDocumentWriter writer,
            ISchema schema)
        {
            _executer = executer;
            _writer = writer;
            _schema = schema;

            _namedQueries = new Dictionary<string, string>
            {
                ["a-query"] = @"query foo { hero { name } }"
            };
        }

        public Task<HttpResponseMessage> GetAsync(HttpRequestMessage request)
        {
            return PostAsync(request, new GraphQLQuery { Query = "query foo { hero }", Variables = null });
        }

        [HttpPost]
        public async Task<HttpResponseMessage> PostAsync(HttpRequestMessage request, GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();
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

            }).ConfigureAwait(false);

            var httpResult = result.Errors?.Count > 0
                ? HttpStatusCode.BadRequest
                : HttpStatusCode.OK;

            var response = request.CreateResponse(httpResult);

            var stream = new MemoryStream();

            await _writer.WriteAsync(stream, result);

            stream.Position = 0L;

            response.Content = new StreamContent(stream, 200);

            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json"); // MimeMapping.GetMimeMapping(imagePath)

            return response;
        }
    }
}