using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.Server.Controllers
{
    [Route("graphql/[controller]")]
    [ApiController]
    public abstract class GraphController : ControllerBase
    {
    }
}