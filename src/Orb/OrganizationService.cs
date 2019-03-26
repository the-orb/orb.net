using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orb
{
    public class OrganizationService
    {
        readonly OrbDbContext _context;

        public OrganizationService(OrbDbContext context)
        {
            _context = context;
        }
    }
}
