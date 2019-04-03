using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orb
{
    public class DivisionService
    {
        readonly OrbDbContext _context;

        public DivisionService(OrbDbContext context)
        {
            _context = context;
        }
    }
}
