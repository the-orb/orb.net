using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orb
{
    public class MarketService
    {
        readonly OrbDbContext _context;

        public MarketService(OrbDbContext context)
        {
            _context = context;
        }
    }
}
