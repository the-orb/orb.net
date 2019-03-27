using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Orb
{
    [Route("api/feeds")]
    public class FeedsApiController : ApiController
    {
        readonly FeedService _service;

        public FeedsApiController(FeedService service)
        {
            _service = service;
        }
    }
}
