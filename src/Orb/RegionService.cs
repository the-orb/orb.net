﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orb
{
    public class RegionService
    {
        readonly OrbDbContext _context;

        public RegionService(OrbDbContext context)
        {
            _context = context;
        }
    }
}
