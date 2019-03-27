using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orb
{
    public class MembershipService
    {
        readonly OrbDbContext _context;

        public MembershipService(OrbDbContext context)
        {
            _context = context;
        }
    }
}
