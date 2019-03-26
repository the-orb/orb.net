using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orb
{
    public class NetworkService
    {
        readonly OrbDbContext _context;

        public NetworkService(OrbDbContext context)
        {
            _context = context;
        }
    }
}
