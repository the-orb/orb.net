using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orb
{
    public class FamilyService
    {
        readonly OrbDbContext _context;

        public FamilyService(OrbDbContext context)
        {
            _context = context;
        }
    }
}
