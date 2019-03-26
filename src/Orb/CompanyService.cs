using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orb
{
    public class CompanyService
    {
        readonly OrbDbContext _context;

        public CompanyService(OrbDbContext context)
        {
            _context = context;
        }
    }
}
