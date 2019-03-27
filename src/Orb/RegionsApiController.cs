using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Orb
{
    public class RegionsApiController : ApiController
    {
        readonly RegionService _service;

        public RegionsApiController(RegionService service)
        {
            _service = service;
        }
    }
}
