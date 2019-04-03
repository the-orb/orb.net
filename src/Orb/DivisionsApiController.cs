using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Orb
{
    public class DivisionsApiController : ApiController
    {
        readonly DivisionService _service;

        public DivisionsApiController(DivisionService service)
        {
            _service = service;
        }
    }
}
