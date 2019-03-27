using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Orb
{
    [Route("api/markets")]
    public class MarketsApiController : ApiController
    {
        readonly MarketService _service;
        public MarketsApiController(MarketService service)
        {
            _service = service;
        }
    }
}
