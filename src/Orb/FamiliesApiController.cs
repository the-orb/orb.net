﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Orb
{
    public class FamiliesApiController : ApiController
    {
        readonly FamilyService _service;

        public FamiliesApiController(FamilyService service)
        {
            _service = service;
        }
    }
}
