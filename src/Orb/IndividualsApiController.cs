using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Orb
{
    [Route("api/individuals")]
    public class IndividualsApiController
    {
        readonly IndividualService _service;

        public IndividualsApiController(IndividualService service)
        {
            _service = service;
        }
    }
}
