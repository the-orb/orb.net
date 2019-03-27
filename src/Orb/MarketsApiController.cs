using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Orb
{
    [RoutePrefix("api/markets")]
    public class MarketsApiController : ApiController
    {
        readonly MarketService _service;
        public MarketsApiController(MarketService service)
        {
            _service = service;
        }

        [HttpGet(), Route("/")]
        public Task<HttpResponseMessage> GetMarketsAsync(HttpRequestMessage request)
        {
            var httpResult = HttpStatusCode.OK;

            var response = request.CreateResponse(httpResult);

            response.Content = new StringContent("{ data: [] }", Encoding.UTF8, "application/json");

            return Task.FromResult(response);
        }

        [HttpGet, Route("/networks")]
        public Task<HttpResponseMessage> GetNetworksAsync(HttpRequestMessage request)
        {
            var httpResult = HttpStatusCode.OK;

            var response = request.CreateResponse(httpResult);

            response.Content = new StringContent("{ data: [] }", Encoding.UTF8, "application/json");

            return Task.FromResult(response);
        }
    }
}
