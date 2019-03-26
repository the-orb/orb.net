using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orb
{
    public class IndividualService
    {
        readonly OrbDbContext _context;

        public IndividualService(OrbDbContext context)
        {
            _context = context;
        }
    }
}
