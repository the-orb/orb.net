using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Http;

namespace GraphQL.Http
{
    public class RelayResponse
    {
        public IDocumentWriter Writer { get; set; }

        public bool IsBatched { get; set; }

        public IEnumerable<ExecutionResult> Results { get; set; }

        public IEnumerable<ExecutionError> Errors =>
            Results?.SelectMany(r => r.Errors) ?? new List<ExecutionError>();

        public bool HasErrors => Results.Any(r => r.Errors?.Count > 0);

        public async Task<Stream> WriteAsync()
        {
            var stream = new MemoryStream();

            await WriteAsync(stream);

            return stream;
        }

        public Task WriteAsync(Stream stream) =>
            Writer.WriteAsync(stream, IsBatched ?
                (object)Results :
                Results.FirstOrDefault()
            );
    }
}
