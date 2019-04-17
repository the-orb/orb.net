using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace GraphQL.Http
{
    using Instrumentation;
    using Types;
    using Validation.Complexity;

    public abstract class GraphController : ApiController
    {
        readonly ISchema _schema;
        readonly IDocumentExecuter _executer;
        readonly IDocumentWriter _writer;
        readonly IDictionary<string, string> _namedQueries;

        public GraphController(
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

        [HttpPost]
        public async Task<HttpResponseMessage> PostAsync(HttpRequestMessage request, PostBody query, CancellationToken cancellation)
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
