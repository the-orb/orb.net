﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Orb
{
    public class CompaniesApiController : ApiController
    {
        readonly CompanyService _service;

        public CompaniesApiController(CompanyService service)
        {
            _service = service;
        }
    }
}
